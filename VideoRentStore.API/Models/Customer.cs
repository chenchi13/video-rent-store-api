using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VideoRentStore.API.Models
{
    public class Customer
    {
        public Customer()
        {
            Rents = new HashSet<Rent>();
        }

        [Key]
        public int IdCustomer { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        //[JsonIgnore]
        public ICollection<Rent> Rents { get; set; }
    }
}
