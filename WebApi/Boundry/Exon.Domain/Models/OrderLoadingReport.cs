namespace Exon.Domain.Models;

public class OrderLoadingReport : BaseEntity<int>
{
    public string? orderId { get; set; }
    public int? companyInternalContractCode { get; set; }
    public string? orderGoodDescreption { get; set; }
    public DateTime? orderIssueDate { get; set; }
    public TimeSpan? orderIssueTime { get; set; }
    public int? receiverCode { get; set; }
    public string? ctName { get; set; }
    public string? receiverName { get; set; }
    public string? truckLicensePlate { get; set; }
    public string? driverFullName { get; set; }
    public int? orderGoodCount { get; set; }
    public int? orderWeight { get; set; }
    public string? billOfLadingID { get; set; }
    public DateTime? billOfLadingDate { get; set; }
    public TimeSpan? billOfLadingTime { get; set; }
    public int? billOfLadingGoodCount { get; set; }
    public int? billOfLadingWeight { get; set; }
    public string? driverTelephne { get; set; }
    public bool? isArrived { get; set; }
    public TimeSpan? driverArrivedTime { get; set; }
}
