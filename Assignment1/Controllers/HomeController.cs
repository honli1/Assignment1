using Assignment1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Assignment1.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {

            return View();
        }
        public ActionResult Send()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Contact(SendEmailModel model)
        {
            if (ModelState.IsValid)
            {
                var body = "<p>Email From: {0} ({1}) </p><p>Message:</P><p>{2}</p>";
                var message = new MailMessage();
                message.To.Add(new MailAddress("hlii0069@student.monash.edu"));
                message.From = new MailAddress("hlii0069@student.monash.edu");
                message.Subject = "Your email subject";
                message.Body = string.Format(body, model.Fromname, model.FromEmail, model.Message);
                message.IsBodyHtml = true;


                using (var smtp = new SmtpClient())
                {
                    smtp.Host = "smtp.monash.edu.au";
                    await smtp.SendMailAsync(message);
                    return RedirectToAction("Send");
                }


            }
            
            return View();
        }
    }
}