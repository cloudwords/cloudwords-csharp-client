using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cloudwords.NET.Classes
{
    public class TaskFollower
    {
        public CustomerUser customerUser { get; set; }
        public Vendor vendor { get; set; }

        public TaskFollower(CustomerUser CustomerUser, Vendor Vendor)
        {
            customerUser = CustomerUser;
            vendor = Vendor;
        }
    }
}
