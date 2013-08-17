using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cloudwords.NET.Classes
{
    public class BidItem
    {
        public Language language { get; set; }
        public int id { get; set; }
        public List<BidItemTask> bidItemTasks { get; set; }
        public bool isLanguageRemoved { get; set; }
        public string path { get; set; }
    }
}
