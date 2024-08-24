using Microsoft.AspNetCore.Mvc;
using Paradise.Data;
using Paradise.Models;
using Paradise.Models.FormModels;
using Paradise.Services;
namespace Paradise.Controllers
{
    public class HomeController : Controller
    {
        private readonly LeadTokenService _tokenService;
        private readonly AppDbContext _context;
        public HomeController(AppDbContext context)
        {
            _tokenService = new LeadTokenService();
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult NotFound()
        {
            return View();
        }
        public IActionResult Medicare()
        {
            ViewBag.ShowLeadToken = false;
            return View();
        }
        public IActionResult MVA()
        {
            ViewBag.ShowLeadToken = false;
            return View();
        }
        public IActionResult ACA()
        {
            ViewBag.ShowLeadToken = false;
            return View();
        }
        public IActionResult AutoInsurance()
        {
            ViewBag.ShowLeadToken = false;
            return View();
        }
        public IActionResult FinalInsurance()
        {
            ViewBag.ShowLeadToken = false;
            return View();
        }
        public IActionResult Contact()
        {
            
            return View();
        }

        public IActionResult ContactUs(ContactUs model)
        {
            Insert(model);
            
            return View("Submitted");
        }
        [HttpPost]
        public IActionResult HandleAutoInsuranceForm(AutoInsurance model)
        {
            var email = model.BasicInfo.Email;

            model.BasicInfo.DateOfSubmission = Utilities.Utilities.EasternTime();

            LeadToken leadToken = new LeadToken();
            leadToken.Token = _tokenService.GenerateToken(email);
            leadToken.Email = email;
            Insert(leadToken);
            model.LeadToken = leadToken;
            Insert(model);
            ViewBag.ShowLeadToken = true;
            return View("AutoInsurance", model);

        }
        
        [HttpPost]
 
        public IActionResult HandleFinalInsuranceForm(FinalInsurance model)
        {
            var email = model.BasicInfo.Email;
            model.BasicInfo.DateOfSubmission = Utilities.Utilities.EasternTime();
            LeadToken leadToken = new LeadToken();
            leadToken.Token = _tokenService.GenerateToken(email);
            leadToken.Email = email;
            Insert(leadToken);
            model.LeadToken = leadToken;
            Insert(model);
            ViewBag.ShowLeadToken = true;
            return View("FinalInsurance", model);
        }

        [HttpPost]
        public IActionResult HandleACAForm(ACA model)
        {
            var email = model.BasicInfo.Email;
            model.BasicInfo.DateOfSubmission = Utilities.Utilities.EasternTime();
            LeadToken leadToken = new LeadToken();
            leadToken.Token = _tokenService.GenerateToken(email);
            leadToken.Email = email;
            Insert(leadToken);
            model.LeadToken = leadToken;
            Insert(model);
            ViewBag.ShowLeadToken = true;
            return View("ACA", model);
        }
        [HttpPost]
        public IActionResult HandleMVAForm(MVA model)
        {
            var email = model.BasicInfo.Email;
            model.BasicInfo.DateOfSubmission = Utilities.Utilities.EasternTime();
            LeadToken leadToken = new LeadToken();
            leadToken.Token = _tokenService.GenerateToken(email);
            leadToken.Email = email;
            Insert(leadToken);
            model.LeadToken = leadToken;
            Insert(model);
            ViewBag.ShowLeadToken = true;
            return View("MVA", model);
        }

        [HttpPost]
        public IActionResult HandleMedicareForm(Medicare model)
        {
            var email = model.BasicInfo.Email;
            model.BasicInfo.DateOfSubmission = Utilities.Utilities.EasternTime();
            LeadToken leadToken = new LeadToken();
            leadToken.Token = _tokenService.GenerateToken(email);
            leadToken.Email = email;
            Insert(leadToken);
            model.LeadToken = leadToken;
            Insert(model);
            ViewBag.ShowLeadToken = true;
            return View("Medicare",model);
        }
        private void Insert(object model)
        {
            _context.Add(model);
            _context.SaveChanges();
        }

    }
}
