using Exon.Domain.Enums;

namespace Exon.Domain.Models
{
    public class Logs : BaseEntity<int>
    {
        public LogType LogType { get; set; }
        public LogStatus LogStatus { get; set; }
        public string? Message { get; set; }
    }
}
