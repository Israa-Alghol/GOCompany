using GOCompanies.Models;
using GOCompanies.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GOCompanies.Controllers
{
    public class VehicleController : Controller
    {
        private readonly ICRepo<Vehicle> cRepo;

        public VehicleController(ICRepo<Vehicle> cRepo)
        {
            this.cRepo = cRepo;
        }
        // GET: VehicleController
        [HttpGet]
        public ActionResult Index()
        {
            var vehicle = cRepo.GetAll();

            return View(vehicle);
        }

        // GET: VehicleController/Details/5
        public ActionResult Details(int id)
        {
            var vehicle = cRepo.GetById(id);
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
                cRepo.Add(vehicle);
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
            var vehicle = cRepo.GetById(id);
            return View(vehicle);
        }

        // POST: VehicleController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Vehicle vehicle)
        {
            try
            {
                cRepo.Update(vehicle);
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
            var vehicle = cRepo.GetById(id);
            return View(vehicle);
        }

        // POST: VehicleController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Vehicle vehicle)
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
