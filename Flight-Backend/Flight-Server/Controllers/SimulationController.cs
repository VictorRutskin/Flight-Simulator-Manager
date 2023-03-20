using Microsoft.AspNetCore.Mvc;

namespace Flight_Server.Controllers
{
    public class SimulationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
