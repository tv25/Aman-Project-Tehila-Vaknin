using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDB.Models
{
    public class Patient
    {
        [Key] public int Id { get; set; }
        public int id_Patient { get; set; }
        public string FirstName { get; set; } = null!;  
        public string? LastName { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }
        public int? Number_Home { get; set; }
        public DateTime DateOfBirth{ get; set; }

        public int? Telephone {get; set; }

        public int? MobilePhone { get; set; }

        public CoronaDetails? CoronaDetails { get; set; }   




    }
}
