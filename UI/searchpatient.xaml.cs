using System;
using System.Collections.Generic;
using System.Linq;
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
using BLAPI;

namespace PlGui
{
    /// <summary>
    /// Interaction logic for searchpatient.xaml
    /// </summary>
    public partial class searchpatient : Window
    {
        IBL bl;
        public BO.Patient p = new BO.Patient();
        public searchpatient(IBL bb)
        {
            InitializeComponent();
            bl = bb;

        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            //input is only numbers
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void add_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if ((idpatient.Text.Length) != 9 )
            {
                MessageBox.Show("הקש מספר בן 9  ספרות בלבד");
            }

            else
            {
                try
                {
                    patientDataGrid.ItemsSource = bl.GetAllPatientBy(int.Parse(idpatient.Text));

                }
                catch (BO.OlreadtExistExceptionBO ex)
                {
                    MessageBox.Show("הפציינט לא קיים במערכת ");
                }
            }

        }
    }
}
