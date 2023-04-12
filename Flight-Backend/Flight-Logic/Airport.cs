using Flight_Logic.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Flight_Logic
{
    public class Airport
    {
        private static SimulatorDbcontext? simulatorDbcontext;

        public static void Initialize(SimulatorDbcontext dbContext)
        {
            simulatorDbcontext = dbContext;
        }

        public static int MaxPlanes = 4; // max landed planes
        public static Plane[] Fields = new Plane[MaxPlanes]; // if true = empty, else occupied, Fields[0] = Field 8 ... Field[3] = Field 5

        public static int BasicTimer = 2000; // 2 second tick time

        public static void EmptyFields()
        {
            for (int i = 0; i < MaxPlanes; i++)
            {
                Fields[i] = null!;
            }
        }

        public static string PlaneLanded(ref Plane plane)
        {
            bool planeLanded = false;

            try
            {
                if (Fields[Fields.Length - 1] == null)
                {
                    for (int i = 0; i < MaxPlanes; i++)
                    {
                        if (Fields[i] == null)
                        {
                            plane = CalculatePlaneField(plane, i); // calculating new plane field
                            planeLanded = true;
                            Fields[i] = plane; // plane landed
                            break;

                        }
                    }
                }
                if (!planeLanded)
                {
                    throw new ArgumentException("No free field to land to, the plane moves to the other close airport.");
                }

                return "At " + plane.LandingTime + ", Flight number " + plane.FlightNumber + " that has " + plane.PassengersCount + " passengers has landed safely in field " + plane.CurrentField;
            }
            catch (ArgumentException exception)
            {
                return exception.Message;
            }
            catch (Exception exception)
            {
                return "Unknown Error";
            }
        }


        public async static Task<string> PlaneFlies()
        {
            Plane localplane;
            try
            {
                int PlaneThatShouldFlyIsInField8 = 0;
                if (Fields[PlaneThatShouldFlyIsInField8] != null)
                {
                    // setting type from landing to departure.
                    Fields[PlaneThatShouldFlyIsInField8].Type = "Departure";
                    localplane = Fields[PlaneThatShouldFlyIsInField8];
                    Fields[PlaneThatShouldFlyIsInField8] = null!;

                    for (int i = 0; i < Fields.Length - 1; i++)
                    {
                        // advancing all planes
                        if (Fields[i] == null && Fields[i + 1] != null)
                        {
                            Plane planeToUpdate = Fields[i + 1];
                            planeToUpdate.CurrentField++;
                            Fields[i + 1] = planeToUpdate;
                            Fields[i] = Fields[i + 1];
                            Fields[i + 1] = null!;
                        }
                    }
                    DateTime dateTime = DateTime.Now;
                    string NowTime = dateTime.ToString("o");

                    return "At " + NowTime + ", Flight number " + localplane.FlightNumber + " with " + localplane.PassengersCount + " passengers has departed safely from field " + localplane.CurrentField;
                }
                else
                {
                    throw new ArgumentException("No plane available for departure at this time.");
                }
            }
            catch (ArgumentException exception)
            {
                return exception.Message;
            }
            catch (Exception exception)
            {
                return "Unknown Error";
            }
        }



        public static Plane CalculatePlaneField(Plane plane, int index)
        {
            int firstField = 8;

            // Calculate new field based on current field and index
            int newField = firstField - index;
            plane.CurrentField = newField;
            return plane;
        }

    }
}
