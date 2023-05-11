
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLAPI;
using BO;
using Microsoft.VisualBasic;
//using BO;
using TestDB.APIDL;

namespace BL
{
    class BLImp : IBL
    {
        DLAPI dl = DLObject.Instance;
        #region Patient
        public IEnumerable<BO.Patient> GetAllPatient()
        {
            IEnumerable<TestDB.Models.Patient> patientes = dl.GetAllPatient();
            var p = from a in patientes
                    select GetPatient(a.id_Patient);
            var order_p = from a in p
                          orderby a.id_Patient
                          select a;
            return order_p;

        }

        public IEnumerable<BO.Patient> GetAllPatientBy(int id)
        {
            var v = from ls in dl.GetAllPatientBy(p => p.id_Patient == id)//
                    select ls;//
            return from st in v
                   from Patient in dl.GetAllPatient()// 
                   let patientbo = Patient.CopyPropertiesToNew(typeof(BO.Patient)) as BO.Patient
                   where st.id_Patient == patientbo.id_Patient//
                   select patientbo;
        }

        public BO.Patient GetPatient(int id)
        {
            TestDB.Models.Patient dopatient = dl.GetPatient(id);
            BO.Patient bopatient = new BO.Patient();
            bopatient.id_Patient = dopatient.id_Patient;
            bopatient.FirstName = dopatient.FirstName;
            bopatient.LastName = dopatient.LastName;
            bopatient.MobilePhone = dopatient.MobilePhone;
            bopatient.DateOfBirth = dopatient.DateOfBirth;
            bopatient.Telephone = dopatient.Telephone;
            bopatient.Street = dopatient.Street;
            bopatient.City = dopatient.City;
            if(dopatient.Number_Home != null)
            {
                 bopatient.Number_Home = (int)dopatient.Number_Home;
            }
            return bopatient;
        }
        
        public void AddPatient(BO.Patient patient)
        {
            TestDB.Models.Patient p = new TestDB.Models.Patient();
            p.id_Patient = patient.id_Patient;
            p.FirstName = patient.FirstName;
            p.LastName = patient.LastName;
            p.Street = patient.Street;
            p.City = patient.City;
            p.Number_Home = patient.Number_Home;
            p.Telephone = patient.Telephone;
            p.MobilePhone = patient.MobilePhone;
            p.DateOfBirth = patient.DateOfBirth;
            try { dl.AddPatient(p); }
            catch (Exception ex) //TODO: TestDB.Models.OlreadtExistException
            {
                throw new BO.OlreadtExistExceptionBO("this patient already exist", ex);
            }

        }
        #endregion
        #region coronaPatient
        public IEnumerable<CoronaPatient> GetAllCoronaPatient()
        {
            var coronaPatientsData = dl.GetAllCoronaPatients();
            return coronaPatientsData.Select(x => ConvertToBO(x.Item1, x.Item2));
        }

        public IEnumerable<CoronaPatient> GetAllCoronaPatientBy(int id)
        {
            var coronaPatientsData = dl.GetAllCoronaPatientsBy(pair => pair.Item1.id_Patient == id);
            return coronaPatientsData.Select(x => ConvertToBO(x.Item1, x.Item2));
        }
        public IEnumerable<DateTime> GetAllPatientVaccineDates(int id)
        {
            var p = dl.GetPatient(id);
            if (p == null)
            {
                throw new Exception("patient is not exist"); 
            }
            if (p.CoronaDetails == null)
            {
                throw new Exception("there is no corona patient detail"); 
            }
            if (p.CoronaDetails.dateAndmanufacturer == null)
            {
                throw new Exception("there is no date or manufacturer"); // TODO:
            }
            List<DateTime> dates = new();
            foreach (var item in p.CoronaDetails.dateAndmanufacturer)
            {
                dates.Add(item.Date);
            }
            return dates;
        }
        public List<string> GetAllVaccineManufacturers(int id)
        {
            var p = dl.GetPatient(id);
            if (p==null)
            {
                throw new Exception("patient is not exist"); // TODO:
            }
            if (p.CoronaDetails == null)
            {
                throw new Exception("there is now corona patient details"); // TODO:
            }
            if(p.CoronaDetails.dateAndmanufacturer == null)
            {
                throw new Exception("there is no date or manufacturer"); // TODO:
            }
            List<string> names = new();
            foreach (var item in p.CoronaDetails.dateAndmanufacturer)
            {
                names.Add(item.manufacturer);
            }
            return names;
        }

        public void AddCoronaPatient(CoronaPatient CoronaPatient)
        {
            var p = dl.GetPatient(CoronaPatient.Id);
            TestDB.Models.CoronaDetails details = new();
            details.StartCoronaDate = CoronaPatient.PositiveResultDate;
            details.RecoveryDate = CoronaPatient.RecoveryDate;
            List<TestDB.Models.DetailVacsions> list = new();
            for (int i = 0; i < CoronaPatient.VaccineManufacturers.Length; i++)
            {
                if (CoronaPatient.VaccineManufacturers[i] == null)
                    continue;
                list.Add(new TestDB.Models.DetailVacsions()
                {
                    Date = CoronaPatient.VaccineDates[i],
                    manufacturer = CoronaPatient.VaccineManufacturers[i],
                }) ;
               
            }
            details.dateAndmanufacturer = list;
            try { dl.AddCoronaPatient(p, details); }
            catch (Exception ex) 
            {
                throw new BO.OlreadtExistExceptionBO("this patient already exist", ex);
            }
        }
        #endregion


        private CoronaPatient ConvertToBO(TestDB.Models.Patient patient, TestDB.Models.CoronaDetails coronaDetails)
        {
            CoronaPatient boCoronaPatient = new CoronaPatient
            {
                Id = patient.id_Patient,
                PositiveResultDate = coronaDetails.StartCoronaDate.GetValueOrDefault(),
                RecoveryDate = coronaDetails.RecoveryDate.GetValueOrDefault(),
                VaccineDates = coronaDetails.dateAndmanufacturer.Select(x => x.Date).ToArray(),
                VaccineManufacturers = coronaDetails.dateAndmanufacturer.Select(x => x.manufacturer).ToArray()
            };

            return boCoronaPatient;
        }

        public CoronaPatient GetCoronaPatient(int id)
        {
            throw new NotImplementedException();
        }
    }
}