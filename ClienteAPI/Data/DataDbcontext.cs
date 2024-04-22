using ClienteAPI.Data.Map;
using ClienteAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace ClienteAPI.Data
{
    public class DataDbcontext : DbContext
    {
        public DataDbcontext(DbContextOptions<DataDbcontext> options) : base(options)
        {
            
        }

        public DbSet<ClienteModel> Cliente { get; set; }
        public DbSet<LogradouroModel> Logradouro { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClienteMap());
            modelBuilder.ApplyConfiguration(new LogradouroMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
