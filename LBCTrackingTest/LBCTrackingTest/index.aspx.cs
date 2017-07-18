using LBCTrackingTest.LBCAPI;
using Microsoft.Practices.EnterpriseLibrary.Caching;
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
            ICacheManager cache = CacheFactory.GetCacheManager();

            List<string> trackingNos = cache.GetData("trackingNos") as List<string>;

            string[] trackings = trackingNos.ToArray(); //new string[] { "311216816471", "321128079188", "311216695131", "311216695121", "311216816431" };
            LBCAPI.Service service = new LBCAPI.Service();

            StringBuilder b = new StringBuilder();

            Dictionary<string, ShipmentHistoryEntry> data = new Dictionary<string, ShipmentHistoryEntry>();

          

            foreach (string tracking in trackings)
            {
                shipmenthistory[] sfs = service.trackandtracehistory(tracking);

                List<ShipmentHistoryEntry> tempHistory = new List<ShipmentHistoryEntry>();

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

                    DateTime realDate = DateHelper.MergeDateWithTime(item.DatePosted, item.DatePostedTime);

                    tempHistory.Add(new ShipmentHistoryEntry() { 
                        StatusandLocation = item.StatusandLocation,
                        StatusCode = item.statusCode,
                        StatusMessage = item.statusMessage,
                        SysOrig = int.Parse(item.SysOrig),
                        DatePosted = realDate
                        //DatePostedTime = DateTime.Parse(item.DatePostedTime)                        
                    });
                }

                var query =
                from th in tempHistory
                orderby th.DatePosted descending
                select th;

               data.Add(tracking, query.FirstOrDefault());

            }

            foreach (KeyValuePair<string, ShipmentHistoryEntry> item in data)
            {
                TableRow row = new TableRow();
                row.Cells.Add(new TableCell() { Text = item.Key });
                ShipmentHistoryEntry v = item.Value;
                row.Cells.Add(new TableCell() { Text = v.StatusandLocation });
                row.Cells.Add(new TableCell() { Text = v.StatusMessage });

                this.Table1.Rows.Add(row);
            }

            //Console.ReadLine();
        }

        protected void AddTrackingButton_Click(object sender, EventArgs e)
        {
            ICacheManager cache = CacheFactory.GetCacheManager();

            List<string> trackingNos = cache.GetData("trackingNos") as List<string>;
            if (trackingNos == null)
            {
                trackingNos = new List<string>();
            }
            trackingNos.Add(this.TrackingTextbox.Text.Trim());
            cache.Add("trackingNos", trackingNos);
            this.TrackingTextbox.Text = string.Empty;
        }
    }
}