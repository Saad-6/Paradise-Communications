using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Paradise.Areas.Admin.Models;
using Paradise.Models;

namespace Paradise.Controllers
{

    public class AccountController : Controller
    {
        private readonly SignInManager<SuperUser> _signInManager;
        private readonly UserManager<SuperUser> _userManager;
       // int count = 5;
        public AccountController(SignInManager<SuperUser> signInManager,UserManager<SuperUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult AccessDenied()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, isPersistent: false, lockoutOnFailure: true);
            
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Admin", new { area = "Admin" });
            }
            if (result.IsLockedOut)
            {
                ModelState.AddModelError(string.Empty, "Your account is locked out. Please try again later.");
            }
            else
            {

                ModelState.AddModelError(string.Empty, $"Invalid login attempt.\n Multiple violations will result in your account being locked out");
            }
            return View(model);
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AccountSettings()
        {
            var admins = await _userManager.GetUsersInRoleAsync("Admin");
            var model = new AccountSettingsViewModel
            {
                AdminUsers = admins.Select(a => new AdminUserViewModel { Email = a.Email }).ToList()
            };
            return View(model);
        }

        // POST: Admin/Account/ChangePassword
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ChangePassword(string currentPassword, string newPassword, string confirmNewPassword)
        {
            if (newPassword != confirmNewPassword)
            {
                return BadRequest("Passwords do not match.");
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return BadRequest("User not found.");
            }

            var result = await _userManager.ChangePasswordAsync(user, currentPassword, newPassword);
            if (result.Succeeded)
            {
                await _signInManager.RefreshSignInAsync(user);
                return Ok();
            }
            return BadRequest(result.Errors.FirstOrDefault()?.Description);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddAdminUser(string newAdminEmail, string newAdminPassword, string confirmAdminPassword)
        {
            if (newAdminPassword != confirmAdminPassword)
            {
                return BadRequest("Passwords do not match.");
            }
            var existingUser = await _userManager.FindByEmailAsync(newAdminEmail);
            if (existingUser != null)
            {
                return BadRequest("User with this email already exists.");
            }

            var user = new SuperUser { UserName = newAdminEmail, Email = newAdminEmail, LockoutEnabled = true };
            var result = await _userManager.CreateAsync(user, newAdminPassword);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Admin");
                return Ok();
            }
            
            return BadRequest(result.Errors.FirstOrDefault()?.Description);
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
