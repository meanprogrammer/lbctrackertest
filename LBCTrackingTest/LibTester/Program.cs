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
            foreach (string tr in trackings)
            {
                var result = service.GetLatestStatus(tr);
                Console.WriteLine(result.StatusandLocation);
            }
            
            

            Console.ReadLine();
        }
    }
}
