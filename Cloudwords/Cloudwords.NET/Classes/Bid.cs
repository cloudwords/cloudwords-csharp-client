using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cloudwords.NET.Classes
{
    public class Bid
    {
        public List<BidItem> bidItems { get; set; }
        public int id { get; set; }
        public string description { get; set; }
        public Status status { get; set; }
        public double amount { get; set; }
        public string path { get; set; }
    }
}
