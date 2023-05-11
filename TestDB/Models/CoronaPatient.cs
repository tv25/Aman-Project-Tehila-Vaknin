using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDB.Models
{
    public class CoronaPatient
    {
        public const int MAX_VACCINE_DOSES = 4;
        public int Id
        {
            get; set;
        }
        public DateTime[] VaccineDates { get; set; } = new DateTime[MAX_VACCINE_DOSES];
        public string[] VaccineManufacturers { get; set; } = new string[MAX_VACCINE_DOSES];
        public DateTime PositiveResultDate
        {
            get; set;
        }
        public DateTime RecoveryDate
        {
            get; set;
        }
    }
}
