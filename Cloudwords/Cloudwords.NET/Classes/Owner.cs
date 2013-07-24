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
        public Owner(int ID)
        {
            firstName = "";
            lastName = "";
            id = ID;
        }
        public Owner(string FirstName,string LastName, int ID)
        {
            firstName = FirstName;
            lastName = LastName;
            id = ID;
        }
    }
}
