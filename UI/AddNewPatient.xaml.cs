using BLAPI;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TestDB.Migrations;

namespace PlGui
{
    /// <summary>
    /// Interaction logic for AddNewLine.xaml
    /// </summary>
    public partial class AddNewPatient : Window
    {
        IBL bl;
        public BO.Patient patient = new BO.Patient();
        public BO.CoronaPatient coronapatient = new BO.CoronaPatient();
        public AddNewPatient(IBL bbl)
        {
            InitializeComponent();
            bl = bbl;
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            //input is only numbers
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        /// <summary>
        /// 
        /// the function check if the client enter a value in textbox
        /// </summary>
        /// <param name="textBox"></param>
        /// <returns>if the client didnt enter value-return true</returns>
        private bool CheckAndReplaceNull(TextBox textBox)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                return true;
            }
        return false;
        }
        /// <summary>
        /// 
        //the function return true if the client didnt enter any  date value
        /// </summary>
        /// <param name="datePicker"></param>
        /// <returns></returns>
        public bool IsDatePickerEmpty(DatePicker datePicker)
        {
            if (datePicker.SelectedDate == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        private void btnSaveNewLine_Click(object sender, RoutedEventArgs e)
        {
            //id
            if (txtLineCode.Text.Length != 9 )
            { MessageBox.Show("הקש מספר בעל 9 ספרות בלבד"); }
            //firstand last name
            else if (CheckAndReplaceNull(p_firstname) || CheckAndReplaceNull(p_lastname)) { MessageBox.Show("חובה להכניס שם פרטי ושם משפחה"); }
            //telefhone
            else if (!(Regex.IsMatch(bttelefhon.Text, @"^0\d{8}$")) && !(CheckAndReplaceNull(bttelefhon)))
            {
                MessageBox.Show("מספר טלפון שגוי ");
            }
            //plefhone
            else if (!(Regex.IsMatch(btfhone.Text, @"^05\d{8}$")) && !(CheckAndReplaceNull(btfhone)))
            {
                MessageBox.Show("נא להכניס מספר פלאפון תקין ");
            }
            //corona dates
            else if ((datefinishcorona.SelectedDate) <= (dategetcorona.SelectedDate) && !(IsDatePickerEmpty(datefinishcorona)) && !(IsDatePickerEmpty(dategetcorona)))
            {
                MessageBox.Show(" תאריכי תחלואת קורונה שגויים");
            }
            else if (((IsDatePickerEmpty(dategetvecion)) && (!(CheckAndReplaceNull(vaccinemanufacturer)))) || 
                (!(IsDatePickerEmpty(dategetvecion))) && ((CheckAndReplaceNull(vaccinemanufacturer))))
             {
                MessageBox.Show(" חובה להכניס גם תאריך קבלת החיסון וגם שם יצרן החיסון");
            }
            //cant inset date of finish corona and not start corona
            else if (((IsDatePickerEmpty(dategetcorona)) && (!(IsDatePickerEmpty(datefinishcorona)))))
            {
                MessageBox.Show("חסר תאריך תחילת הקורונה");
            }
            else if (IsDatePickerEmpty(btdate))
            {
                MessageBox.Show("חובה להזין תאריך לידה");
            }

            else
            {
                try
                {
                   

                    //tekefhon
                    if (CheckAndReplaceNull(bttelefhon)) { patient.Telephone = null; }
                    else { patient.Telephone = int.Parse(bttelefhon.Text); }
                    //plefhon
                    if (CheckAndReplaceNull(btfhone)) { patient.MobilePhone = null; }
                    else { patient.MobilePhone = int.Parse(btfhone.Text); }
                    //city
                    if (CheckAndReplaceNull(btcity)) { patient.City = null; }
                    else { patient.City = btcity.Text; }
                    //street
                    if (CheckAndReplaceNull(btStreet)) { patient.Street = null; }
                    else { patient.Street = btStreet.Text; }
                    //date get vacsion
                    if (IsDatePickerEmpty(dategetvecion)) { coronapatient.VaccineDates[0]=DateTime.MinValue; }
                    else { coronapatient.VaccineDates[0] = DateTime.Parse(dategetvecion.Text); }
                    //date get corona
                    if (IsDatePickerEmpty(dategetcorona)) { coronapatient.PositiveResultDate = DateTime.MinValue; }
                    else { coronapatient.PositiveResultDate = DateTime.Parse(dategetcorona.Text); }
                    //date finish corona
                    if (IsDatePickerEmpty(datefinishcorona)) { coronapatient.RecoveryDate = DateTime.MinValue; }
                    else { coronapatient.RecoveryDate = DateTime.Parse(datefinishcorona.Text); }

                    patient.FirstName = p_firstname.Text;
                    patient.id_Patient = int.Parse(txtLineCode.Text);
                    patient.LastName = p_lastname.Text;
                    patient.DateOfBirth = DateTime.Parse(btdate.Text);
                    coronapatient.Id = int.Parse(txtLineCode.Text);                    
                    coronapatient.VaccineManufacturers[0] = vaccinemanufacturer.Text;
                   
                          
                        bl.AddPatient(patient);
                        bl.AddCoronaPatient(coronapatient);
                        MessageBox.Show("הפציינט נוסף בהצלחה");
                        this.Close();
                    }
                    catch (BO.OlreadtExistExceptionBO ex)
                    {
                        MessageBox.Show("הפציינט כבר קיים במערכת");
                    }
                    catch(Exception )
                    {
                        MessageBox.Show("אחד או יותר מהפרטים שהזנת אינם נכונים או חסרים");
                    }
            }

        }
    }
}
