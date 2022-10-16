using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using GOCompanies.Models;
using GOCompanies.Repositories;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GOCompanies.Controllers
{
    public class HomeController : BaseController
    {

        private readonly ILogger<HomeController> _logger;
        private readonly CDBContext _dbContext;
        private readonly ICRepo<Home1> _hRepo;

        public HomeController(ILogger<HomeController> logger, CDBContext dbContext) :base(dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
           
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public ActionResult List(int companyId)
        {
            var result = _hRepo.List3(a => a.CompanyId == companyId);

            return View("Index", result);
        }
    }
}
