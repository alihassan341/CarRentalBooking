using Humanizer;
using static Humanizer.In;
using static System.Formats.Asn1.AsnWriter;
using System.Configuration;
using System.Net.Mail;

namespace CarRentalBookingSystem.Model
{
    public class EmailSenderOptions
    {
        public string SmtpHost { get; set; }
        public int SmtpPort { get; set; }
        public bool UseSsl { get; set; }
        public string SmtpUsername { get; set; }
        public string SmtpPassword { get; set; }
        public string FromEmail { get; set; }
    }
   
}
