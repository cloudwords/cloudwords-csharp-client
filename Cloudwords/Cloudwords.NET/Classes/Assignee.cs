using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cloudwords.NET.Classes
{
    public class Assignee
    {
        public CustomerUser customerUser { get; set; }

        public Assignee(CustomerUser CustomerUser)
        {
            customerUser = CustomerUser;
        }
    }
}
