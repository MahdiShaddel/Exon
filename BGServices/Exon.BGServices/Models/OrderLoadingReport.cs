using System;
using System.Collections.Generic;

namespace Exon.BGServices.Models;

public partial class OrderLoadingReport
{
    public int Id { get; set; }

    public string OrderId { get; set; }
    public int CompanyInternalContractCode { get; set; }
    public string OrderGoodDescreption { get; set; }
    public DateTime OrderIssueDate { get; set; }
    public TimeSpan OrderIssueTime { get; set; }
    public int ReceiverCode { get; set; }
    public string CtName { get; set; }
    public string ReceiverName { get; set; }
    public string TruckLicensePlate { get; set; }
    public string DriverFullName { get; set; }
    public int OrderGoodCount { get; set; }
    public int OrderWeight { get; set; }
    public string BillOfLadingId { get; set; }
    public DateTime BillOfLadingDate { get; set; }
    public TimeSpan BillOfLadingTime { get; set; }
    public int BillOfLadingGoodCount { get; set; }
    public int BillOfLadingWeight { get; set; }
    public string DriverTelephne { get; set; }
    public bool? IsArrived { get; set; }
    public TimeSpan DriverArrivedTime { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime ModifedDate { get; set; }
}
