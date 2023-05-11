
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLAPI
{
    public interface IBL
    {
        #region Patient
        IEnumerable<BO.Patient> GetAllPatient();
        IEnumerable<BO.Patient> GetAllPatientBy(int id);
        BO.Patient GetPatient(int id);
        void AddPatient(BO.Patient patient);
        #endregion
        #region CoronaPatient
        IEnumerable<BO.CoronaPatient> GetAllCoronaPatient();
        IEnumerable<BO.CoronaPatient> GetAllCoronaPatientBy(int id);
        BO.CoronaPatient GetCoronaPatient(int id);
        void AddCoronaPatient(BO.CoronaPatient CoronaPatient);
        IEnumerable<DateTime> GetAllPatientVaccineDates(int id);
       List<string> GetAllVaccineManufacturers(int id);
        #endregion
       

    }
}