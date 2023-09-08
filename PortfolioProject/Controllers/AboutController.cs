using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PortfolioProject.Models;

namespace PortfolioProject.Controllers
{
	public class AboutController : Controller
	{
		// GET: About
		PortfolioProjectDbEntities db = new PortfolioProjectDbEntities();
		[Authorize]
		public ActionResult Index()
		{
			var result = db.About.ToList();
			return View(result);
		}

		[HttpGet]
		public ActionResult AddAbout()
		{
			return View();
		}

		[HttpPost]
		public ActionResult AddAbout(About about)
		{
			db.About.Add(about);
			db.SaveChanges();
			return RedirectToAction("Index");
		}

		public ActionResult DeleteAbout(int id)
		{
			var abouToDelete = db.About.Find(id);
			db.About.Remove(abouToDelete);
			db.SaveChanges();
			return RedirectToAction("Index");
		}

		[HttpGet]
		public ActionResult UpdateAbout(int id)
		{
			var abouToUpdate = db.About.Find(id);
			return View(abouToUpdate);
		}
		[HttpPost]
		public ActionResult UpdateAbout(About about)
		{
			var update = db.About.Find(about.ID);
			update.Heading = about.Heading;
			update.Description = about.Description;
			update.Addresse = about.Addresse;
			update.Email = about.Email;
			update.Image = about.Image;
			update.Name = about.Name;
			update.Phone = about.Phone;
			db.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}