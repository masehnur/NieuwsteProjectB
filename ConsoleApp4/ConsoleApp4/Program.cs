using FluentEmail.Core;
using FluentEmail.Razor;
using FluentEmail.Smtp;
using System;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var sender = new SmtpSender(() => new SmtpClient("localhost")
            {
                EnableSsl = false,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Port = 25
                //DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory,
                //PickupDirectoryLocation = @"C:\Demos"
            });

            StringBuilder template = new();
            template.AppendLine("Beste @Model.FirstName,");
            template.AppendLine("<p>Bedankt voor uw reservering! We hopen u snel te zien!</p>");
            template.AppendLine("- Team INF1A");
            

            Email.DefaultSender = sender;
            Email.DefaultRenderer = new RazorRenderer();

            var email = await Email
                .From("maseh@maseh.com")
                .To("test@test.com")
                .Subject("Uw reservering")
                .UsingTemplate(template.ToString(), new { FirstName = "Maseh"})
                //.Body("Bedankt voor uw reservering! We zien uw spoedig.\n Groetjes, Restaurant INF1A")
                .SendAsync();
        
        }
    }
}
