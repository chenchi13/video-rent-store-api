using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VideoRentStore.API.Models
{
    public class Director
    {
        public Director()
        {
            Movies = new HashSet<Movie>();
        }

        [Key]
        public int IdDirector { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        [JsonIgnore]
        public ICollection<Movie> Movies { get; set; }
    }
}
