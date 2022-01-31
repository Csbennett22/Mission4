using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DateMe.Models
{
    public class ApplicationResponse
    {
        [Key]
        [Required]
        public int ApplicationId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte Age { get; set; }
        public string PhoneNumber { get; set; }
        public bool Stalker { get; set; }
        //build a foreign key relationship
        public int MajorId { get; set; }
        public Major Major { get; set; }
    }
}
