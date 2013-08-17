using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cloudwords.NET.Classes
{
    public class BidItemTask
    {
        public int id { get; set; }
        public Attributes attributes { get; set; }
        public ProjectTaskType projectTaskType { get; set; }
        public double cost { get; set; }
        public string path { get; set; }
    }
}
