using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PortfolioProject.Models;
namespace PortfolioProject.Controllers
{
    public class HomeSkillController : Controller
    {
        // GET: HomeSkill

        PortfolioProjectDbEntities db = new PortfolioProjectDbEntities();
       public PartialViewResult Skills()
		{
          var result=  db.Skills.ToList();
            return PartialView(result);
		}
    }
}