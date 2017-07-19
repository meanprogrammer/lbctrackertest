using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Service = LBCTracking.Library;

namespace LBCTrackingTest
{
    /// <summary>
    /// Summary description for TrackingHandler
    /// </summary>
    public class TrackingHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";

            string trackingNo = context.Request.QueryString.Get("tno");

            Service.LBCTracking service = new Service.LBCTracking();
            Service.ShipmentLatestStatus status = service.GetLatestStatus(trackingNo);

            string json = JsonConvert.SerializeObject(status);
            context.Response.Write(json);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}