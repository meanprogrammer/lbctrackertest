using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
            context.Response.Write("Hello World");
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