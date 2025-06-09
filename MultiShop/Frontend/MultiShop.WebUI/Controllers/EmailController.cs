using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MultiShop.WebUI.Models;

namespace MultiShop.WebUI.Controllers
{
    public class EmailController : Controller
    {
        [HttpGet]
        public IActionResult SendEmail()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendEmail(EmailRequestViewModel emailRequestViewModel)
        {
            MimeMessage mimeMessage = new MimeMessage();

            MailboxAddress mailboxAddressFrom = new MailboxAddress("MultiShop Owner", "yasinramazanprojegonderici@gmail.com");
            mimeMessage.From.Add(mailboxAddressFrom);

            MailboxAddress mailboxAddressTo = new MailboxAddress("MultiShop User", emailRequestViewModel.ReceiverEmail);
            mimeMessage.To.Add(mailboxAddressTo);

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = emailRequestViewModel.Body;
            mimeMessage.Body = bodyBuilder.ToMessageBody();

            mimeMessage.Subject = emailRequestViewModel.Subject;

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Connect("smtp.gmail.com", 587, false);
            smtpClient.Authenticate("yasinramazanprojegonderici@gmail.com", "axhagscvtzjlpplb");
            smtpClient.Send(mimeMessage);
            smtpClient.Disconnect(true);

            return View();
        }
    }
}
