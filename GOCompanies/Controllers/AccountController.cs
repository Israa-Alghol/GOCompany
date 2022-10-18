using GOCompanies.Models;
using GOCompanies.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Threading.Tasks;

namespace GOCompanies.Controllers
{
    public class AccountController : Controller
    {
        //private readonly CDBContext _context;

        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(UserManager<IdentityUser> userManager,
                                      SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }


        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegistrationViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser
                {
                    UserName = model.Name,
                    
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);

                    return RedirectToAction("index", "Home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");

            }
            return View(model);
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel user)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(user.Name, user.Password, user.RememberMe, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");

            }
            return View(user);
        }
        [AllowAnonymous]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }

        //[HttpPost]
        //public async Task<ActionResult> Login(LoginViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var userdetails = await _context.Userdetails
        //        .SingleOrDefaultAsync(m => m.Password == model.Password);
        //        if (userdetails == null)
        //        {
        //            ModelState.AddModelError("Password", "Invalid login attempt.");
        //            return View("Index");
        //        }
        //        HttpContext.Session.SetString("userId", userdetails.Name);

        //    }
        //    else
        //    {
        //        return View("Index");
        //    }
        //    return RedirectToAction("Index", "Home");
        //}
        //[HttpPost]
        //public async Task<ActionResult> Registar(RegistrationViewModel model)
        //{

        //    if (ModelState.IsValid)
        //    {
        //        Userdetails user = new Userdetails
        //        {
        //            Name = model.Name,
        //            Password = model.Password,

        //        };
        //        _context.Add(user);
        //        await _context.SaveChangesAsync();

        //    }
        //    else
        //    {
        //        return View("Registration");
        //    }
        //    return RedirectToAction("Index", "Account");
        //}
        //// registration Page load
        //public IActionResult Registration()
        //{
        //    ViewData["Message"] = "Registration Page";

        //    return View();
        //}
        //public IActionResult Logout()
        //{
        //    HttpContext.Session.Clear();
        //    return View("Index");
        //}
        //public void ValidationMessage(string key, string alert, string value)
        //{
        //    try
        //    {
        //        TempData.Remove(key);
        //        TempData.Add(key, value);
        //        TempData.Add("alertType", alert);
        //    }
        //    catch
        //    {
        //        Debug.WriteLine("TempDataMessage Error");
        //    }

        //}
    }
}
