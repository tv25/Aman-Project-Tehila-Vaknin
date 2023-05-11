using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class Patient
    {
        public int Id { get; set; }
        public int id_Patient
        {
            get; set;
        }
        public string FirstName { get; set; } 
        public string LastName
        {
            get; set;
        }
        public string City
        {
            get; set;
        }
        public string Street
        {
            get; set;
        }
        public int Number_Home
        {
            get; set;
        }
        public DateTime DateOfBirth
        {
            get; set;
        }

        public int? Telephone
        {
            get; set;
        }

        public int? MobilePhone
        {
            get; set;
        }
        public override string ToString()
        {
            string str = id_Patient + " "+ FirstName + " " + LastName+" " + City + " "+" " + Street+" " +" " + Number_Home+" " + DateOfBirth +" " + Telephone+" " + MobilePhone+" ";
            return str;
        }
    }
}
