using BugTracker.Domain.Interface.Service;
using BugTracker.Domain.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Interface.Presentation.Services
{
    public static class MailServiceInjection
    {
        public static IMailService Create()
        {
            return new MailService();
        }
    }
}