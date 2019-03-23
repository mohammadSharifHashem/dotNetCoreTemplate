using System;
using System.Collections.Generic;

namespace Project.Entity.Models
{
    public partial class AppAccessTokens
    {
        public string Token { get; set; }
        public long UserId { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public string AppId { get; set; }
        public string DeviceToken { get; set; }
        public string AppVersion { get; set; }
        public string DevicePlatform { get; set; }
        public string PlatformVersion { get; set; }
        public string DeviceType { get; set; }
        public string DeviceId { get; set; }
        public string IpAddress { get; set; }
        public bool AllowNotifications { get; set; }
        public byte Status { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public virtual RegisteredApps App { get; set; }
        public virtual Users User { get; set; }
    }
}
