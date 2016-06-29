using BugTracker.Domain.Entity;
using BugTracker.Domain.Interface.Service;
using Interface.Presentation.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Interface.Presentation.Mail_Body
{
    public static class UserActivation
    {
        private static MailService mail = new MailService();

        private static IActivationService activationService = ActivationServiceInjection.Create();

        public static void SendTo(User user)
        {
            activationService.Add(new BugTracker.Domain.Entity.Activation(SendTo(user.Email),user.IDUser, user));
        }

        private static string SendTo(string mailTo)
        {
            string code = Guid.NewGuid().ToString();

            string body =
                "<div>" +
                    "<div style=\"width: 85%;text-align: center;margin: 0 auto;background-color: #d4d8b4;\">" +
                        "<div style=\"background-image:url('http://localhost:58173/Content/Images/WebSite/logo-m.png');width: 170px;height: 231px;background-position: center;background-repeat: no-repeat;display:inline-block;margin-bottom:50px;\"></div>" +
                            "<div style=\"background-image:url('http://localhost:58173/Content/Images/WebSite/banner.png');height: 230px;width: 850px;background-position: center;background-repeat: no-repeat;display:inline-block;margin-bottom:50px;\"></div>" +
                    "<h1 style=\"color: #005f2b;\">ACTIVATE YOUR BUGTRACKER ACCOUNT</h1>" +
                    "<p><a href=\"http://localhost:58173/activated?code=" + code + " \">Click here</a> to verify your email address</p>" +
                    "<footer style=\"background-color: #200303;width: 100%;margin-top: 20px;padding: 15px 0;\">" +
                      "<p style=\"color: #d4d8b4;\">BugTracker LTDA.   21554 N. Northsight Blvd.  Suite 205  Scottsdale,  AZ   85260   Brazil</p>" +
                    "</footer>" +
                  "</div>" +
                "</div>";

            mail.Send(mailTo, "Activation of BugTracker account", body, true);

            return code;
        }
    }
}