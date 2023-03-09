using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exon.Domain.Models
{
    public class ReportLoaded : BaseEntity<int>
    {
        public string billOfLadingID { get; set; }
        public string companyInternalContractCode { get; set; }
        public string billOfLadingGoodDescreption { get; set; }
        public string billOfLadingDate { get; set; }
        public string billOfLadingTime { get; set; }
        public string receiverCode { get; set; }
        public string ctName { get; set; }
        public string driverFullName { get; set; }
        public string billOfLadingGoodCount { get; set; }
        public string billOfLadingWeight { get; set; }
        public string driverTelephne { get; set; }
        public string billOfLadingOrderId { get; set; }
        public string orderIssueDate { get; set; }
        public string orderIssueTime { get; set; }
    }
}
