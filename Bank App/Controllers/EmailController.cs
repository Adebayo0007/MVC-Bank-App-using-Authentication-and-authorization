// using Microsoft.AspNetCore.Mvc;
// using MVC_MobileBankApp.Models;
// using System.Collections.Generic;
// using System.Linq;
// using System.Net.Mail;
// using System.Web;
// // using System.Web.Mvc;
// // using System.Web.Helper;
// using MimeKit;

// namespace SendingEmailsFromController.Controllers  
// {  
//     public class HomeController : Controller  
//     {  
//         // GET: Home  
//         public ActionResult SendEmail(string email, string subject, string htmlmessage)  
//         {  
//             var message = new MimeMessage();
//             message.From.Add(MailboxAddress.Parse("tijaniadebayoabdllahi@gmail.com"));
//             message.To.Add(MailboxAddress.Parse(email));
//             message.Subject = "Heading";
//             message.Body  = new TextPart(MimeKit.Text.TextFormat.Html)
//             {
//                 Text = htmlmessage
//             };
           
//             using (var emailClient = new SmtpClient())
//             {
//                 emailClient.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
//                 emailClient.Authenticate("your email", "your password");
//                 emailClient.Send(emailToSend);
//                 emailClient.DisConnect(true);
//             }
             
//             return View();  
//         }  
  


//         [HttpPost]  
//         public ActionResult SendEmail(EmployeeModel obj)
//         {
//             try  
//             {  
//                 //Configuring webMail class to send emails  
//                 //gmail smtp server  
//                 WebMail.SmtpServer = "smtp.gmail.com";   
//                 //gmail port to send emails  
//                 WebMail.SmtpPort = 587;  
//                 WebMail.SmtpUseDefaultCredentials = true;  
//                 //sending emails with secure protocol  
//                 WebMail.EnableSsl = true;   
//                 //EmailId used to send emails from application  
//                 WebMail.UserName = "YourGamilId@gmail.com";  
//                 WebMail.Password = "YourGmailPassword";  
                
//                 //Sender email address.  
//                 WebMail.From = "SenderGamilId@gmail.com";   
//                    //Send email  
//                 WebMail.Send(to: obj.ToEmail, subject: obj.EmailSubject, body: obj.EMailBody, cc: obj.EmailCC, bcc: obj.EmailBCC, isBodyHtml: true);  
//                 ViewBag.Status = "Email Sent Successfully.";  
//       }  
//       catch (Exception)  
//       {  
//                 ViewBag.Status = "Problem while sending email, Please check details.";  
  
//        }  
//             return View();  
//   
//    }


//  }
// }
  

