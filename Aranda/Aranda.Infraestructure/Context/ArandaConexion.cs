using Aranda.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Aranda.Infraestructure.Context
{
    public class ArandaConexion : DbContext
    {
        public ArandaConexion(DbContextOptions options) : base(options) { }
        public ArandaConexion() { }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=LAPTOP-HRQO58R0;Initial Catalog=ArandaDb;Integrated Security=True");
        }

        public DbSet<Catalogue> Catalogue { get; set; }
    }
}
