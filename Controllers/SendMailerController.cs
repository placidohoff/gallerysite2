using FirstAzureWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;

namespace FirstAzureWebApp.Controllers
{
    public class SendMailerController : Controller
    {
        public ActionResult Index() {  
                return View();  
        }
        
        public ActionResult AfterSend() {
            var result = TempData["isSuccess"];
            return View(result);  
        }  
        public ActionResult SendSuccess() {
            var result = TempData["isSuccess"];
            return View(result);  
        }
        public ActionResult SendFail() {
            var result = TempData["isSuccess"];
            return View(result);  
        }  
        
        [HttpPost]  
        public ActionResult Index(FirstAzureWebApp.Models.MailModel _objModelMail) {  
            if (ModelState.IsValid) {  
                MailMessage mail = new MailMessage();  
                mail.To.Add(_objModelMail.To);  
                mail.From = new MailAddress(_objModelMail.From);  
                mail.Subject = _objModelMail.Subject;  
                string Body = _objModelMail.Body;  
                mail.Body = Body;  
                mail.IsBodyHtml = true;  
                SmtpClient smtp = new SmtpClient();  
                smtp.Host = "smtp.gmail.com";  
                smtp.Port = 587;  
                smtp.UseDefaultCredentials = false;  
                smtp.Credentials = new System.Net.NetworkCredential("sweetflow401@gmail.com", "tvetuhqayfkfiand"); // Enter seders User name and password  
                smtp.EnableSsl = true;
                try
                {
                    smtp.Send(mail);
                    //MailResult result = new MailResult(true);
                    TempData["isSuccess"] = true;
                    return RedirectToAction("SendSuccess", "SendMailer");
                }
                catch(SmtpException e)
                {
                    //throw e;
                    TempData["isSuccess"] = false;
                    return RedirectToAction("SendFail", "SendMailer");

                }
                //finally
                //{
                //    smtp.Dispose();
                //    return 
                //}

                //return View("Index", _objModelMail);
                //return redirecttoaction("index", "home");
                //return RedirectToAction("AfterSend", "SendMailer");
            }
            else {  
                return View();  
            }  
        }  
    }
}
