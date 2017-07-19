using LBCTracking.Library.LBCService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LBCTracking.Library
{
    public class LBCTracking : LBCTrackingBase
    {

        bool isBusy = false;
        public LBCTracking()
        {
            this.Service.trackandtraceDetailsCompleted += TrackAndDetailsCompleted;
            this.Service.trackandtracehistoryCompleted +=Service_trackandtracehistoryCompleted;
        }

        ShipmentLatestStatus result = null;

        public ShipmentLatestStatus GetLatestStatus(string trackingNo)
        {
            while (isBusy) { }
            isBusy = true;
            this.Service.trackandtraceDetailsAsync(trackingNo, trackingNo);
            while (isBusy) { }
            return result;
        }

        public void TrackAndDetailsCompleted(object sender, trackandtraceDetailsCompletedEventArgs e)
        {
            shipmentFields details = e.Result.FirstOrDefault();
            this.Service.trackandtracehistoryAsync(e.UserState.ToString(), details);
        }

        private void Service_trackandtracehistoryCompleted(object sender, trackandtracehistoryCompletedEventArgs e)
        {
            shipmentFields sf = e.UserState as shipmentFields;

            List<ShipmentHistoryEntry> tempHistory = new List<ShipmentHistoryEntry>();

            foreach (var item in e.Result)
            {
                DateTime realDate = DateHelper.MergeDateWithTime(item.DatePosted, item.DatePostedTime);

                tempHistory.Add(new ShipmentHistoryEntry()
                {
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

            ShipmentLatestStatus latest = new ShipmentLatestStatus();
            latest.DatePosted = query.FirstOrDefault().DatePosted;
            latest.To = sf.ConsigneeName;
            latest.ToAddress = sf.ConsigneeAddress;
            latest.StatusandLocation = query.FirstOrDefault().StatusandLocation;
            latest.StatusCode = query.FirstOrDefault().StatusCode;
            latest.StatusMessage = query.FirstOrDefault().StatusMessage;

            result = latest;

            isBusy = false;
        }
    }
}
