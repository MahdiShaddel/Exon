namespace Exon.Domain.Models;

public class OrderLoadingReport : BaseEntity<int>
{
    public string? orderId { get; set; }
    public string? companyInternalContractCode { get; set; }
    public string? orderGoodDescreption { get; set; }
    public string? orderIssueDate { get; set; }
    public string? orderIssueTime { get; set; }
    public string? receiverCode { get; set; }
    public string? ctName { get; set; }
    public string? receiverName { get; set; }
    public string? truckLicensePlate { get; set; }
    public string? driverFullName { get; set; }
    public string? orderGoodCount { get; set; }
    public string? orderWeight { get; set; }
    public string? billOfLadingID { get; set; }
    public string? billOfLadingDate { get; set; }
    public string? billOfLadingTime { get; set; }
    public string? billOfLadingGoodCount { get; set; }
    public string? billOfLadingWeight { get; set; }
    public string? driverTelephne { get; set; }
    public bool? isArrived { get; set; }
    public string? driverArrivedTime { get; set; }
}
