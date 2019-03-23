using System;
using System.Collections.Generic;

namespace Project.Entity.Models
{
    public partial class Users
    {
        public Users()
        {
            ActionLogs = new HashSet<ActionLogs>();
            AppAccessTokens = new HashSet<AppAccessTokens>();
        }

        public long UserId { get; set; }
        public int UserTypeId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string PasswordSalt { get; set; }
        public DateTime? PasswordExpiryDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool IsVerificationEmailSent { get; set; }
        public string VerificationToken { get; set; }
        public bool Approved { get; set; }
        public long? AddedBy { get; set; }
        public string FacebookUserId { get; set; }
        public string GoogleUserId { get; set; }
        public string TwitterUserId { get; set; }
        public bool PasswordResetRequired { get; set; }
        public bool IsInvited { get; set; }
        public long? IsInvitedBy { get; set; }
        public byte Status { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public virtual UserTypes UserType { get; set; }
        public virtual ICollection<ActionLogs> ActionLogs { get; set; }
        public virtual ICollection<AppAccessTokens> AppAccessTokens { get; set; }
    }
}
