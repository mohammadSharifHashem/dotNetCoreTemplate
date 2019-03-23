using System;
using System.Collections.Generic;
using System.Text;

namespace Project.ApplicationLib.Mailer
{
    public interface IMailKitService
    {
        void Send(EmailMessage emailMessage);
        void sendAsync(EmailMessage emailMessage);
    }
}
