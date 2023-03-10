using Exon.Domain.Models;

namespace Exon.API.Responses;

public class ReportResponse
{
    public List<OrderLoadingReport> Entities { get; set; }
    public int TotalPage { get; set; }
    public int PageIndex { get; set; }
}
