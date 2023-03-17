namespace Exon.BGServices.DTO.ReportLoaded
{
    public class ValueReportLoadedDTO
    {
        public string billOfLadingID { get; set; }
        public int companyInternalContractCode { get; set; }
        public string billOfLadingGoodDescreption { get; set; }
        public string billOfLadingDate { get; set; }
        public TimeSpan billOfLadingTime { get; set; }
        public int receiverCode { get; set; }
        public string ctName { get; set; }
        public string receiverName { get; set; }
        public string truckLicensePlate { get; set; }
        public string driverFullName { get; set; }
        public int billOfLadingGoodCount { get; set; }
        public int billOfLadingWeight { get; set; }
        public string driverTelephne { get; set; }
        public string billOfLadingOrderId { get; set; }
        public DateTime orderIssueDate { get; set; }
        public TimeSpan orderIssueTime { get; set; }
    }
}
