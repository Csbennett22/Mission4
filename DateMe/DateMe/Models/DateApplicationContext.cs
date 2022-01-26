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

    }
}
