using LBCTracking.Library.LBCService;
using Microsoft.Practices.EnterpriseLibrary.Caching;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LBCTracking.Library
{
    public class LBCTracking : LBCTrackingBase
    {
        ICacheManager cache = CacheFactory.GetCacheManager();
        public LBCTracking()
        {
        }

        ShipmentLatestStatus result = null;

        public ShipmentLatestStatus GetLatestStatus(string trackingNo)
        {
            shipmentFields[] sfs = this.Service.trackandtraceDetails(trackingNo);
            shipmentFields sf = sfs.FirstOrDefault();

            shipmenthistory[] shs = this.Service.trackandtracehistory(trackingNo);

             List<ShipmentHistoryEntry> tempHistory = new List<ShipmentHistoryEntry>();

             foreach (var item in shs)
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

             CacheHelper.AppendToCache(trackingNo, cache);

            return result;
        }
    }
}
