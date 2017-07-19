using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LBCTracking.Library
{
    public class ShipmentLatestStatus
    {
        public DateTime DatePosted { get; set; }
        public string To { get; set; }
        public string ToAddress { get; set; }
        public string StatusandLocation { get; set; }
        public string StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public int SysOrig { get; set; }
    }
}