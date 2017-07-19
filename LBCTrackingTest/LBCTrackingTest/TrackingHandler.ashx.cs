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
            context.Response.ContentType = "text/plain";

            string trackingNo = context.Request.QueryString.Get("tno");

            Service.LBCTracking service = new Service.LBCTracking();
            service.GetLatestStatus(trackingNo);
            //context.Response.Write("Hello World");
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