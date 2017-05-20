using System;
using System.Threading.Tasks;
using Domain.VarnishLog;

namespace Infrastructure.Utils.VarnishLogParser
{
    public abstract class VarnishLogParserCore : IParser<VarnishLog>
    {
        public virtual string ParseIp(string str) => str.Split(' ')[0];
        public virtual DateTime ParseDate(string str) => DateTime.ParseExact(str.Split('[')[1].Split(']')[0], "dd/MMMM/yyyy:HH:mm:ss zz00", System.Globalization.CultureInfo.InvariantCulture);
        public virtual string ParseMethod(string str) => str.Split('"')[1].Split(' ')[0];
        public virtual string ParseUrl(string str) => str.Split('"')[1].Split(' ')[1];
        public virtual string ParseProtocol(string str) => str.Split('"')[1].Split(' ')[2];
        public virtual int ParseResponseCode(string str) => int.Parse(str.Split('"')[2].Split(' ')[1]);
        public virtual long ParseResponseSize(string str) => int.Parse(str.Split('"')[2].Split(' ')[2]);
        public virtual string ParseRefferal(string str) => str.Split('"')[3];
        public virtual string ParseBrowserType(string str) => str.Split('"')[5];

        public virtual VarnishLog Parse(string str)
        {
            return new VarnishLog
            {
                ClientIp = ParseIp(str),
                Date = ParseDate(str),
                Method = ParseMethod(str),
                Url = ParseUrl(str),
                Protocol = ParseProtocol(str),
                ResponseCode = ParseResponseCode(str),
                ResponseSize = ParseResponseSize(str),
                Refferal = ParseRefferal(str),
                BrowserType = ParseBrowserType(str)
            };
        }

        public virtual Task<VarnishLog> ParseAsync(string str)
        {
            throw new NotImplementedException();
        }
    }
}