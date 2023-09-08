using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PortfolioProject.Models;
namespace PortfolioProject.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        PortfolioProjectDbEntities db = new PortfolioProjectDbEntities();
        [Authorize]
        public ActionResult Index()
        {
            var result = db.Messages.ToList();
            return View(result);
        }
    }
}