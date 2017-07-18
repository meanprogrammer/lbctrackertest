using LBCTrackingTest.LBCAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LBCTrackingTest
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string[] trackings = new string[] { "311216816471", "321128079188", "311216695131", "311216695121" };
            LBCAPI.Service service = new LBCAPI.Service();

            StringBuilder b = new StringBuilder();

            foreach (string tracking in trackings)
            {
                shipmentFields[] sfs = service.trackandtraceDetails(tracking);

                foreach (var item in sfs)
                {
                    //Console.WriteLine(string.Format("Tracking #: {0}", item.TrackingNo));
                    b.AppendFormat("Tracking #: {0}", item.TrackingNo);
                    //Console.WriteLine(string.Format("Status: {0}", item.statusMessage));
                    b.AppendFormat("Status: {0}", item.statusMessage);
                }

            }

            this.Literal1.Text = b.ToString();
            //Console.ReadLine();
        }
    }
}