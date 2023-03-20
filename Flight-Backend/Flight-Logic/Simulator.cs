using Newtonsoft.Json;

namespace Flight_Logic
{
    public class Simulator
    {
        private readonly HttpClient _client;

        public Simulator()
        {
            _client = new HttpClient();
        }

        public async Task Start()
        {
            while (true)
            {
                // generate random flight
                var flight = GenerateRandomFlight();

                // send flight to API
                var content = new StringContent(JsonConvert.SerializeObject(flight));
                await _client.PostAsync("https://localhost:7026/api/flights", content);

                // wait for random interval before generating the next flight
                await Task.Delay(new Random().Next(1000, 5000));
            }
        }

        private Flight GenerateRandomFlight()
        {
            var flight = new Flight
            {
                FlightNumber = new Random().Next(100, 1000),
                StartTime = DateTime.UtcNow,
                Type = new Random().Next(2) == 0 ? "Landing" : "Departure",
                CurrentSegment = 1 // starting point
            };

            return flight;
        }
    }
}
