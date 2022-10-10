using GOCompanies.Models;
using GOCompanies.Repositories;
using GOCompanies.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace GOCompanies.Controllers
{
    public class DriverController : BaseController
    {
        private readonly ICRepo<Driver> dRepo;
        private readonly ICRepo<Company> cRepo;
        private readonly CDBContext _dbContext;

        public DriverController(ICRepo<Company> cRepo,ICRepo<Driver> dRepo, CDBContext dbContext):base(dbContext)
        {
            _dbContext = dbContext; 
            this.dRepo = dRepo;
            this.cRepo = cRepo;
        }
        [HttpGet]

        public ActionResult GetDrivers()
        {
            return Ok(dRepo.GetAll());
        }

        // GET: DriverController
        [HttpGet]
        public ActionResult Index()
        {
            var driver = dRepo.GetAll();

            return View(driver);
        }

        // GET: DriverController/Details/5
        public ActionResult Details(int id)
        {
            var driver = dRepo.GetById(id);
            return View(driver);
        }

        // GET: DriverController/Create
        public ActionResult Create()
        {

            var model = new CompanyViewModel
            {

                Companies = FillSelectList()
            };
            return View(model);
        }

        // POST: DriverController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CompanyViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (model._company.Id == -1)
                    {
                        ViewBag.Message = "Please select an company from the list!";

                        return View(GetAllCompanies());
                    }

                    var company = cRepo.GetById(model._company.Id);
                    Driver driver = new Driver
                    {
                        Id = model._driver.Id,
                        Name = model._driver.Name,
                        Company = company,

                    };
                    dRepo.Add(driver);
                    return RedirectToAction(nameof(Index));

                }
                catch
                {
                    return View();
                }
            }

            ModelState.AddModelError("", "You have to fill all the required fields!");
            return View(GetAllCompanies());
        }

        // GET: DriverController/Edit/5
        public ActionResult Edit(int id)
        {
            var driver = dRepo.GetById(id);
            return View(driver);
        }

        // POST: DriverController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Driver driver)
        {
            try
            {
                dRepo.Update(driver);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DriverController/Delete/5
        public ActionResult Delete(int id)
        {
            var driver = dRepo.GetById(id);
            return View(driver);
        }

        // POST: DriverController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id,Driver driver)
        {
            try
            {
                dRepo.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        List<Company> FillSelectList()
        {
            var companies = cRepo.GetAll().ToList();
            companies.Insert(0, new Company { Id = -1, Name = " --- Please select an category --- " });
            return companies;
        }
        CompanyViewModel GetAllCompanies()
        {
            var vmodel = new CompanyViewModel
            {

                Companies = FillSelectList()
            };
            return vmodel;
        }
    }
}
