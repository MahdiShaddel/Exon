namespace Exon.API.DTOs
{
    public class UpdateDTO
    {
        public string orderId { get; set; }
        public bool isArrived { get; set; }
        public string driverArrivedTime { get; set; }
    }
}
