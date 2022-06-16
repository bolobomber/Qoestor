using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Logging;
using Questor.DAL.Interface.Repositories;
using Questor.DAL.Models;
using Questor.Services.Interfaces;
using SmtpClient = System.Net.Mail.SmtpClient;

namespace Questor.Services.Services
{

    public class EmailService : IEmailService
    {
        private readonly IUserRepository userRepository;

        public EmailService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public async Task SendEmailAsync(string email, string subject, string message){
            
            
            MailMessage Mailmassage = new MailMessage();
           // Mailmassage.IsBodyHtml = true;
            Mailmassage.From = new MailAddress("vladyslav.nenchyn@nure.ua", "Questor");
            Mailmassage.To.Add(email);
            Mailmassage.Subject = subject;
            Mailmassage.Body = message;
            using (SmtpClient client = new SmtpClient("smtp.gmail.com"))
            {
                client.Credentials = new NetworkCredential("vladyslav.nenchyn@nure.ua", "09092001Vlados");
                client.Port = 587;
                client.EnableSsl = true;
                client.Send(Mailmassage);
            }
        }
    }
}
