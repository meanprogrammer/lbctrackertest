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
            string[] trackings = new string[] { "311216816471", "321128079188", "311216695131", "311216695121", "311216816431" };
            LBCAPI.Service service = new LBCAPI.Service();

            StringBuilder b = new StringBuilder();

            foreach (string tracking in trackings)
            {
                shipmenthistory[] sfs = service.trackandtracehistory(tracking);

                foreach (var item in sfs)
                {
                    /*
                    b.AppendFormat("Tracking #: {0} {1}", item.TrackingNo, Environment.NewLine);
                    b.AppendFormat("Status: {0} {1}", item.statusMessage, Environment.NewLine);
                    b.AppendFormat("Status code: {0} {1}", item.statusCode, Environment.NewLine);
                     */

                    b.AppendFormat("Date Posted #: {0} {1}", item.DatePosted, Environment.NewLine);
                    b.AppendFormat("Date Posted Time: {0} {1}", item.DatePostedTime, Environment.NewLine);
                    b.AppendFormat("Status and Location: {0} {1}", item.StatusandLocation, Environment.NewLine);
                    b.AppendFormat("Status code: {0} {1}", item.statusCode, Environment.NewLine);
                    b.AppendFormat("Status Message: {0} {1}", item.statusMessage, Environment.NewLine);
                    b.AppendFormat("SysOrig: {0} {1}", item.SysOrig, Environment.NewLine);
                }

            }

            this.Literal1.Text = b.ToString();
            this.TextBox1.Text = b.ToString();
            //Console.ReadLine();
        }
    }
}