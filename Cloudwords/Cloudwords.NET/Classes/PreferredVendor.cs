using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cloudwords.NET.Classes
{
   public  class PreferredVendor
    {
        public string name { get; set; }
        public int id { get; set; }
        public string path { get; set; }
        public PreferredVendor(string Name, int ID, string Path)
        {
            name = Name;
            id = ID;
            path = Path;
        }
        public PreferredVendor( int ID)
        {
            name = "";
            id = ID;
            path = "";
        }
    }
}
