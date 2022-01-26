using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DateMe.Models
{
    public class DateApplicationContext : DbContext // inheritance
    {
        //Constructor
       public DateApplicationContext(DbContextOptions<DateApplicationContext> options) : base (options)
        {
            //leave blank
        }

        public DbSet<ApplicationResponse> Responses { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<ApplicationResponse>().HasData(
                new ApplicationResponse
                {
                    ApplicationId = 1,
                    FirstName = "Michael",
                    LastName = "Phelps",
                    Age = 32,
                    PhoneNumber = "123-456-7890",
                    Major = "Swimming",
                    Stalker = false
                },
                new ApplicationResponse
                {
                    ApplicationId = 2,
                    FirstName = "Creed",
                    LastName = "Bratton",
                    Age = 90,
                    PhoneNumber = "098-765-4321",
                    Stalker = true
                }
                );
        }

    }
}
