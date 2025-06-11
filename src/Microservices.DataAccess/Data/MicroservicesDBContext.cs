using Microservices.DataAccess.Models;
using Microsoft.EntityFrameworkCore;


namespace Microservices.DataAccess.Data
{
    public class MicroservicesDBContext : DbContext
    {
        public MicroservicesDBContext(DbContextOptions<MicroservicesDBContext> options)
        : base(options)
        {
        }

        public DbSet<Log> Logs { get; set; }
    }
}
