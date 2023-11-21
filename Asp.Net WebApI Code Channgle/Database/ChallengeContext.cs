using Asp.Net_WebApI_Code_Channgle.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;

namespace Asp.Net_WebApI_Code_Channgle.Database
{
    public class ChallengeContext :DbContext
    {


        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        
        private readonly IConfiguration configuration;

        public ChallengeContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
              

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(configuration["ConnectionString"]);
            base.OnConfiguring(optionsBuilder);
        }



    }
}

