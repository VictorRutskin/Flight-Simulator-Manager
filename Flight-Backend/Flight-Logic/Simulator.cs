using Azure;
using Flight_Logic.Data;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Numerics;

namespace Flight_Logic
{
    public class Simulator
    {
        private readonly SimulatorDbcontext simulatorDbcontext;

        public Simulator(SimulatorDbcontext simulatorDbcontext)
        {
            this.simulatorDbcontext = simulatorDbcontext;
        }

        public async Task<string> SingleAction()
        {
            try
            {
                // Randoming value to check if i add new plane or send one flying away
                Random random = new Random();
                int FuncToDo = random.Next(1, 3);

                // New plane landing
                if (FuncToDo == 1)
                {
                    // generate random flight
                    Plane plane = new Plane();

                    string logMessage = Airport.PlaneLanded(ref plane);

                    await simulatorDbcontext.planes.AddAsync(plane);
                    await simulatorDbcontext.SaveChangesAsync();

                    //// send flight to API
                    //var content = new StringContent(JsonConvert.SerializeObject(plane));
                    //await _client.PostAsync("https://localhost:7026/api/flights", content);

                    return logMessage;
                }
                // Plane in latest lane is flying
                else if (FuncToDo == 2)
                {
                    var plane = await simulatorDbcontext.planes.FirstOrDefaultAsync(p => p.CurrentField == 8);

                    if(plane != null)
                    {
                        simulatorDbcontext.planes.Remove(plane);
                        await simulatorDbcontext.SaveChangesAsync();
                    }



                    return await Airport.PlaneFlies();

                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return null;



            // wait for random interval before generating the next flight
        }
    }
}
