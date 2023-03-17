namespace Exon.Inferastructure.Responses;

public class LadingReportResponse
{
    public List<ReportLoadedListDTO> Entities { get; set; }
    public int TotalPage { get; set; }
    public int PageIndex { get; set; }
}
