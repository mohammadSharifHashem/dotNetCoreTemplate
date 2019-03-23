using System;
using System.Collections.Generic;

namespace Project.Entity.Models
{
    public partial class ActionLogs
    {
        public long ActionLogId { get; set; }
        public int ActionTypeId { get; set; }
        public int ModuleId { get; set; }
        public long UserId { get; set; }
        public string Data { get; set; }
        public DateTime Date { get; set; }
        public byte Status { get; set; }

        public virtual Modules Module { get; set; }
        public virtual Users User { get; set; }
    }
}
