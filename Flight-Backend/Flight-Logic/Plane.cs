

namespace Flight_Logic
{
    public class Plane
    {

        public Plane(long flightNumber, string? type, int passengersCount, int currentField)
        {
            FlightNumber = flightNumber;
            Type = type;
            PassengersCount = passengersCount;
            CurrentField = currentField;

            DateTime dateTime = DateTime.Now;
            LandingTime = dateTime.ToString("o");

        }
        public Plane()
        {
            Random random = new Random();

            // Generate a random flight number between 1000 and 9999
            byte[] buffer = new byte[8];
            random.NextBytes(buffer);
            long longValue = BitConverter.ToInt64(buffer, 0);
            FlightNumber = (long)Math.Abs(longValue % (9999999999999999L - 1000000000000000L + 1)) + 1000000000000000L;

            // Generate a random type, either "Landing" or "Departure"
            Type ="Landing";

            // Generate a random passenger count between 0 and 500
            PassengersCount = random.Next(501);

            // Generate a random current segment between 1 and 9
            CurrentField = random.Next(1, 10);

            DateTime dateTime = DateTime.Now;
            LandingTime = dateTime.ToString("o");


        }

        private long _flightNumber;
        public long FlightNumber
        {
            get => _flightNumber;
            set
            {
                if (value < 1000000000000000 || value > 9999999999999999)
                {
                    throw new ArgumentException("Flight number must be between 1000 and 9999.");
                }
                _flightNumber = value;
            }
        }

        private string? _type;
        public string? Type
        {
            get => _type;
            set
            {
                if (value != "Landing" && value != "Departure")
                {
                    throw new ArgumentException("Type must be either 'Landing' or 'Departure'.");
                }
                _type = value;
            }
        }

        private int _passengersCount;
        public int PassengersCount
        {
            get => _passengersCount;
            set
            {
                if (value < 0 || value > 500)
                {
                    throw new ArgumentException("Passenger count must be between 0 and 500.");
                }
                _passengersCount = value;
            }
        }

        private int _currentField;
        public int CurrentField
        {
            get => _currentField;
            set
            {
                if (value < 1 || value > 9)
                {
                    throw new ArgumentException("Current segment must be between 1 and 9.");
                }
                _currentField = value;
            }
        }
        public string LandingTime { get; set; }

     
    }
}