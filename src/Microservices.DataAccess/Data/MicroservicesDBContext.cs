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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                entity.SetTableName(entity.GetTableName()?.ToLower()??string.Empty);
                foreach (var property in entity.GetProperties())
                {
                    property.SetColumnName(property.Name.ToLower());
                }
            }
        }
    }
}
