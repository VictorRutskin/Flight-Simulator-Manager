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

        public async Task<string> DeleteAllPlanes()
        {
            try
            {
                // Delete all planes from the database
                var planes = await simulatorDbcontext.planes.ToListAsync();
                simulatorDbcontext.planes.RemoveRange(planes);
                await simulatorDbcontext.SaveChangesAsync();

                // Return success message
                return "All planes deleted successfully.";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
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

                    if(logMessage !="No free field to land to, the plane moves to the other close airport.")
                    {
                        await simulatorDbcontext.planes.AddAsync(plane);
                    }
                    await simulatorDbcontext.SaveChangesAsync();


                    return logMessage;
                }
                // Plane in latest lane is flying
                else if (FuncToDo == 2)
                {
                    // delete all planes from db
                    await DeleteAllPlanes();
                    int MaxPlanes = 4;

                    var response = await Airport.PlaneFlies();

                    for (int i = 0; i < MaxPlanes; i++)
                    {
                        if (Airport.Fields[i] != null)
                        {
                            // Reseting id and inputing
                            Plane plane = Airport.Fields[i];
                            plane.PlaneId = 0;
                            simulatorDbcontext.planes.Add(plane);
                        }
                    }

                    await simulatorDbcontext.SaveChangesAsync();


                    return response;

                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return null!;



            // wait for random interval before generating the next flight
        }
    }
}
