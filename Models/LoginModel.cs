using Microsoft.AspNetCore.Mvc;

namespace Paradise.Models
{
    public class LoginModel
    {
        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string Password { get; set; }
    }
}
