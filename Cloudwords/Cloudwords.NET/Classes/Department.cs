using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cloudwords.NET.Classes
{
    public class Department
    {
        public string name { get; set; }
        public int id { get; set; }
        public Department()
        {
            name = "";
        }
        public Department(int ID)
        {
            name = "";
            id = ID;
        }
        public Department(string Name,int ID)
        {
            name = Name;
            id = ID;
        }
    }
}
