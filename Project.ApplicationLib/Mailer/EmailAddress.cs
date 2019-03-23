using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace Project.ApplicationLib.Mailer
{
    public class EmailAddress : MailAddress
    {
        public EmailAddress(string address) : base(address)
        {
        }

        public EmailAddress(string address, string displayName) : base(address, displayName)
        {
        }

        public EmailAddress(string address, string displayName, Encoding displayNameEncoding) : base(address, displayName, displayNameEncoding)
        {
        }
    }
}
