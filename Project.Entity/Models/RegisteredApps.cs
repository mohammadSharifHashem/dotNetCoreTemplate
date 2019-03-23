using System;
using System.Collections.Generic;

namespace Project.Entity.Models
{
    public partial class RegisteredApps
    {
        public RegisteredApps()
        {
            AppAccessTokens = new HashSet<AppAccessTokens>();
        }

        public string AppId { get; set; }
        public string AppSecret { get; set; }
        public string IosCertificateFile { get; set; }
        public string IosCertificatePassword { get; set; }
        public string AndroidApiKey { get; set; }
        public string FacebookAppId { get; set; }
        public string FacebookAppSecret { get; set; }
        public string GoogleAppId { get; set; }
        public string GoogleAppSecret { get; set; }
        public string GoogleApiKeyIos { get; set; }
        public string GoogleApiKeyAndroid { get; set; }
        public string GoogleApiKeyWeb { get; set; }
        public string IosVersionNumber { get; set; }
        public bool IosIsMandatoryVersionUpdate { get; set; }
        public string AndroidVersionNumber { get; set; }
        public bool AndroidIsMandatoryVersionUpdate { get; set; }
        public bool IsExternal { get; set; }
        public int? AccessTokenExpiryInMins { get; set; }
        public DateTime? IosLowerVersionsExpiryDate { get; set; }
        public DateTime? AndroidLowerVersionsExpiryDate { get; set; }
        public int? VersionExpiryNotifyDays { get; set; }
        public byte Status { get; set; }
        public DateTime AddedDate { get; set; }

        public virtual ICollection<AppAccessTokens> AppAccessTokens { get; set; }
    }
}
