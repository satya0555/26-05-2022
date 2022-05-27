using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using API.Entities;

namespace API.Data
{
    public class StoreContext:DbContext
    {  
    public StoreContext()
        {
              
        } 
        public StoreContext(DbContextOptions<StoreContext> options) :base(options)
        {
              
        }
        public DbSet<AppUser> Users{get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlite(connectionString);
    }

}
}