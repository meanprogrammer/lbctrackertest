using Microsoft.Practices.EnterpriseLibrary.Caching;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LBCTracking.Library
{
    public class CacheHelper
    {
        public static void AppendToCache(string trackingNo, ICacheManager cache) 
        {
            string currentValue = string.Empty;
            if(cache.Contains(Resources.TrackingCacheKey))
            {
                currentValue = cache.GetData(Resources.TrackingCacheKey).ToString();
            }

            if(!currentValue.Contains(trackingNo))
            {
                if (currentValue == string.Empty)
                {
                    currentValue = trackingNo;
                }
                else
                {
                    currentValue = currentValue + "," + trackingNo;
                }
            }
            cache.Add(Resources.TrackingCacheKey, currentValue);
        }

        public static void RemoveFromCache(string trackingNo, ICacheManager cache)
        {
            string currentValue = string.Empty;
            if (cache.Contains(Resources.TrackingCacheKey))
            {
                currentValue = cache.GetData(Resources.TrackingCacheKey).ToString();
            }
        }
    }
}
