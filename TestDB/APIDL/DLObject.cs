using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TestDB.DATA;
using TestDB.Models;

namespace TestDB.APIDL
{
    public sealed class DLObject : DLAPI   

    {
         
        private static readonly Data _context = new Data();

        #region singelton
        static readonly DLObject instance = new DLObject();
        static DLObject()
        {
        }// static ctor to ensure instance init is done just before first usage
        DLObject()
        {
        } // default => private
        public static DLObject Instance
        {
            get => instance;
        }// The public Instance property to use
        #endregion
        #region coronapatient

        public IEnumerable<Patient> GetAllPatient()
        {
            var list = _context.Patients
            .Include(p => p.CoronaDetails)
            .ThenInclude(cd => cd.dateAndmanufacturer)
            .ToList();
            return list;
        }

        public IEnumerable<Patient> GetAllPatientBy(Func<Patient, bool> predicate)
        {
            return GetAllPatient().Where(predicate);
        }

        public Patient GetPatient(int id)
        {
            return _context.Patients.Include(p => p.CoronaDetails).ThenInclude(cd => cd.dateAndmanufacturer).FirstOrDefault(p => p.id_Patient == id);
        }

        public void AddPatient(Patient patient)
        {
            if (_context.Patients.Any(p => p.id_Patient == patient.id_Patient))
            {
                throw new Exception("Is exist");
            }

            patient.Id = default;
            _context.Patients.Add(patient);
            _context.SaveChanges();
        }

        public IEnumerable<(Patient, CoronaDetails)> GetAllCoronaPatients()
        {
            return _context.Patients
                .Include(p => p.CoronaDetails)
                .ThenInclude(cd => cd.dateAndmanufacturer)
                .Where(p => p.CoronaDetails != null)
                .Select(p => new { Patient = p, CoronaDetails = p.CoronaDetails! })
                .AsEnumerable()
                .Select(x => (x.Patient, x.CoronaDetails));
        }

        public IEnumerable<(Patient, CoronaDetails)> GetAllCoronaPatientsBy(Predicate<(Patient, CoronaDetails)> predicate)
        {
            return _context.Patients
                .Include(p => p.CoronaDetails)
                .ThenInclude(cd => cd.dateAndmanufacturer)
                .Where(p => p.CoronaDetails != null)
                .Select(p => new { Patient = p, CoronaDetails = p.CoronaDetails! })
                .AsEnumerable()
                .Select(x => (x.Patient, x.CoronaDetails))
                .Where(pair => predicate(pair));
        }

        public (Patient, CoronaDetails) GetCoronaPatient(int id)
        {
            var patient = _context.Patients.Include(p => p.CoronaDetails).ThenInclude(cd => cd.dateAndmanufacturer).FirstOrDefault(p => p.Id == id);
            if (patient?.CoronaDetails != null)
            {
                return (patient, patient.CoronaDetails);
            }
            return (null, null);
        }

        public void AddCoronaPatient(Patient patient, CoronaDetails coronaDetails)
        {
            patient.CoronaDetails = coronaDetails;
            _context.CoronaDetails.Add(coronaDetails);
            _context.SaveChanges();
        }
        #endregion
    }
}
