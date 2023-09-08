using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MailKit.Net.Smtp;
using System.Configuration;
using PortfolioProject.Models;
namespace PortfolioProject.Controllers
{
	public class HomeContactController : Controller
	{
		// GET: HomeContact
		PortfolioProjectDbEntities db = new PortfolioProjectDbEntities();
		public ActionResult Index()
		{
			return View();
		}
	


		[HttpPost]
		public ActionResult SendMessage(string name, string email, string telefon, string message, Messages messages)
		{
			var smtpServer = ConfigurationManager.AppSettings["SmtpServer"];
			var smtpPort = int.Parse(ConfigurationManager.AppSettings["SmtpPort"]);
			var smtpUsername = ConfigurationManager.AppSettings["SmtpUsername"];
			var smtpPassword = ConfigurationManager.AppSettings["SmtpPassword"];
			var smtpUsername2 = ConfigurationManager.AppSettings["SmtpUsername2"];
			var messageToSend = new MimeMessage();
			messageToSend.From.Add(new MailboxAddress(" ", smtpUsername));
			messageToSend.To.Add(new MailboxAddress(" ", smtpUsername2));
			messageToSend.Subject = "Neue Kontaktanfrage";
			messageToSend.Body = new TextPart("plain")
			{
				Text = $"Name: {name}\nEmail: {email}\nTelefon: {telefon}\nNachricht: {message}"
			};

			using (var client = new SmtpClient())
			{

				client.Connect(smtpServer, smtpPort, false);
				client.Authenticate(smtpUsername, smtpPassword);
				client.Send(messageToSend);
				client.Disconnect(true);
			}


			db.Messages.Add(messages);
			db.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}