using System;
using System.Collections.Generic;

namespace Exon.BGServices.Models;

public partial class OrderLoadingReport
{
    public int Id { get; set; }

    public string OrderId { get; set; }

    public string CompanyInternalContractCode { get; set; }

    public string OrderGoodDescreption { get; set; }

    public string OrderIssueDate { get; set; }

    public string OrderIssueTime { get; set; }

    public string ReceiverCode { get; set; }

    public string CtName { get; set; }

    public string ReceiverName { get; set; }

    public string TruckLicensePlate { get; set; }

    public string DriverFullName { get; set; }

    public string OrderGoodCount { get; set; }

    public string OrderWeight { get; set; }

    public string BillOfLadingId { get; set; }

    public string BillOfLadingDate { get; set; }

    public string BillOfLadingTime { get; set; }

    public string BillOfLadingGoodCount { get; set; }

    public string BillOfLadingWeight { get; set; }

    public string DriverTelephne { get; set; }

    public bool? IsArrived { get; set; }

    public string DriverArrivedTime { get; set; }

    public DateTime CreateDate { get; set; }

    public DateTime ModifedDate { get; set; }
}
