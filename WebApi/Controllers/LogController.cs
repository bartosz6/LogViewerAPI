using System;
using System.Threading.Tasks;
using Domain.VarnishLog.Queries;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Utils;

namespace WebApplication.Controllers
{
    [Route("api/logs")]
    [ExceptionHandler]
    public class LogController : Controller
    {
        private readonly IQueryDispatcher _queryDispatcher;
        public LogController(IQueryDispatcher queryDispatcher)
        {
            _queryDispatcher = queryDispatcher;
        }

        [AllowAnonymous]
        [HttpGet("{code?}", Name = "Logs_List")]
        public async Task<object> GetLogs(
            int? code,
            string text,
            DateTime? startDate,
            DateTime? endDate,
            string orderBy,
            bool? desc,
            int? start,
            int? limit
        )
        {
            var result = await _queryDispatcher.Dispatch<GetVarnishLogsQuery, string>(
                new GetVarnishLogsQuery(
                    startIndex: start ?? 0,
                    length: limit ?? 20,
                    startDate: startDate,
                    endDate: endDate,
                    responseCode: code,
                    orderColumn: orderBy,
                    sortDescending: desc ?? true,
                    fullText: text
                )
            );

            return result;
        }
    }
}
