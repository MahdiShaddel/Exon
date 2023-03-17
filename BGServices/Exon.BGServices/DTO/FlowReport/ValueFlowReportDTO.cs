namespace Exon.BGServices.DTO.FlowReport
{
    public class ValueFlowReportDTO
    {
        public string orderId { get; set; }
        public int companyInternalContractCode { get; set; }
        public string orderGoodDescreption { get; set; }
        public DateTime orderIssueDate { get; set; }
        public TimeSpan orderIssueTime { get; set; }
        public int receiverCode { get; set; }
        public string ctName { get; set; }
        public string receiverName { get; set; }
        public string truckLicensePlate { get; set; }
        public string driverFullName { get; set; }
        public int orderGoodCount { get; set; }
        public int orderWeight { get; set; }
    }
}
