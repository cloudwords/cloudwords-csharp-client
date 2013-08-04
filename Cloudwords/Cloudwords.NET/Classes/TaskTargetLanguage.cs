using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cloudwords.NET.Classes
{
    public class TaskTargetLanguage
    {
        public string code { get; set; }
        public TaskTargetLanguage(string Code)
        {
            code = Code;
        }
    }
}
