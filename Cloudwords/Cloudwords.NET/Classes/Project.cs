using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cloudwords.NET.Classes
{
    public class Project
    {
        public string name { get; set; }
        public int id { get; set; }
        public string description { get; set; }
        public Status status { get; set; }
        public SourceLanguage sourceLanguage { get; set; }
        public List<TargetLanguage> targetLanguages { get; set; }
        public string deliveryDueDate { get; set; }
        public string bidDueDate { get; set; }
        public string reviewDueDate { get; set; }
        public string createdDate { get; set; }
        public string notes { get; set; }
        public IntendedUse intendedUse { get; set; }
        public Department department { get; set; }
        public Owner owner { get; set; }
        public string poNumber { get; set; }
        public string bidSelectDeadlineDate { get; set; }
        public double amount { get; set; }
        public List<Follower> followers { get; set; }
        public string path { get; set; }

    }
}
