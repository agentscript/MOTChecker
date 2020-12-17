using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MOTChecker.Models
{
    public class MotTest
    {
        public DateTime completedDate { get; set; }
        public string testResult { get; set; }
        public DateTime expiryDate { get; set; }
        public string odometerValue { get; set; }
        public string odometerUnit { get; set; }
        public string motTestNumber { get; set; }
        public List<RfrAndComment> rfrAndComments { get; set; }

    }

    public class RfrAndComment
    {
        public string text { get; set; }
        public string type { get; set; }
    }
}