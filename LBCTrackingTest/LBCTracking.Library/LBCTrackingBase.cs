using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LBCTracking.Library
{
    public class LBCTrackingBase
    {
        LBCService.Service _service;
        public LBCService.Service Service 
        {
            get {
                if (_service == null)
                { 
                    _service = new LBCService.Service();
                }
                return _service;
            }
        }
    }
}
