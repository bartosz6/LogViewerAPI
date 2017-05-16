using System;

namespace Domain.VarnishLog.Queries
{
    public class GetVarnishLogsQuery : IQuery<string>
    {
        public int StartIndex { get; }
        public int Length { get; }
        public string OrderColumn { get; }
        public bool SortDescending { get; }

        public DateTime? StartDate { get; }
        public DateTime? EndDate { get; }
        public int? ResponseCode { get; }
        public string FullText { get; }


        public GetVarnishLogsQuery(int startIndex, int length, DateTime? startDate, DateTime? endDate, int? responseCode, string orderColumn, bool sortDescending, string fullText)
        {
            this.StartIndex = startIndex;
            this.Length = length;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.ResponseCode = responseCode;
            this.OrderColumn = orderColumn;
            this.SortDescending = sortDescending;
            this.FullText = fullText;

        }
    }
}