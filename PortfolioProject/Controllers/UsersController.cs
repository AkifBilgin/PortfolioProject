using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using PortfolioProject.Models;
namespace PortfolioProject.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        PortfolioProjectDbEntities db = new PortfolioProjectDbEntities();
        [HttpGet]
        public ActionResult Index()
        {
		
            return View();
        }
        [HttpPost]
        public ActionResult Index(Users user)
        {


            var result = db.Users.FirstOrDefault(x => x.Username == user.Username && x.PasswordHash == user.PasswordHash);
            if (result != null)
            {
                FormsAuthentication.SetAuthCookie(result.Username, false);
                Session["username"] = result.Username.ToString();
                return RedirectToAction("Index","Statistic");
            }
            
                return View();
        }
    }
}