using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VideoRentStore.API.Models
{
    public class Genre
    {
        public Genre()
        {
            Movies = new HashSet<Movie>();
        }

        [Key]
        public int IdGenre { get; set; }
        public string Name { get; set; }

        [JsonIgnore]
        public ICollection<Movie> Movies { get; set; }
    }
}
