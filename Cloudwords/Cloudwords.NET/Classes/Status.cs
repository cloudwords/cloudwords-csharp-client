using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Cloudwords.NET.Classes
{
    public class Status
    {
        public string display { get; set; }
        public string code { get; set; }
        public Status(string Code)
        {
            code = Code;
        }
        public Status(string Display,string Code)
        {
            code = Code;
            display = Display;
        }
    }
}
