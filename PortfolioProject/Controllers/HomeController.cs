using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PortfolioProject.Models;
namespace PortfolioProject.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        PortfolioProjectDbEntities db = new PortfolioProjectDbEntities();
        public ActionResult Index()
        {
            var result = db.Heading.ToList();
            return View(result);
        }
    }
}