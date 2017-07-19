using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service = LBCTracking.Library;

namespace LibTester
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] trackings = new string[] { "311216816471", "321128079188", "311216695131", "311216695121" };  

            //LBCTracking trackingService = new 
            Service.LBCTracking service = new Service.LBCTracking();
            var result = service.GetLatestStatus("311216816471");

            Console.ReadLine();
        }
    }
}
