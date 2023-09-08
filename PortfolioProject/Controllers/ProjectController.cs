using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PortfolioProject.Models;
namespace PortfolioProject.Controllers
{
    public class ProjectController : Controller
    {
        // GET: Project
        PortfolioProjectDbEntities db = new PortfolioProjectDbEntities();
        [Authorize]
        public ActionResult Index()
        {
            var result = db.Projects.ToList();
            return View(result);
        }
        [HttpGet]
        public ActionResult AddProject()
		{
            return View();
		}
        [HttpPost]
        public ActionResult AddProject(Projects project)
        {
            db.Projects.Add(project);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateProject(int id)
		{
            var result = db.Projects.Find(id);
            return View(result);
		}
        [HttpPost]
        public ActionResult UpdateProject(Projects project)
        {
            var update = db.Projects.Find(project.ID);
            update.Heading = project.Heading;
            update.Description = project.Description;
            update.Image = project.Image;
            update.GitHubLink = project.GitHubLink;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteProject(int id)
		{
            var delete = db.Projects.Find(id);
            db.Projects.Remove(delete);
            db.SaveChanges();
            return RedirectToAction("Index");
		}
    }
}