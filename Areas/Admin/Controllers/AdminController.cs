using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Paradise.Areas.Admin.Models;
using Paradise.Data;
using Paradise.Models.FormModels;

namespace Paradise.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly AppDbContext _context;
        private readonly DbSet<Medicare> _dbMedicare;
        private readonly DbSet<MVA> _dbMVA;
        private readonly DbSet<FinalInsurance> _dbFi;
        private readonly DbSet<ContactUs> _dbContact;
        private readonly DbSet<AutoInsurance> _dbAuto;
        private readonly DbSet<ACA> _dbACA;
        public AdminController(AppDbContext context) 
        { 
            _context = context;
            _dbMedicare = _context.Set<Medicare>();
            _dbACA = _context.Set<ACA>();
            _dbAuto = _context.Set<AutoInsurance>();
            _dbContact= _context.Set<ContactUs>();
            _dbFi = _context.Set<FinalInsurance>();
            _dbMVA= _context.Set<MVA>();

        }
        public IActionResult Index()
        {
           
            
            return View();
        }
        //public IActionResult ViewInsurance(string view)
        //{
        //    // Check if the view name exists in the dictionary
        //    if (!Utilities.Utilities.classMap.TryGetValue(view, out var entityType))
        //    {
        //        return NotFound(); // Handle the case where the view name is invalid
        //    }
        //    // Get the corresponding DbSet from the context using reflection
        //    var dbSetProperty = typeof(AppDbContext).GetProperty("_db" + view);
        //    if (dbSetProperty == null)
        //    {
        //        return NotFound(); // Handle the case where the DbSet doesn't exist
        //    }
        //    // Get the IQueryable from the DbSet property
        //    var dbSet = dbSetProperty.GetValue(_context);
        //    // Cast the IQueryable to IQueryable<TEntity>
        //    var queryableType = typeof(IQueryable<>).MakeGenericType(entityType);
        //    var query = (IQueryable)dbSet;
        //    // Use the Entity Framework Include method dynamically
        //    var includeMethod = typeof(EntityFrameworkQueryableExtensions).GetMethod("Include", new[] { queryableType, typeof(string) });
        //    if (includeMethod != null)
        //    {
        //        query = (IQueryable)includeMethod.MakeGenericMethod(entityType).Invoke(null, new object[] { query, "BasicInfo" });
        //        query = (IQueryable)includeMethod.MakeGenericMethod(entityType).Invoke(null, new object[] { query, "LeadToken" });
        //    }
        //    int index = 1;
        //    int defaultPageSize = 5;
        //    int count = (int)typeof(Queryable).GetMethods().Single(m => m.Name == "Count" && m.GetParameters().Length == 1)
        //                                       .MakeGenericMethod(entityType)
        //                                       .Invoke(null, new object[] { query });
        //    // Apply pagination
        //    query = (IQueryable)typeof(Queryable).GetMethods().Single(m => m.Name == "Skip" && m.GetParameters().Length == 2)
        //                                          .MakeGenericMethod(entityType)
        //                                          .Invoke(null, new object[] { query, (index - 1) * defaultPageSize });
        //    query = (IQueryable)typeof(Queryable).GetMethods().Single(m => m.Name == "Take" && m.GetParameters().Length == 2)
        //                                          .MakeGenericMethod(entityType)
        //                                          .Invoke(null, new object[] { query, defaultPageSize });

        //    var items = typeof(Enumerable).GetMethod("ToList").MakeGenericMethod(entityType).Invoke(null, new object[] { query });

        //    // Create a PaginatedList instance dynamically
        //    Type paginatedListType = typeof(PaginatedList<>).MakeGenericType(entityType);
        //    var paginatedList = Activator.CreateInstance(paginatedListType, items, count, index, defaultPageSize);

        //    ViewBag.pageSize = defaultPageSize;

        //    return View(view, paginatedList);
        //}



        public IActionResult Medicare()
        {
            var query = _dbMedicare.Include(m => m.BasicInfo).Include(m => m.LeadToken).AsQueryable();
            int index = 0;
            int defualtSite = 5;
            var count = query.Count();
            query = query.Skip(index).Take(defualtSite);
            var items = query.ToList();
            var paginatedList = new PaginatedList<Medicare>(items, count, index, defualtSite);
            ViewBag.pageSize = 5;
            return View(paginatedList);
        }
        public IActionResult MVA()
        {
            var query = _dbMVA.Include(m => m.BasicInfo).Include(m => m.LeadToken).AsQueryable();
            int index = 0;
            int defualtSite = 5;
            var count = query.Count();
            query = query.Skip(index).Take(defualtSite);
            var items = query.ToList();
            var paginatedList = new PaginatedList<MVA>(items, count, index, defualtSite);

            ViewBag.pageSize = 5;
            return View(paginatedList);

        }
        public IActionResult ACA()
        {
            var query = _dbACA.Include(m => m.BasicInfo).Include(m => m.LeadToken).AsQueryable();
            int index = 0;
            int defualtSite = 5;
            var count = query.Count();
            query = query.Skip(index).Take(defualtSite);
            var items = query.ToList();
            var paginatedList = new PaginatedList<ACA>(items, count, index, defualtSite);

            ViewBag.pageSize = 5;
            return View(paginatedList);

        }
        public IActionResult AutoInsurance()
        {
            var query = _dbAuto.Include(m => m.BasicInfo).Include(m => m.LeadToken).AsQueryable();
            int index = 0;
            int defualtSite = 5;
            var count = query.Count();
            query = query.Skip(index).Take(defualtSite);
            var items = query.ToList();
            var paginatedList = new PaginatedList<AutoInsurance>(items, count, index, defualtSite);

            ViewBag.pageSize = 5;
            return View(paginatedList);

        }
        public IActionResult FinalInsurance()
        {
            var query = _dbFi.Include(m => m.BasicInfo).Include(m => m.LeadToken).AsQueryable();
            int index = 0;
            int defualtSite = 5;
            var count = query.Count();
            query = query.Skip(index).Take(defualtSite);
            var items = query.ToList();
            var paginatedList = new PaginatedList<FinalInsurance>(items, count, index, defualtSite);

            ViewBag.pageSize = 5;
            return View(paginatedList);

        }
        public IActionResult UserQueries()
        {
            var query = _dbContact.AsQueryable<ContactUs>();
            int index = 0;
            int defualtSite = 5;
            var count = query.Count();
            query = query.Skip(index).Take(defualtSite);


            query = query.Skip(index).Take(defualtSite);
            var items = query.ToList();
            var paginatedList = new PaginatedList<ContactUs>(items, count, index, defualtSite);

            ViewBag.pageSize = 5;
            return View(paginatedList);
        }

        [HttpPost]
        public IActionResult MedicareFilters(string name = "", DateTime dos = default(DateTime), string phone = "", DateTime dateTime = default(DateTime), string token = "", int pageNumber = 1, int pageSize = 5)
        {
           
            var query = _dbMedicare.Include(m => m.BasicInfo).Include(m => m.LeadToken).AsQueryable<Medicare>();
            int pageIndex = pageNumber - 1;
            int startIndex = (pageSize * pageIndex);
            query = Query<Medicare>(query, name, dos, phone, dateTime, token);
       
            var count = query.Count();
            pageSize = pageSize == 0 ? count : pageSize;
            // Apply pagination
            query = query.Skip(startIndex).Take(pageSize);
            var items = query.ToList();
            var paginatedList = new PaginatedList<Medicare>(items, count, pageIndex, pageSize);

            ViewBag.pageSize = pageSize;
            return PartialView("_MedicareTable",paginatedList);
        }
        [HttpPost]
        public IActionResult MVAFilters(string name = "", DateTime dos = default(DateTime), string phone = "", DateTime dateTime = default(DateTime), string token = "", int pageNumber = 1, int pageSize = 5)
        {

            var query = _dbMVA.Include(m => m.BasicInfo).Include(m => m.LeadToken).AsQueryable<MVA>();
            int pageIndex = pageNumber - 1;
            int startIndex = (pageSize * pageIndex);
            query = Query<MVA>(query, name, dos, phone, dateTime, token);

            var count = query.Count();
            pageSize = pageSize == 0 ? count : pageSize;
            // Apply pagination
            query = query.Skip(startIndex).Take(pageSize);
            var items = query.ToList();
            var paginatedList = new PaginatedList<MVA>(items, count, pageIndex, pageSize);

            ViewBag.pageSize = pageSize;
            return PartialView("_MVATable", paginatedList);
        }
        [HttpPost]
        public IActionResult ACAFilters(string name = "", DateTime dos = default(DateTime), string phone = "", DateTime dateTime = default(DateTime), string token = "", int pageNumber = 1, int pageSize = 5)
        {

            var query = _dbACA.Include(m => m.BasicInfo).Include(m => m.LeadToken).AsQueryable<ACA>();
            int pageIndex = pageNumber - 1;
            int startIndex = (pageSize * pageIndex);
            query = Query<ACA>(query, name, dos, phone, dateTime, token);

            var count = query.Count();
            pageSize = pageSize == 0 ? count : pageSize;
            // Apply pagination
            query = query.Skip(startIndex).Take(pageSize);
            var items = query.ToList();
            var paginatedList = new PaginatedList<ACA>(items, count, pageIndex, pageSize);

            ViewBag.pageSize = pageSize;
            return PartialView("_ACATable", paginatedList);
        }
        [HttpPost]
        public IActionResult AutoInsuranceFilters(string name = "", DateTime dos = default(DateTime), string phone = "", DateTime dateTime = default(DateTime), string token = "", int pageNumber = 1, int pageSize = 5)
        {

            var query = _dbAuto.Include(m => m.BasicInfo).Include(m => m.LeadToken).AsQueryable<AutoInsurance>();
            int pageIndex = pageNumber - 1;
            int startIndex = (pageSize * pageIndex);
            query = Query<AutoInsurance>(query, name, dos, phone, dateTime, token);

            var count = query.Count();
            pageSize = pageSize == 0 ? count : pageSize;
            // Apply pagination
            query = query.Skip(startIndex).Take(pageSize);
            var items = query.ToList();
            var paginatedList = new PaginatedList<AutoInsurance>(items, count, pageIndex, pageSize);

            ViewBag.pageSize = pageSize;
            return PartialView("_AutoInsuranceTable", paginatedList);
        }
         [HttpPost]
        public IActionResult FinalInsuranceFilters(string name = "", DateTime dos = default(DateTime), string phone = "", DateTime dateTime = default(DateTime), string token = "", int pageNumber = 1, int pageSize = 5)
        {

            var query = _dbFi.Include(m => m.BasicInfo).Include(m => m.LeadToken).AsQueryable<FinalInsurance>();
            int pageIndex = pageNumber - 1;
            int startIndex = (pageSize * pageIndex);
            query = Query<FinalInsurance>(query, name, dos, phone, dateTime, token);

            var count = query.Count();
            pageSize = pageSize == 0 ? count : pageSize;
            // Apply pagination
            query = query.Skip(startIndex).Take(pageSize);
            var items = query.ToList();
            var paginatedList = new PaginatedList<FinalInsurance>(items, count, pageIndex, pageSize);

            ViewBag.pageSize = pageSize;
            return PartialView("_FinalInsuranceTable", paginatedList);
        } 
        public IActionResult ContactFilters(string name = "", string email = "", string phone = "", DateTime dateTime = default(DateTime), string token = "", int pageNumber = 1, int pageSize = 5)
        {

            var query = _dbContact.AsQueryable<ContactUs>();
            int pageIndex = pageNumber - 1;
            int startIndex = (pageSize * pageIndex);
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(m => m.FirstName.Contains(name));
                query = query.Where(m => m.LastName.Contains(name));
            }if (!string.IsNullOrEmpty(email))
            {
                query = query.Where(m => m.Email.Contains(email));
            }
            if (!string.IsNullOrEmpty(phone))
            {
                query = query.Where(m => m.Phone.Contains(phone));
            }

            var count = query.Count();
            pageSize = pageSize == 0 ? count : pageSize;
            query = query.Skip(startIndex).Take(pageSize);
            var items = query.ToList();
            var paginatedList = new PaginatedList<ContactUs>(items, count, pageIndex, pageSize);

            ViewBag.pageSize = pageSize;
            return PartialView("_ContactUsTable", paginatedList);
        }
        public IQueryable<T> Query<T>(IQueryable<T> query, string name, DateTime dos, string phone, DateTime dateTime, string token) where T : class
        {
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(m => EF.Property<string>(EF.Property<object>(m, "BasicInfo"), "FirstName").Contains(name) ||
                                          EF.Property<string>(EF.Property<object>(m, "BasicInfo"), "LastName").Contains(name));
            }
            if (dos != default(DateTime))
            {
                query = query.Where(m => EF.Functions.DateDiffDay(
                                             EF.Property<DateTime>(EF.Property<object>(m, "BasicInfo"), "DateOfSubmission"),
                                             dos) == 0);
            }


            if (!string.IsNullOrEmpty(phone))
            {
                query = query.Where(m => EF.Property<string>(EF.Property<object>(m, "BasicInfo"), "Phone").Contains(phone));
            }

            if (dateTime != default(DateTime))
            {
                query = query.Where(m => EF.Property<DateTime>(EF.Property<object>(m, "BasicInfo"), "DateOfBirth") == dateTime);
            }

            if (!string.IsNullOrEmpty(token))
            {
                query = query.Where(m => EF.Property<string>(EF.Property<object>(m, "LeadToken"), "Token").Contains(token));
            }

            return query;
        }
        public IActionResult DashBoard()
        {
            return View();
        }
    }
}
