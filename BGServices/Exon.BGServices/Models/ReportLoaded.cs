using System;
using System.Collections.Generic;

namespace Exon.BGServices.Models;

public partial class ReportLoaded
{
    public int Id { get; set; }

    public string billOfLadingID { get; set; } = null!;

    public string companyInternalContractCode { get; set; } = null!;

    public string billOfLadingGoodDescreption { get; set; } = null!;

    public string billOfLadingDate { get; set; } = null!;

    public string billOfLadingTime { get; set; } = null!;

    public string receiverCode { get; set; } = null!;

    public string ctName { get; set; } = null!;

    public string driverFullName { get; set; } = null!;

    public string billOfLadingGoodCount { get; set; } = null!;

    public string billOfLadingWeight { get; set; } = null!;

    public string driverTelephne { get; set; } = null!;

    public string billOfLadingOrderId { get; set; } = null!;

    public string orderIssueDate { get; set; } = null!;

    public string orderIssueTime { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public DateTime ModifedDate { get; set; }
}
