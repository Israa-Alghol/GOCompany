using GOCompanies.Models;
using GOCompanies.Repositories;
using GOCompanies.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.Text.Json;
using System;
using System.Text;
using System.Text.Json.Serialization;

namespace GOCompanies.Controllers
{
    public class BaseController : Controller
    {
        public static List<SelectListItem> _Companies { get; set; }

        private readonly CDBContext _dbContext;


        public BaseController(CDBContext dbContext)
        {
            _dbContext = dbContext;
            
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            _Companies = _dbContext.Companies.Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.Id.ToString(),
            }).ToList();
            base.OnActionExecuting(context);
           
            //string jsonString = JsonSerializer.Serialize(_Companies);
           
            //HttpContext.Session.Set<List<SelectListItem>>("cartItems", _Companies);

        }


        //public ActionResult Act(CompanyViewModel viewModel)
        //{
        //    var w = ControllerContext.ActionDescriptor.AttributeRouteInfo.Name;


        //    return View(viewModel);
        //}
    }
}
