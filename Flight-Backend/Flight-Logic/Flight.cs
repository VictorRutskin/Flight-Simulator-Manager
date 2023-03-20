

namespace Flight_Logic
{
    public class Flight
    {
        public int FlightNumber { get; set; }
        public string? Type { get; set; } // Landing or Departure
        public int PassengersCount { get; set; }
        public int CurrentSegment { get; set; }
        public DateTime StartTime { get; set; }
    }


}