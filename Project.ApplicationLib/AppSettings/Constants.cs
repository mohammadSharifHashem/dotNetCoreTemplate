using System;

namespace CommonLib.AppSettings
{
    class Constants
    {
        public class Actions
        {
            public const string ADD = "Add";
            public const string EDIT = "Edit";
            public const string DELETE = "Delete";
            public const string LIST = "List";
        }

        // Extensions
        public const string DOCUMENT_EXTENSIONS = "*.pdf;*.doc;*.docx;*.txt";
        public const string IMAGE_EXTENSIONS = "*.jpeg;*.jpg;*.png;*.gif";
        public const string EMAIL_REGEX_VALIDATION = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";
    }
}
