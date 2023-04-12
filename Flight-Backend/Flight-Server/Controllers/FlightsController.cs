using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flight_Logic;
using Flight_Logic.Data;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace Flight_Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FlightsController : ControllerBase
    {
        private readonly List<Plane> _Planes;
        private readonly Simulator _simulator;
        private readonly SimulatorDbcontext simulatorDbcontext;

        public FlightsController(SimulatorDbcontext simulatorDbcontext)
        {
            _Planes = new List<Plane>();
            this.simulatorDbcontext = simulatorDbcontext;
            _simulator = new Simulator(simulatorDbcontext);
        }

        [HttpGet]
        public IActionResult GetAllFlights()
        {
            return Ok(_Planes);
        }

        [HttpPost]
        public IActionResult AddFlight([FromBody] Plane plane)
        {
            _Planes.Add(plane);
            return Ok();
        }

        [HttpPut("{flightNumber}")]
        public IActionResult UpdateFlightSegment(int flightNumber, [FromBody] int segmentNumber)
        {
            var flight = _Planes.FirstOrDefault(f => f.FlightNumber == flightNumber);

            if (flight == null)
            {
                return NotFound();
            }

            flight.CurrentField = segmentNumber;
            return Ok();
        }

        [HttpGet("{type}")]
        public IActionResult GetNextFlightSegment(string type)
        {
            var nextSegment = type == "landing" ? 2 : 6; // next segment based on flight type
            var flight = _Planes.FirstOrDefault(f => f.Type == type && f.CurrentField == nextSegment);

            if (flight == null)
            {
                return NotFound();
            }

            // simulate flight movement to next segment
            flight.CurrentField = nextSegment + 1;

            return Ok(flight);
        }


        [HttpGet("Parking")]
        public IActionResult GetAmountOfParked()
        {
            // Assuming _Planes is a collection of Plane objects
            var parkedPlanes = _Planes.Count(p => p.Type == "landing" && p.CurrentField == 2);

            return Ok(parkedPlanes);
        }


        [HttpPost("RandomAction")]
        public async Task<IActionResult> Simulator_SingleAction()
        {
           string LogResponse = await _simulator.SingleAction();
            JObject jsonObject = new JObject();
            jsonObject.Add("message", LogResponse);
            return Ok(jsonObject.ToString());
            // return Ok(LogResponse);
        }

        // API endpoint to delete all planes
        [HttpDelete("DeleteAllPlanes")]
        public async Task<IActionResult> DeleteAllPlanes()
        {
            // Call the delete all planes method in the simulator service
            string logResponse = await _simulator.DeleteAllPlanes();

            // Return the response as JSON
            JObject jsonObject = new JObject();
            jsonObject.Add("message", logResponse);
            return Ok(jsonObject.ToString());
        }


    }
}
