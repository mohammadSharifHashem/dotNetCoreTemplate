using System;
using System.Collections.Generic;

namespace Project.Entity.Models
{
    public partial class MediaFiles
    {

        public long MediaFileId { get; set; }
        public int? ModuleId { get; set; }
        public string FilePath { get; set; }
        public string FileType { get; set; }
        public byte Status { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public virtual Modules Module { get; set; }
    }
}
