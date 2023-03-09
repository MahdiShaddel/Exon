using System;
using System.Collections.Generic;

namespace Exon.BGServices.Models;

public partial class FlowReport
{
    public int Id { get; set; }
    public string orderId { get; set; }
    public string companyInternalContractCode { get; set; }
    public string orderIssueDate { get; set; }
    public string orderIssueTime { get; set; }
    public string receiverCode { get; set; }
    public string ctName { get; set; }
    public string receiverName { get; set; }
    public string truckLicensePlate { get; set; }
    public string driverFullName { get; set; }
    public string orderGoodCount { get; set; }
    public string orderWeight { get; set; }

    public DateTime CreateDate { get; set; }

    public DateTime ModifedDate { get; set; }
}
