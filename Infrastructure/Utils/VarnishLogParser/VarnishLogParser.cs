using System;
using System.Threading.Tasks;
using Domain.VarnishLog;

namespace Infrastructure.Utils.VarnishLogParser
{
    public class VarnishLogParser : VarnishLogParserCore, IParser<VarnishLog>
    {
        public override string ParseIp(string str)
        {
            try
            {
                return base.ParseIp(str);
            }
            catch
            {
                throw new ArgumentException($"Error while parsing ClientIp from {str}");
            }
        }
        public override DateTime ParseDate(string str)
        {
            try
            {
                return base.ParseDate(str);
            }
            catch
            {
                throw new ArgumentException($"Error while parsing Date from {str}");
            }
        }
        public override string ParseMethod(string str) 
        {
            try
            {
                return base.ParseMethod(str);
            }
            catch
            {
                throw new ArgumentException($"Error while parsing Method from {str}");
            }
        }
        public override string ParseUrl(string str)
        {
            try
            {
                return base.ParseUrl(str);
            }
            catch
            {
                throw new ArgumentException($"Error while parsing Url from {str}");
            }
        }
        public override string ParseProtocol(string str) 
        {
            try
            {
                return base.ParseProtocol(str);
            }
            catch
            {
                throw new ArgumentException($"Error while parsing Protocol from {str}");
            }
        }
        public override int ParseResponseCode(string str) 
        {
            try
            {
                return base.ParseResponseCode(str);
            }
            catch
            {
                throw new ArgumentException($"Error while parsing ResponseCode from {str}");
            }
        }
        public override long ParseResponseSize(string str) 
        {
            try
            {
                return base.ParseResponseSize(str);
            }
            catch
            {
                throw new ArgumentException($"Error while parsing ResponseSize from {str}");
            }
        }
        public override string ParseRefferal(string str) 
        {
            try
            {
                return base.ParseRefferal(str);
            }
            catch
            {
                throw new ArgumentException($"Error while parsing Refferal from {str}");
            }
        }
        public override string ParseBrowserType(string str) 
        {
            try
            {
                return base.ParseBrowserType(str);
            }
            catch
            {
                throw new ArgumentException($"Error while parsing BrowserType from {str}");
            }
        }
        public override VarnishLog Parse(string str)
        {            
            return base.Parse(str);
        }

        public override Task<VarnishLog> ParseAsync(string str)
        {
            return base.ParseAsync(str);
        }
    }
}