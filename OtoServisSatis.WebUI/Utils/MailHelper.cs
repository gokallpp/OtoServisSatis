using OtoServisSatis.Entities;
using System.Net;
using System.Net.Mail;

namespace OtoServisSatis.WebUI.Utils
{
    public class MailHelper
    {
        public static async Task SendMailAsync(Musteri musteri)
        {
           SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.Credentials = new NetworkCredential("gokalppabdullah@gmail.com", "widfqwpscrfxekhh");
            smtpClient.EnableSsl = true;
            MailMessage message = new MailMessage();
            message.From = new MailAddress("gokalppabdullah@gmail.com");
            message.To.Add("softwaregokalp@gmail.com");
            message.Subject = "Siteden mesaj geldi";
            message.Body = $"Mail Bilgileri <hr/> Ad Soyad : {musteri.Adi} {musteri.Soyadi} <hr/> İlgilendiği Araç Id : {musteri.AracId} <hr/> Email : {musteri.Email} <hr/> Telefon : {musteri.Telefon} <hr/> Notlar : {musteri.Notlar}";
            message.IsBodyHtml = true;
            // smtpClient.Send(message);
            await smtpClient.SendMailAsync(message);
            smtpClient.Dispose();

        }
    }
}
