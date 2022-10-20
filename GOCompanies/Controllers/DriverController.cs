using GOCompanies.Models;
using GOCompanies.Repositories;
using GOCompanies.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GOCompanies.Controllers
{
    public class DriverController : BaseController
    {
        private readonly ICRepo<Driver> dRepo;
        private readonly ICRepo<Company> cRepo;
        private readonly ICRepo<Vehicle> vRepo;
        private readonly CDBContext _dbContext;

        public DriverController(ICRepo<Company> cRepo, ICRepo<Vehicle> vRepo, ICRepo<Driver> dRepo, CDBContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
            this.dRepo = dRepo;
            this.cRepo = cRepo;
            this.vRepo = vRepo;
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
            //var driver = dRepo.GetAll();

            //return View(driver);
            return View();
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
                Vehicles = FillSelectListV(),
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
                    //if (model.Company == -1)
                    //{
                    //    ViewBag.Message = "Please select an company from the list!";

                    //    return View(GetAllCompanies());
                    //}           

                    var company = cRepo.GetById(model.Company);
                    var vehicle = vRepo.GetById(model.Vehicle);
                    Driver driver = new Driver
                    {
                        Id = model.driverId,
                        Name = model.nameDriver,
                        CompanyId = company.Id,
                        Company = company,
                        VehicleId = vehicle.Id, 
                        Vehicle = vehicle,

                    };
                    dRepo.Add(driver);
                    return RedirectToAction(nameof(List));
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
            var CompanyId = 0;
            if (driver.Company == null)
            {

                CompanyId = driver.Id;
                driver.Company.Id = 0;
            }
            else

                CompanyId = driver.Company.Id;

            var VehicleId = 0;
            if (driver.Vehicle == null)
            {

                VehicleId = driver.Id;
                driver.Vehicle.Id = 0;
            }
            else

                VehicleId = driver.Vehicle.Id;

            var viewModel = new CompanyViewModel
            {
                driverId = driver.Id,
                nameDriver = driver.Name,
                Company = CompanyId,
                Companies = cRepo.GetAll().ToList(),
                Vehicle = VehicleId,
                Vehicles = vRepo.GetAll().ToList(),

            };
            return View(viewModel);
        }

        // POST: DriverController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CompanyViewModel viewModel)
        {
            try
            {               
                var company = cRepo.GetById(viewModel.Company);
                var vehicle = vRepo.GetById(viewModel.Vehicle);
                Driver driver = new Driver
                {
                    Id = viewModel.driverId,
                    Name = viewModel.nameDriver,
                    Company = company,
                    Vehicle = vehicle,

                };
                dRepo.Update(driver);
                return RedirectToAction(nameof(List));

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
        public ActionResult ConfirmDelete(int id)
        {

            try
            {
                dRepo.Delete(id);
                return RedirectToAction(nameof(List));
            }
            catch
            {
                return View();
            }
        }
        List<Company> FillSelectList()
        {
            var companies = cRepo.GetAll().ToList();
            //companies.Insert(0, new Company { Id = -1, Name = " --- Please select an company --- " });
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
        List<Vehicle> FillSelectListV()
        {
            var vehicles = vRepo.GetAll().ToList();
            //vehicles.Insert(0, new Vehicle { Id = -1, Name = " --- Please select an vehicle --- " });
            return vehicles;
        }
        CompanyViewModel GetAllVehicles()
        {
            var vmodel = new CompanyViewModel
            {

                Vehicles = FillSelectListV()
            };
            return vmodel;
        }
        public ActionResult List(int companyId)
        {
            if (companyId == 0)
            {
                if(HttpContext.Session.GetInt32("Session2") != null)
                {
                    companyId = (int)HttpContext.Session.GetInt32("Session2");
                    var result = dRepo.List(a => a.CompanyId == companyId);
                    var company = cRepo.GetById(companyId);
                    HttpContext.Session.SetInt32("Session2", companyId);
                    HttpContext.Session.SetString("Session1", company.Name);

                    return View("Index", result);
                }
                return RedirectToAction(nameof(Index));
            }
            else
            {
                var result = dRepo.List(a => a.CompanyId == companyId);
                var company = cRepo.GetById(companyId);
                //if (result.Any())
                //{
                HttpContext.Session.SetInt32("Session2", companyId);
                HttpContext.Session.SetString("Session1", company.Name);
                //    var name = result.Where(x => x.CompanyId == companyId).SingleOrDefault()?.Company.Name;
                //    ViewBag.Company = name;

                //}

                return View("Index", result);
            }
            
        }
        
    }
}
