using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net;



namespace CarRentalBookingSystem.Controllers
{
    public class EmailTestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        //public static IActionResult SendEmail()
        //{
        //    // set up the email message
        //    MailMessage message = new MailMessage();
        //    message.From = new MailAddress("arain6320@gmail.com");
        //    message.To.Add("aa7671951@gmail.com");
        //    message.Subject = "Test Email from .NET Core 6";
        //    message.Body = "This is a test email message from .NET Core 6.";

        //    // set up the SMTP client
        //    SmtpClient client = new SmtpClient("smtp.example.com", 587);
        //    client.UseDefaultCredentials = false;
        //    client.Credentials = new NetworkCredential("arain6320@gmail.com", "16240000@@");
        //    client.EnableSsl = true;

        //    // send the email message
        //    try
        //    {
        //        client.Send(message);
        //        Console.WriteLine("Email sent successfully!");

        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Failed to send email. Error message: " + ex.Message);
        //    }
        //    return View();
        //}
    }
}
