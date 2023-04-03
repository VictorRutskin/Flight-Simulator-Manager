using Microsoft.EntityFrameworkCore;

namespace Flight_Logic.Data
{
    public class SimulatorDbcontext : DbContext
    {
        public SimulatorDbcontext()
        {
        }

        public SimulatorDbcontext(DbContextOptions options): base(options)
        {
        }

        public DbSet<Plane> planes { get; set; }
    }
}
