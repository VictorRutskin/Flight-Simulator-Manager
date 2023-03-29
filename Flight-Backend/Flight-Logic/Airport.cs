using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Flight_Logic
{
    public static class Airport
    {
        public static int MaxPlanes = 4; //max landed planes
        public static Plane[] Fields = new Plane[MaxPlanes]; // if true = empty, else occupied, Fields[0] = Field 8 ... Field[3] = Field 5

        public static int BasicTimer = 2000; // 2 second tick time


        public static void EmptyFields()
        {
            for (int i = 0; i < MaxPlanes; i++)
            {
                Fields[i] = null;
            }
        }

        public static string PlaneLanded(Plane plane)
        {
            bool PlaneLanded = false;

            try
            {
                for (int i = 0; i < MaxPlanes; i++)
                {
                    if (Fields[i] == null)
                    {
                        plane = CalculatePlaneField(plane, i); // calculating new plane field
                        Fields[i] = plane; //plane landed
                        PlaneLanded = true;
                        break;
                    }
                }

                if (PlaneLanded == false)
                {
                    throw new ArgumentException("No free field to land to, the plane moves to the other close airport.");
                }

                return "At "+ plane.LandingTime + ", Flight number " + plane.FlightNumber +" that has "+ plane .PassengersCount+ " passengers has landed safely in field " + plane.CurrentField;
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

        public static string PlaneFlies()
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
                    Fields[PlaneThatShouldFlyIsInField8] = null;

                    for (int i = 0; i < Fields.Length-1; i++)
                    {
                        // advancing all planes
                        if (Fields[i] == null && Fields[i + 1] != null)
                        {
                            Fields[i] = Fields[i + 1];
                            Fields[i + 1] = null;
                        }
                    }
                    DateTime dateTime = DateTime.Now;
                    string NowTime = dateTime.ToString("o");


                    return "At " + NowTime + ", Flight number " + localplane.FlightNumber + " that has " + localplane.PassengersCount + " passengers has departured from field 8.";
                }
                else
                {
                    throw new ArgumentException("There are no planes in the airport.");
                }
            }
            catch (ArgumentException exception)
            {
                return exception.Message;
            }
            catch (Exception exception)
            {
                return "Unknown error.";
            }
        }

        private static Plane CalculatePlaneField(Plane plane, int i)
        {
            int AllFields = 8;
            plane.CurrentField = AllFields - i;

            return plane;
        }

    }
}
