using System;
using System.Threading.Tasks;
using Domain.VarnishLog.Queries;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    [Route("api/logs")]
    public class LogController : Controller
    {
        private readonly IQueryDispatcher _queryDispatcher;
        public LogController(IQueryDispatcher queryDispatcher)
        {
            _queryDispatcher = queryDispatcher;
        }

        [AllowAnonymous]
        [HttpGet("{code}/{text}", Name = "Logs_List")]
        public async Task<object> GetLogs(
            int code,
            string text,
            DateTime startDate,
            DateTime endDate,
            string orderBy,
            bool desc,
            int start,
            int limit
        )
        {
            var result = await _queryDispatcher.Dispatch<GetVarnishLogsQuery, string>(
                new GetVarnishLogsQuery(
                    startIndex: start,
                    length: limit,
                    startDate: startDate,
                    endDate: endDate,
                    responseCode: code,
                    orderColumn: orderBy,
                    sortDescending: desc,
                    fullText: text
                )
            );

            return result;
        }
    }
}
