using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cloudwords.NET.Classes
{
    public class Owner
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int id { get; set; }

        public Owner()
        {
            firstName = "";
            lastName = "";
        }
    }
}
