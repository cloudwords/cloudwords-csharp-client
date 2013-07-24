using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cloudwords.NET.Classes
{
    public class IntendedUse
    {
        public string name { get; set; }
        public int id { get; set; }
        public IntendedUse()
        {
            name = "";
        }
        public IntendedUse(int ID)
        {
            name = "";
            id = ID;
        }
        public IntendedUse(string Name, int ID)
        {
            name = Name;
            id = ID;
        }

    }
}
