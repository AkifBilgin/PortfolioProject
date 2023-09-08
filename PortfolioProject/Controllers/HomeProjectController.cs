using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PortfolioProject.Models;
namespace PortfolioProject.Controllers
{
    public class HomeProjectController : Controller
    {
        // GET: HomeProject
        PortfolioProjectDbEntities db = new PortfolioProjectDbEntities();
        public PartialViewResult Project()
		{
            var result = db.Projects.ToList();
            return PartialView(result);
		}
    }
}