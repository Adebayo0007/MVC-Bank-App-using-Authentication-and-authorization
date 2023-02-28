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

using System.Net.Mail;

namespace MVC_MobileBankApp
 { 
public class Email
{
        public static bool SendMail(string mailfrom, List<string>replytos, List<string> mailtos,
        List<string> mailccs, List<string> mailbccs, string body, string subject, List<string> Attachment,string attach)
 {
    try
        {
           using(MailMessage MyMail = new MailMessage())
            {

                MyMail.From = new MailAddress(mailfrom);
                foreach (string mailto in mailtos)
                MyMail.To.Add(mailto);
                if (replytos != null && replytos.Any())
                {
                    foreach (string replyto in replytos)
                    MyMail.ReplyToList.Add(replyto);
                }

                if (mailccs != null && mailccs.Any())
                {
                    foreach (string mailcc in mailccs)
                    MyMail.CC.Add(mailcc);
                }

                if (mailbccs != null && mailbccs.Any())
                {
                    foreach (string mailbcc in mailbccs)
                    MyMail.Bcc.Add(mailbcc);
                } 

                    MyMail.Subject = subject;
                    MyMail.IsBodyHtml = true;
                    MyMail.Body = body;
                    MyMail.Priority = MailPriority.Normal;

                if (Attachment != null && Attachment.Any())
                {

                    System.Net.Mail.Attachment attachment;
                    foreach (var item in Attachment)
                    {
                        attachment = new System.Net.Mail.Attachment(item);
                        MyMail.Attachments.Add(attachment);
                    }
                }

                SmtpClient smtpMailObj = new SmtpClient();
                smtpMailObj.Host = "localhost";
                smtpMailObj.Port = 3306;
                smtpMailObj.Credentials = new System.Net.NetworkCredential("root", "Adebayo58641999");
                smtpMailObj.Send(MyMail);
                return true;
            }

      


        }
            catch
            {
            return false;
            }

            //adding attachment

          using(MailMessage myMail = new MailMessage())
        {
            Attachment attachment = new Attachment(attach);
            myMail.Attachments.Add(attachment);
           // further processing to send the mail message
        }
  }
}
 }

