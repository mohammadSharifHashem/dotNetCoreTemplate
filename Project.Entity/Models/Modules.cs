using System;
using System.Collections.Generic;

namespace Project.Entity.Models
{
    public partial class Modules
    {
        public Modules()
        {
            ActionLogs = new HashSet<ActionLogs>();
            MediaFiles = new HashSet<MediaFiles>();
        }

        public int ModuleId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public byte Status { get; set; }

        public virtual ICollection<ActionLogs> ActionLogs { get; set; }
        public virtual ICollection<MediaFiles> MediaFiles { get; set; }
    }
}
