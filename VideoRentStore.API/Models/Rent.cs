using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VideoRentStore.API.Models
{
    public class Rent
    {
        [Key]
        public int IdRent { get; set; }
        public DateTime DateOfRent { get; set; }
        public DateTime DueDate { get; set; }
        public int MovieId { get; set; }
        public int CustomerId { get; set; }

        public Movie Movie { get; set; }
        [JsonIgnore]
        public Customer Customer { get; set; }
    }
}
