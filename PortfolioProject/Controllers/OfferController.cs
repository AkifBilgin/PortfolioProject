using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PortfolioProject.Models;
namespace PortfolioProject.Controllers
{
    public class OfferController : Controller
    {
        // GET: Offer

        PortfolioProjectDbEntities db = new PortfolioProjectDbEntities();
        [Authorize]
        public ActionResult Index()
        {
            var result = db.Offers.ToList();
            return View(result);
        }
        [HttpGet]
        public ActionResult AddOffer()
		{
            return View();
		}
        [HttpPost]
        public ActionResult AddOffer(Offers offer)
		{
            db.Offers.Add(offer);
            db.SaveChanges();
            return RedirectToAction("Index");
		}

        public ActionResult DeleteOffer(int id)
		{
            var offerToDelete = db.Offers.Find(id);
            db.Offers.Remove(offerToDelete);
            db.SaveChanges();
            return RedirectToAction("Index");
		}

        [HttpGet]
        public ActionResult UpdateOffer(int id)
		{
            var result = db.Offers.Find(id);
            return View(result);
		}

        [HttpPost]
        public ActionResult UpdateOffer(Offers offer)
		{
            var update = db.Offers.Find(offer.ID);
            update.Heading = offer.Heading;
            update.Description = offer.Description;
            update.Icon = offer.Icon;
            db.SaveChanges();
            return RedirectToAction("Index");
		}
    }
}