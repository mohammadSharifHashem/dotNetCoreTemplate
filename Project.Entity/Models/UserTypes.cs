using System;
using System.Collections.Generic;

namespace Project.Entity.Models
{
    public partial class UserTypes
    {
        public UserTypes()
        {
            Users = new HashSet<Users>();
        }

        public int UserTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public byte Status { get; set; }

        public virtual ICollection<Users> Users { get; set; }
    }
}
