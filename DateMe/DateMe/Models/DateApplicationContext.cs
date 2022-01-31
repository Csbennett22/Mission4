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
        public DbSet<Major> Majors { get; set; }

        // seeding the data
        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Major>().HasData(
                new Major { MajorId=1, MajorName="Information Systems"},
                new Major { MajorId=2, MajorName= "Ancient Near Eastern Studies: Greek New Testament" },
                new Major { MajorId = 3, MajorName = "Accounting" },
                new Major { MajorId = 4, MajorName = "Spanish" },
                new Major { MajorId = 5, MajorName = "Undeclared" }
                );

            mb.Entity<ApplicationResponse>().HasData(
                new ApplicationResponse
                {
                    ApplicationId = 1,
                    FirstName = "Michael",
                    LastName = "Phelps",
                    Age = 32,
                    PhoneNumber = "123-456-7890",
                    MajorId = 2,
                    Stalker = false
                },
                new ApplicationResponse
                {
                    ApplicationId = 2,
                    FirstName = "Creed",
                    LastName = "Bratton",
                    Age = 90,
                    PhoneNumber = "098-765-4321",
                    MajorId = 5,
                    Stalker = true
                }
                );
        }

    }
}
