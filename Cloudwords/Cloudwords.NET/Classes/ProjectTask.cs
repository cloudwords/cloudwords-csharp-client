using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cloudwords.NET.Classes
{
    public class ProjectTask
    {
        public string name { get; set; }
        public string description { get; set; }
        public string type { get; set; }
        public Assignee assignee { get; set; }
        public List<TaskFollower> followers { get; set; }
        public TaskTargetLanguage targetLanguage { get; set; }
        public DateTime? startDate { get; set; }
        public DateTime? dueDate { get; set; }
        public int emailReminderDay { get; set; }
    }
}
