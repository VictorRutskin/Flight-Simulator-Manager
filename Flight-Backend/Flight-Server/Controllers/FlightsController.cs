using System;
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
        private readonly Simulator _simulator;
        private readonly SimulatorDbcontext simulatorDbcontext;

        public FlightsController(SimulatorDbcontext simulatorDbcontext)
        {
            this.simulatorDbcontext = simulatorDbcontext;
            _simulator = new Simulator(simulatorDbcontext);
        }

        [HttpGet("Parking")]
        public IActionResult GetAmountOfParked()
        {
            try
            {
                var parkedPlanes = simulatorDbcontext.planes.Count();
                return Ok(parkedPlanes);
            }
            catch (Exception ex)
            {
                // Handle the exception and return an error response
                JObject errorObject = new JObject();
                errorObject.Add("error", "Failed to get amount of parked planes");
                errorObject.Add("message", ex.Message);
                return BadRequest(errorObject.ToString());
            }
        }

        [HttpPost("RandomAction")]
        public async Task<IActionResult> Simulator_SingleAction()
        {
            try
            {
                string logResponse = await _simulator.SingleAction();
                JObject jsonObject = new JObject();
                jsonObject.Add("message", logResponse);
                return Ok(jsonObject.ToString());
            }
            catch (Exception ex)
            {
                // Handle the exception and return an error response
                JObject errorObject = new JObject();
                errorObject.Add("error", "Failed to perform random action");
                errorObject.Add("message", ex.Message);
                return BadRequest(errorObject.ToString());
            }
        }

        [HttpDelete("DeleteAllPlanes")]
        public async Task<IActionResult> DeleteAllPlanes()
        {
            try
            {
                string logResponse = await _simulator.DeleteAllPlanes();
                JObject jsonObject = new JObject();
                jsonObject.Add("message", logResponse);
                return Ok(jsonObject.ToString());
            }
            catch (Exception ex)
            {
                // Handle the exception and return an error response
                JObject errorObject = new JObject();
                errorObject.Add("error", "Failed to delete all planes");
                errorObject.Add("message", ex.Message);
                return BadRequest(errorObject.ToString());
            }
        }
    }
}
