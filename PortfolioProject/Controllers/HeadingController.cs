using PortfolioProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortfolioProject.Controllers
{
    public class HeadingController : Controller
    {
        // GET: Heading
        PortfolioProjectDbEntities db = new PortfolioProjectDbEntities();
        [Authorize]
        public ActionResult Index()
        {
            var result = db.Heading.ToList();
            return View(result);
        }
    [HttpGet]
    public ActionResult AddHeading()
		{
            return View();
		}
        [HttpPost]
        public ActionResult AddHeading(Heading heading)
        {
            db.Heading.Add(heading);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteHeading(int id)
		{
            var headingToDelete = db.Heading.Find(id);
            db.Heading.Remove(headingToDelete);
            db.SaveChanges();
            return RedirectToAction("Index");
		}
        [HttpGet]
        public ActionResult UpdateHeading(int id)
		{
            var result = db.Heading.Find(id);
            return View(result);
		}

        [HttpPost]
        public ActionResult UpdateHeading(Heading heading)
		{
            var headingToUpdate = db.Heading.Find(heading.ID);
            headingToUpdate.Description = heading.Description;
            headingToUpdate.Introduction = heading.Introduction;
            headingToUpdate.Skills = heading.Skills;
            headingToUpdate.Skills2 = heading.Skills2;
            headingToUpdate.Skills3 = heading.Skills3;
            db.SaveChanges();
            return RedirectToAction("Index");
		}
    }
}