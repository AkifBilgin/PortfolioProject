using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PortfolioProject.Models;
namespace PortfolioProject.Controllers
{
    public class CustomAboutController : Controller
    {
        // GET: CustomAbout
        PortfolioProjectDbEntities db = new PortfolioProjectDbEntities();
       public PartialViewResult About()
		{
            var result = db.About.ToList();
            return PartialView(result);
		}
    }
}