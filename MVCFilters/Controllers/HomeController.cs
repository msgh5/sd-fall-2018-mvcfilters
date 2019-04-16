using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCFilters.Models;
using MVCFilters.Models.Filters;

namespace MVCFilters.Controllers
{
    public class HomeController : Controller
    {   
        private ApplicationDbContext Context { get; set; }

        public HomeController()
        {
            Context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            //CreateLog("Index", "Home");

            return View();
        }

        [MVCFiltersAuthorization(Roles = "Admin")]
        public ActionResult AdminsOnly()
        {   
            return View();
        }

        public ActionResult About()
        {
            //CreateLog("About", "Home");

            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Unauthorized()
        {
            return View();
        }

        private void CreateLog(string actionName, string controllerName)
        {
            var log = new ActionLog();
            log.ActionName = actionName;
            log.ControllerName = controllerName;

            Context.ActionLogs.Add(log);
            Context.SaveChanges();
        }
    }
}