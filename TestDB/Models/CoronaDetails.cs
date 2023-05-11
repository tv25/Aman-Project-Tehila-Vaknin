using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TestDB.Models
{
    public class CoronaDetails
    {
        public int id { get; set; }
        public ICollection<DetailVacsions> dateAndmanufacturer { get; set; } 
        public  DateTime? RecoveryDate{get; set; }
        public DateTime? StartCoronaDate { get; set; }

    }
}
