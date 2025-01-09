using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using SignalRWebUI.Dtos.MailDtos;

namespace SignalRWebUI.Controllers
{
    public class MailController : Controller
    {
        [HttpGet]
        public IActionResult SendMail()
        {
            return View();
        }


        [HttpPost]
        public IActionResult SendMail(CreateMailDto createMailDto)
        {
            MimeMessage mimeMessage = new MimeMessage();

            MailboxAddress mailboxfrom = new MailboxAddress("SignalR Rezervasyon", "soyaddeneme108@gmail.com");
            mimeMessage.From.Add(mailboxfrom);

            MailboxAddress mailboxAddressTo = new MailboxAddress("User", createMailDto.ReceiverMail);
            mimeMessage.To.Add(mailboxAddressTo);

            var bodybuilder=new BodyBuilder();
            bodybuilder.TextBody=createMailDto.Body;
            mimeMessage.Body=bodybuilder.ToMessageBody();

            mimeMessage.Subject=createMailDto.Subject;

            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 587, false);
            client.Authenticate("soyaddeneme108@gmail.com", "yswkywqnpodrshnj");
            client.Send(mimeMessage);
            client.Disconnect(true);
            client.Dispose();

            return RedirectToAction("Index", "Category");
        }
    }
}
