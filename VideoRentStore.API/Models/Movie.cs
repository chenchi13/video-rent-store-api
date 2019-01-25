using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VideoRentStore.API.Models
{
    public class Movie
    {
        public Movie()
        {
            Rents = new HashSet<Rent>();
        }

        [Key]
        public int IdMovie { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }

        public int GenreId { get; set; }
        public int DirectorId { get; set; }

        public virtual Director Director { get; set; }

        public virtual Genre Genre { get; set; }

        [JsonIgnore]
        public ICollection<Rent> Rents { get; set; }
    }
}
