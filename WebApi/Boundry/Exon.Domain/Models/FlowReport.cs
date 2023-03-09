namespace Exon.Domain.Models
{
    public class FlowReport : BaseEntity<int>
    {
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
    }
}
