

namespace Flight_Logic
{
    public class Flight
    {
        public int FlightNumber { get; set; }
        public string Type { get; set; } // landing or takeoff
        public int CurrentSegment { get; set; }
        public DateTime StartTime { get; set; }
    }


}