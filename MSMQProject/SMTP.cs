using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Text;

namespace MSMQProject
{
    public class SMTP
    {
        public IConfiguration Configuration;

        public void SendMail(string data)
        {
            try
            {
                var message = new MimeMessage();

                message.From.Add(address: new MailboxAddress("Employee Management", "singhkartikey45@gmail.com"));
              
                message.To.Add(new MailboxAddress("Employee Management", "singhkartikey45@gmail.com"));

                message.Subject = "Registration";

                message.Body = new TextPart("plain")
                {
                    Text = data
                };

                using (var client = new SmtpClient())
                {
                    client.Connect("smtp.gmail.com", 587, false);
                    client.Authenticate("singhkartikey45@gmail.com", "9754286186");
                    client.Send(message);
                    client.Disconnect(true);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
