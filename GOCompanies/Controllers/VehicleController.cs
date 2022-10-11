using GOCompanies.Models;
using GOCompanies.Repositories;
using GOCompanies.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace GOCompanies.Controllers
{
    public class VehicleController : BaseController
    {
        private readonly ICRepo<Vehicle> vRepo;
        private readonly ICRepo<Company> cRepo;
        private readonly CDBContext _dbContext;

        public VehicleController(ICRepo<Company> cRepo, ICRepo<Vehicle> vRepo, CDBContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
            this.vRepo = vRepo;
            this.cRepo = cRepo;
        }
        [HttpGet]
        public ActionResult GetVehicles()
        {
            return Ok(vRepo.GetAll());
        }
        // GET: VehicleController
        [HttpGet]
        public ActionResult Index()
        {
            var vehicle = vRepo.GetAll();

            return View(vehicle);
        }

        // GET: VehicleController/Details/5
        public ActionResult Details(int id)
        {
            var vehicle = vRepo.GetById(id);
            return View(vehicle);
        }

        // GET: VehicleController/Create
        public ActionResult Create()
        {
            var model = new CompanyViewModel
            {

                Companies = FillSelectList()
            };
            return View(model);
        }

        // POST: VehicleController/Create
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
                    Vehicle vehicle = new Vehicle
                    {
                        Id = model._vehicle.Id,
                        Name = model._vehicle.Name,
                        CompanyId = company.Id,
                        Company = company,

                    };
                    vRepo.Add(vehicle);
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

        // GET: VehicleController/Edit/5
        public ActionResult Edit(int id)
        {
            var vehicle = vRepo.GetById(id);
            return View(vehicle);
        }

        // POST: VehicleController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Vehicle vehicle)
        {
            try
            {
                vRepo.Update(vehicle);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: VehicleController/Delete/5
        public ActionResult Delete(int id)
        {
            var vehicle = vRepo.GetById(id);
            return View(vehicle);
        }

        // POST: VehicleController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Vehicle vehicle)
        {
            try
            {
                vRepo.Delete(id);
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
        public ActionResult List(int companyId)
        {
            var result = vRepo.List2(a => a.CompanyId == companyId);

            return View("Index", result);
        }
    }
}
