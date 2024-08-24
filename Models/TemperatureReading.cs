

namespace TemperatureApi.Models
{
    public class Device
    {
        public int DeviceId { get; set; } // Primary key
    }

    public class TemperatureReading
    {
        public int ID { get; set; }
        public float TempValue { get; set; }
        public DateTime Time { get; set; }
        public int DeviceId { get; set; }
    }
}
