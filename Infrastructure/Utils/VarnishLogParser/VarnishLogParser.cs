using System;
using System.Threading.Tasks;
using Domain.VarnishLog;

namespace Infrastructure.Utils.VarnishLogParser
{
    public class VarnishLogParser : IParser<VarnishLog>
    {
        public VarnishLog Parse(string str)
        {
            var ip = str.Split(' ')[0];
            var date = DateTime.ParseExact(str.Split('[')[1].Split(']')[0], "dd/MMMM/yyyy:HH:mm:ss zz00", System.Globalization.CultureInfo.InvariantCulture);
            var method = str.Split('"')[1].Split(' ')[0];
            var url = str.Split('"')[1].Split(' ')[1];
            var protocol = str.Split('"')[1].Split(' ')[2];
            var responseCode = int.Parse(str.Split('"')[2].Split(' ')[1]);
            var responseSize = int.Parse(str.Split('"')[2].Split(' ')[2]);
            var refferal = str.Split('"')[3];
            var browserType = str.Split('"')[5];

            return new VarnishLog
            {
                ClientIp = ip,
                Date = date,
                Method = method,
                Url = url,
                Protocol = protocol,
                ResponseCode = responseCode,
                ResponseSize = responseSize,
                Refferal = refferal,
                BrowserType = browserType
            };
        }

        public Task<VarnishLog> ParseAsync(string str)
        {
            throw new NotImplementedException();
        }
    }
}