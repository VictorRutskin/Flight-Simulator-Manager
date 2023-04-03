using Newtonsoft.Json;
using System.Numerics;

namespace Flight_Logic
{
    public class Simulator
    {
        private readonly HttpClient _client;

        public Simulator()
        {
            _client = new HttpClient();
        }    

        public async Task<string> SingleAction()
        {
            // Randoming value to check if i add new plane or send one flying away
            Random random = new Random();
            int FuncToDo = random.Next(1, 3);

            // New plane landing
            if (FuncToDo == 1)
            {
                // generate random flight
                Plane plane = new Plane();

                string logMessage = Airport.PlaneLanded(plane);

                //// send flight to API
                //var content = new StringContent(JsonConvert.SerializeObject(plane));
                //await _client.PostAsync("https://localhost:7026/api/flights", content);

                return logMessage;
            }
            // Plane in latest lane is flying
            else if (FuncToDo == 2)
            {
                
                return Airport.PlaneFlies();

            }
            return null;


            // wait for random interval before generating the next flight
        }
    }
}
