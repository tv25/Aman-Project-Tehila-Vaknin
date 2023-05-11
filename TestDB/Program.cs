using TestDB.DATA;
using TestDB.Models;

var patients = new List<Patient>
            {
                new Patient
                {
                    id_Patient = 387876787,
                    FirstName = "חנה",
                    LastName = "כהן",
                    City = "New York",
                    Street = "Main Street",
                    Number_Home = 1,
                    DateOfBirth = new DateTime(1980, 1, 1),
                    Telephone = 123456789,
                    MobilePhone = 987654321,
                    CoronaDetails = new CoronaDetails
                    {
                        RecoveryDate = new DateTime(2022, 1, 15),
                        StartCoronaDate = new DateTime(2022, 1, 1),
                        dateAndmanufacturer = new List<DetailVacsions>
                        {
                            new DetailVacsions { Date = new DateTime(2021, 6, 1), manufacturer = "אבי" },
                            new DetailVacsions { Date = new DateTime(2021, 7, 1), manufacturer = "מוטי" }
                        }
                    }
                },
                 new Patient
                {
                    id_Patient = 226764489,
                    FirstName = "דוד",
                    LastName = "זר",
                    City = "New York",
                    Street = "Main Street",
                    Number_Home = 1,
                    DateOfBirth = new DateTime(2020, 1, 1),
                    Telephone = 123456789,
                    MobilePhone = 987654321,
                    CoronaDetails = new CoronaDetails
                    {
                        RecoveryDate = new DateTime(2022, 1, 15),
                        StartCoronaDate = new DateTime(2022, 1, 1),
                        dateAndmanufacturer = new List<DetailVacsions>
                        {
                            new DetailVacsions { Date = new DateTime(2021, 6, 1), manufacturer = "אבי" },
                            new DetailVacsions { Date = new DateTime(2021, 7, 1), manufacturer = "מוטי" }
                        }
                    }
                },
                  new Patient
                {
                    id_Patient = 376766487,
                    FirstName = "שרה",
                    LastName = "אלמסי",
                    City = "New York",
                    Street = "Main Street",
                    Number_Home = 1,
                    DateOfBirth = new DateTime(1992, 1, 1),
                    Telephone = 123456789,
                    MobilePhone = 987654321,
                    CoronaDetails = new CoronaDetails
                    {
                        RecoveryDate = new DateTime(2022, 1, 15),
                        StartCoronaDate = new DateTime(2022, 1, 1),
                        dateAndmanufacturer = new List<DetailVacsions>
                        {
                            new DetailVacsions { Date = new DateTime(2021, 6, 1), manufacturer = "חנה" },
                            new DetailVacsions { Date = new DateTime(2021, 7, 1), manufacturer = "מוטי" }
                        }
                    }
                },
                   new Patient
                {
                    id_Patient = 336789900,
                    FirstName = "מירי",
                    LastName = "לוי",
                    City = "בני ברק",
                    Street = "חפת חיים",
                    Number_Home = 1,
                    DateOfBirth = new DateTime(2014, 1, 1),
                    Telephone = 123456789,
                    MobilePhone = 987654321,
                    CoronaDetails = new CoronaDetails
                    {
                        RecoveryDate = new DateTime(2022, 1, 15),
                        StartCoronaDate = new DateTime(2022, 1, 1),
                        dateAndmanufacturer = new List<DetailVacsions>
                        {
                            new DetailVacsions { Date = new DateTime(2021, 6, 1), manufacturer = "מחמוד" },
                            new DetailVacsions { Date = new DateTime(2021, 7, 1), manufacturer = "מחמוד" }
                        }
                    }
                },
                    new Patient
                {
                    id_Patient = 227876678,
                    FirstName = "נעמה",
                    LastName = "ברסי",
                    City = "ירושלים",
                    Street = "רמות",
                    Number_Home = 3,
                    DateOfBirth = new DateTime(1995, 1, 1),
                    Telephone = 123456789,
                    MobilePhone = 987654321,
                    CoronaDetails = new CoronaDetails
                    {
                        RecoveryDate = new DateTime(2022, 1, 15),
                        StartCoronaDate = new DateTime(2022, 1, 1),
                        dateAndmanufacturer = new List<DetailVacsions>
                        {
                            new DetailVacsions { Date = new DateTime(2021, 6, 1), manufacturer = "אבי" },
                            new DetailVacsions { Date = new DateTime(2021, 7, 1), manufacturer = "מחמוד" }
                        }
                    }
                },

                    new Patient
                {
                    id_Patient = 234543454,
                    FirstName = "שמעון",
                    LastName = "וקנין",
                    City = "New York",
                    Street = "Main Street",
                    Number_Home = 1,
                    DateOfBirth = new DateTime(1980, 1, 1),
                    Telephone = 123456789,
                    MobilePhone = 987654321,
                    CoronaDetails = new CoronaDetails
                    {
                        RecoveryDate = new DateTime(2022, 1, 15),
                        StartCoronaDate = new DateTime(2022, 1, 1),
                        dateAndmanufacturer = new List<DetailVacsions>
                        {
                            new DetailVacsions { Date = new DateTime(2021, 6, 1), manufacturer = "רות" },
                            new DetailVacsions { Date = new DateTime(2021, 7, 1), manufacturer = "רות" }
                        }
                    }
                },

                    new Patient
                {
                    id_Patient = 337876676,
                    FirstName = "מיכל",
                    LastName = "אברגל",
                    City = "New York",
                    Street = "Main Street",
                    Number_Home = 1,
                    DateOfBirth = new DateTime(2018, 1, 1),
                    Telephone = 123456789,
                    MobilePhone = 987654321,
                    CoronaDetails = new CoronaDetails
                    {
                        RecoveryDate = new DateTime(2022, 1, 15),
                        StartCoronaDate = new DateTime(2022, 1, 1),
                        dateAndmanufacturer = new List<DetailVacsions>
                        {
                            new DetailVacsions { Date = new DateTime(2021, 6, 1), manufacturer = "אבי" },
                            new DetailVacsions { Date = new DateTime(2021, 7, 1), manufacturer = "מוטי" }
                        }
                    }
                },

                    new Patient
                {
                    id_Patient = 227500098,
                    FirstName = "מירי",
                    LastName = "מסיקה",
                    City = "קרית יערים",
                    Street = "בלוך",
                    Number_Home = 70,
                    DateOfBirth = new DateTime(2000, 1, 1),
                    Telephone = 123456789,
                    MobilePhone = 987654321,
                    CoronaDetails = new CoronaDetails
                    {
                        RecoveryDate = new DateTime(2022, 1, 15),
                        StartCoronaDate = new DateTime(2022, 1, 1),
                        dateAndmanufacturer = new List<DetailVacsions>
                        {
                            new DetailVacsions { Date = new DateTime(2021, 6, 1), manufacturer = "מירי" },
                            new DetailVacsions { Date = new DateTime(2021, 7, 1), manufacturer = "מירי" }
                        }
                    }
                },

                    new Patient
                {
                    id_Patient = 334344545,
                    FirstName = "מחמוד",
                    LastName = "מחמודי",
                    City = "אבו גאש",
                    Street = "ראשיד",
                    Number_Home = 1,
                    DateOfBirth = new DateTime(1980, 1, 1),
                    Telephone = 123456789,
                    MobilePhone = 987654321,
                    CoronaDetails = new CoronaDetails
                    {
                        RecoveryDate = new DateTime(2022, 1, 15),
                        StartCoronaDate = new DateTime(2022, 1, 1),
                        dateAndmanufacturer = new List<DetailVacsions>
                        {
                            new DetailVacsions { Date = new DateTime(2021, 6, 1), manufacturer = "אבי" },
                            new DetailVacsions { Date = new DateTime(2021, 7, 1), manufacturer = "מוטי" }
                        }
                    }
                },

                    new Patient
                {
                    id_Patient = 276786675,
                    FirstName = "לייה",
                    LastName = "וקנין",
                    City = "New York",
                    Street = "Main Street",
                    Number_Home = 1,
                    DateOfBirth = new DateTime(1993, 1, 1),
                    Telephone = 123456789,
                    MobilePhone = 987654321,
                    CoronaDetails = new CoronaDetails
                    {
                        RecoveryDate = new DateTime(2022, 1, 15),
                        StartCoronaDate = new DateTime(2022, 1, 1),
                        dateAndmanufacturer = new List<DetailVacsions>
                        {
                            new DetailVacsions { Date = new DateTime(2021, 6, 1), manufacturer = "ראובן" },
                            new DetailVacsions { Date = new DateTime(2021, 7, 1), manufacturer = "מוטי" }
                        }
                    }
                },

                    new Patient
                {
                    id_Patient = 267656567,
                    FirstName = "גיטי",
                    LastName = "נרוב",
                    City = "New York",
                    Street = "Main Street",
                    Number_Home = 1,
                    DateOfBirth = new DateTime(1980, 1, 1),
                    Telephone = 123456789,
                    MobilePhone = 987654321,
                    CoronaDetails = new CoronaDetails
                    {
                        RecoveryDate = new DateTime(2022, 1, 15),
                        StartCoronaDate = new DateTime(2022, 1, 1),
                        dateAndmanufacturer = new List<DetailVacsions>
                        {
                            new DetailVacsions { Date = new DateTime(2021, 6, 1), manufacturer = "מחוד" },
                            new DetailVacsions { Date = new DateTime(2021, 7, 1), manufacturer = "מחוד" }
                        }
                    }
                },

                     new Patient
                {
                    id_Patient = 337876676,
                    FirstName = "רבקה",
                    LastName = "לוי",
                    City = "New York",
                    Street = "Main Street",
                    Number_Home = 1,
                    DateOfBirth = new DateTime(1980, 1, 1),
                    Telephone = 123456789,
                    MobilePhone = 987654321,
                    CoronaDetails = new CoronaDetails
                    {
                        RecoveryDate = new DateTime(2022, 1, 15),
                        StartCoronaDate = new DateTime(2022, 1, 1),
                        dateAndmanufacturer = new List<DetailVacsions>
                        {
                            new DetailVacsions { Date = new DateTime(2021, 6, 1), manufacturer = "חמוד" },
                            new DetailVacsions { Date = new DateTime(2021, 7, 1), manufacturer = "מחמוד" }
                        }
                    }
                }

            };


using (var db = new Data())
{
    db.Patients.AddRange(patients);
    db.SaveChanges();
}

Console.WriteLine("Data added successfully!");
