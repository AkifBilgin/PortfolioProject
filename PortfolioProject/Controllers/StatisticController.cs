using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PortfolioProject.Models;
namespace PortfolioProject.Controllers
{
    public class StatisticController : Controller
    {
        // GET: Statistic
        PortfolioProjectDbEntities db = new PortfolioProjectDbEntities();
        [Authorize]
        public ActionResult Index()
        {
            ViewBag.messages = db.Messages.Count();
            ViewBag.projects = db.Projects.Count();

            decimal resultAvg = db.Projects.Average(a=>a.Price).Value;
            decimal roundedResultAvg = Math.Round(resultAvg, 2);
            ViewBag.avgPrice = roundedResultAvg;

            decimal resultMax = db.Projects.Max(a => a.Price).Value;
            decimal roundedResultMax = Math.Round(resultMax, 2);
            ViewBag.maxPrice = roundedResultMax;
            return View();
        }
    }
}