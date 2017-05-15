using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.VarnishLog;
using Domain.VarnishLog.Queries;
using Infrastructure.Interfaces;
using Infrastructure.Utils;

namespace Application.QueryHandlers
{
    public class VarnishLogQueryHandler : IQueryHandler<GetVarnishLogsQuery, string>
    {
        private readonly IRepository<VarnishLog> _varnishLogRepository;

        public VarnishLogQueryHandler(IRepository<VarnishLog> varnishLogRepository)
        {
            _varnishLogRepository = varnishLogRepository;
        }

        public Task<string> Handle(GetVarnishLogsQuery query)
        {
            var logs = _varnishLogRepository.GetAll();

            return logs.ToList().ToJsonTask();
        }
    }
}