using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flight_Logic;
using Microsoft.AspNetCore.Mvc;

namespace Flight_Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FlightsController : ControllerBase
    {
        private readonly List<Plane> _Planes;
        private readonly Simulator _simulator;

        public FlightsController()
        {
            _Planes = new List<Plane>();
            _simulator = new Simulator();
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

        [HttpPost("start-simulator")]
        public async Task<IActionResult> StartSimulator()
        {
            await _simulator.Start();
            return Ok();
        }

        [HttpPost("RandomAction")]
        public async Task<IActionResult> Simulator_SingleAction()
        {
           string LogResponse = await _simulator.SingleAction();
            return Ok(LogResponse);
        }


    }
}
