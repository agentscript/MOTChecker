using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Profile;

namespace MOTChecker.Models
{
    public class Vehicle
    {
        public Vehicle()
        {
            
        }
        public string registration { get; set; }
        public string make { get; set; }
        public string model { get; set; }
        public string firstUsedDate { get; set; }
        public string fuelType { get; set; }
        public string primaryColour { get; set; }
        public List<MotTest> motTests { get; set; }
    }
}