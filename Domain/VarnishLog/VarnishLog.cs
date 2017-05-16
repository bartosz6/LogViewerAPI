using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Domain.VarnishLog
{
    public class VarnishLog
    {
        public string BrowserType { get; set; }
        public string ClientIp { get; set; }
        public DateTime Date { get; set; }
        public string Method { get; set; }
        public string Url { get; set; }
        public string Protocol { get; set; }
        public int ResponseCode { get; set; }
        public long ResponseSize { get; set; }
        public string Refferal { get; set; }

        public VarnishLog()
        {
        }
    }
}