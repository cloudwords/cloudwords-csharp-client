using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cloudwords.NET.Classes
{
    public class Follower
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int id { get; set; }
        public Follower()
        {
            firstName="";
            lastName = "";
        }
         public Follower(int ID)
        {
            firstName = "";
            lastName = "";
            id = ID;
        }
         public Follower(string FirstName, string LastName, int ID)
        {
            firstName = FirstName;
            lastName = LastName;
            id = ID;
        }
    }
}
