using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PortfolioProject.Models;
namespace PortfolioProject.Controllers
{
    public class SkillsController : Controller
    {
        // GET: Skills
        PortfolioProjectDbEntities db = new PortfolioProjectDbEntities();
        [Authorize]
        public ActionResult Index()
        {
            var result = db.Skills.ToList();
            return View(result);
        }
        [HttpGet]
        public ActionResult AddSkill()
		{
            return View();
		}
        [HttpPost]
        public ActionResult AddSkill(Skills skills)
		{
            db.Skills.Add(skills);
            db.SaveChanges();
            return RedirectToAction("Index");
		}

        public ActionResult DeleteSkill(int id)
		{
            var skillToDelete = db.Skills.Find(id);
            db.Skills.Remove(skillToDelete);
            db.SaveChanges();
            return RedirectToAction("Index");
		}

        [HttpGet]
        public ActionResult UpdateSkill(int id)
		{
            var result = db.Skills.Find(id);
            return View(result);
        }
        [HttpPost]
        public ActionResult UpdateSkill(Skills skills)
		{
            var update = db.Entry(skills);
            update.State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
		}
    }
}