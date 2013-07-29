using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cloudwords.NET.Classes
{
    public class BidRequest
    {
        public bool doLetCloudwordsChoose { get; set; }
        public List<PreferredVendor> preferredVendors { get; set; }
        public string createdDate { get; set; }
        public bool doAutoSelectBidFromVendor { get; set; }
        public int winningBidId { get; set; }
        public string path { get; set; }
    }
}
