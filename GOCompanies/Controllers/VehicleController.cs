using GOCompanies.Models;
using GOCompanies.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GOCompanies.Controllers
{
    public class VehicleController : BaseController
    {
        private readonly ICRepo<Vehicle> vRepo;
        private readonly CDBContext _dbContext;

        public VehicleController(ICRepo<Vehicle> vRepo, CDBContext dbContext) : base(dbContext)
        {
            this._dbContext = dbContext;
            this.vRepo = vRepo;
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
            return View();
        }

        // POST: VehicleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Vehicle vehicle)
        {
            try
            {
                vRepo.Add(vehicle);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
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
    }
}
