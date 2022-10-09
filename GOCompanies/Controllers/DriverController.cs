using GOCompanies.Models;
using GOCompanies.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GOCompanies.Controllers
{
    public class DriverController : Controller
    {
        private readonly ICRepo<Driver> cRepo;

        public DriverController(ICRepo<Driver> cRepo)
        {
            this.cRepo = cRepo;
        }


        // GET: DriverController
        [HttpGet]
        public ActionResult Index()
        {
            var driver = cRepo.GetAll();

            return View(driver);
        }

        // GET: DriverController/Details/5
        public ActionResult Details(int id)
        {
            var driver = cRepo.GetById(id);
            return View(driver);
        }

        // GET: DriverController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DriverController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Driver driver)
        {
            try
            {
                cRepo.Add(driver);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DriverController/Edit/5
        public ActionResult Edit(int id)
        {
            var driver = cRepo.GetById(id);
            return View(driver);
        }

        // POST: DriverController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Driver driver)
        {
            try
            {
                cRepo.Update(driver);
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
            var driver = cRepo.GetById(id);
            return View(driver);
        }

        // POST: DriverController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id,Driver driver)
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
