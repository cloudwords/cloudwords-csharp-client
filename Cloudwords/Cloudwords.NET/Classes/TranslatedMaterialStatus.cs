using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cloudwords.NET.Classes
{
    class TranslatedMaterialStatus
    {
        public Status status { get; set; }
        public TranslatedMaterialStatus(Status st)
        {
            status = st;
        }
    }
}
