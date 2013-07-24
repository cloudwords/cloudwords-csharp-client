using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cloudwords.NET.Classes
{
    public class TargetLanguage
    {
        public string display { get; set; }
        public string languageCode { get; set; }
        public TargetLanguage()
        {
            display = "";
        }
        public TargetLanguage(string LanguageCode)
        {
            display = "";
            languageCode = LanguageCode;
        }
        public TargetLanguage(string Display,string LanguageCode)
        {
            display = Display;
            languageCode = LanguageCode;
        }
    }
}
