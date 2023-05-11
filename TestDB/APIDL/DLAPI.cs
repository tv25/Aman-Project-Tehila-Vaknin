using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDB.Models;

namespace TestDB.APIDL
{
    public interface DLAPI
    {
        #region Patient
        IEnumerable<Models.Patient> GetAllPatient();
        IEnumerable<Models.Patient> GetAllPatientBy(Func<Patient, bool> predicate);
        Models.Patient GetPatient(int id);
        void AddPatient(Models.Patient patient);
        #endregion
        #region CoronaPatient
        IEnumerable<(Models.Patient, Models.CoronaDetails)> GetAllCoronaPatients();
        IEnumerable<(Models.Patient, Models.CoronaDetails)> GetAllCoronaPatientsBy(Predicate<(Models.Patient, Models.CoronaDetails)> predicate);
        void AddCoronaPatient(Models.Patient patient, Models.CoronaDetails coronaDetails);
        #endregion

    }
}
