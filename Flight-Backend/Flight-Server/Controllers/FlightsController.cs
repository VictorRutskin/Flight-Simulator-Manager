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
            private readonly List<Flight> _flights;
            private readonly Simulator _simulator;

            public FlightsController()
            {
                _flights = new List<Flight>();
                _simulator = new Simulator();
            }

            [HttpGet]
            public IActionResult GetAllFlights()
            {
                return Ok(_flights);
            }

            [HttpPost]
            public IActionResult AddFlight([FromBody] Flight flight)
            {
                _flights.Add(flight);
                return Ok();
            }

            [HttpPut("{flightNumber}")]
            public IActionResult UpdateFlightSegment(int flightNumber, [FromBody] int segmentNumber)
            {
                var flight = _flights.FirstOrDefault(f => f.FlightNumber == flightNumber);

                if (flight == null)
                {
                    return NotFound();
                }

                flight.CurrentSegment = segmentNumber;
                return Ok();
            }

            [HttpGet("{type}")]
            public IActionResult GetNextFlightSegment(string type)
            {
                var nextSegment = type == "landing" ? 2 : 6; // next segment based on flight type
                var flight = _flights.FirstOrDefault(f => f.Type == type && f.CurrentSegment == nextSegment);

                if (flight == null)
                {
                    return NotFound();
                }

                // simulate flight movement to next segment
                flight.CurrentSegment = nextSegment + 1;

                return Ok(flight);
            }

            [HttpPost("start-simulator")]
            public async Task<IActionResult> StartSimulator()
            {
                await _simulator.Start();
                return Ok();
            }
        }
    }
