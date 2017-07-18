using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LBCTrackingTest
{
    public class ShipmentHistoryEntry
    {
        public DateTime DatePosted { get; set; }
        public string StatusandLocation { get; set; }
        public string StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public int SysOrig { get; set; }
    }
}