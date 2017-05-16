using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Domain.VarnishLog;
using Domain.VarnishLog.Queries;
using Infrastructure.Interfaces;
using Infrastructure.Utils;

namespace Application.QueryHandlers
{
    public class VarnishLogQueryHandler :
        IQueryHandler<GetVarnishLogsQuery, string>
    {
        private readonly IRepository<VarnishLog> _varnishLogRepository;

        public VarnishLogQueryHandler(IRepository<VarnishLog> varnishLogRepository)
        {
            _varnishLogRepository = varnishLogRepository;
        }

        public Task<string> Handle(GetVarnishLogsQuery query)
        {
            var logs = _varnishLogRepository.Find(log =>
                (!query.ResponseCode.HasValue || log.ResponseCode.Equals(query.ResponseCode.Value))
                && (string.IsNullOrWhiteSpace(query.FullText) || log.ClientIp.Contains(query.FullText) || log.BrowserType.Contains(query.FullText) || log.Url.Contains(query.FullText) || log.Refferal.Contains(query.FullText))
                && (!query.StartDate.HasValue || log.Date > query.StartDate.Value)
                && (!query.EndDate.HasValue || log.Date < query.EndDate.Value))
                .OrderByWithDirection<VarnishLog, bool>(string.IsNullOrWhiteSpace(query.OrderColumn) ? "Date" : query.OrderColumn, query.SortDescending)
                .Skip(query.StartIndex)
                .Take(query.Length + 1)
                .ToList();

            return (new
            {
                HasMoreData = logs.Count > query.Length,
                Data = logs.Take(query.Length)
            }).ToJsonTask();
        }
    }
}