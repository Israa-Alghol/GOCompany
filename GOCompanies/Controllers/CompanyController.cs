using GOCompanies.Models;
using GOCompanies.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace GOCompanies.Controllers
{
    public class CompanyController : BaseController
    {
        private readonly ICRepo<Company> cRepo;
        private readonly CDBContext _dbContext;

        public CompanyController(ICRepo<Company> cRepo,CDBContext dbContext):base(dbContext)
        {
            _dbContext = dbContext; 
            this.cRepo = cRepo;
        }

      

        // GET: CompanyController
        [HttpGet]
        public ActionResult Index()
        {
            var company = cRepo.GetAll();

            return View(company);
        }

        // GET: CompanyController/Details/5
        public ActionResult Details(int id)
        {
            var company = cRepo.GetById(id);
            return View(company);
        }

        // GET: CompanyController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CompanyController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Company company)
        {
            try
            {
                cRepo.Add(company);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CompanyController/Edit/5
        public ActionResult Edit(int id)
        {
            var company = cRepo.GetById(id);
            return View(company);
        }

        // POST: CompanyController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Company company)
        {
            try
            {
                cRepo.Update(company);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CompanyController/Delete/5
        public ActionResult Delete(int id)
        {
            var company = cRepo.GetById(id);
            return View(company);
        }

        // POST: CompanyController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Company company)
        {
            try
            {
                cRepo.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
