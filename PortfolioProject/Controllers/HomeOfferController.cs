using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PortfolioProject.Models;

namespace PortfolioProject.Controllers
{
    public class HomeOfferController : Controller
    {
        // GET: HomeOfferController
        PortfolioProjectDbEntities db = new PortfolioProjectDbEntities();
      public PartialViewResult Offer()
		{
            var result = db.Offers.ToList();
            return PartialView(result);
		}
    }
}