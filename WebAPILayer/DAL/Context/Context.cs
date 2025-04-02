using Microsoft.EntityFrameworkCore;
using WebAPILayer.DAL.Entities;

namespace WebAPILayer.DAL.Context
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=WebAPI;Trusted_Connection=True;");
        }

        public DbSet<Category> Categories { get; set; }
    }
}
