using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CommonLib.AppUtilities
{
    [DataContract]
    public class GList<T>
    {
        [DataMember]
        public List<T> List { get; set; }

        [DataMember]
        public Paging Paging { get; set; }

        public GList()
        {
            List = new List<T>();
            Paging = null;
        }

        public void SetPaging(int pageIndex, int pageSize, int totalCount)
        {
            Paging = new Paging();
            Paging.PageIndex = pageIndex;
            Paging.PageSize = pageSize;
            Paging.TotalCount = totalCount;
        }

    }

    [DataContract]
    public class Paging
    {
        [DataMember]
        public int PageIndex { get; set; }
        [DataMember]
        public int PageSize { get; set; }
        [DataMember]
        public int TotalCount { get; set; }
    }
}
