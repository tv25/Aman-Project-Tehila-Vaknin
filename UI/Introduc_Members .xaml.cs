using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// Interaction logic for LineStations.xaml
    /// </summary>
    public partial class Introduc_Members : Window
    {
        IBL bl;
        public BO.Patient p = new BO.Patient();
        public Introduc_Members(IBL bb)
        {
            InitializeComponent();
            bl = bb;

            stationDataGrid.ItemsSource = bl.GetAllPatient(); 

        }


        private void Button_Click_add(object sender, RoutedEventArgs e)//add station
        {
            AddNewPatient add = new AddNewPatient(bl);
             add.ShowDialog();
            stationDataGrid.ItemsSource = bl.GetAllPatient();
        }
        private void Button_Click_search(object sender, RoutedEventArgs e)//add station
        {
            searchpatient add = new searchpatient(bl);
            add.ShowDialog();
            stationDataGrid.ItemsSource = bl.GetAllPatient();
        }


        private void stationDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            {
                if (stationDataGrid.SelectedItem != null)
                {
                    p = (stationDataGrid.SelectedItem as BO.Patient);
                    p = bl.GetPatient(p.id_Patient);
                    lineStationDataGrid.ItemsSource = bl.GetAllCoronaPatientBy(p.id_Patient);
                    dates.ItemsSource=bl.GetAllPatientVaccineDates(p.id_Patient);
                    names.ItemsSource = bl.GetAllVaccineManufacturers(p.id_Patient);
                    
                    tbname.Text = p.id_Patient.ToString();
                    tbcode.Text = p.FirstName;
                }
                else { stationDataGrid.SelectedItem = default; }
              
            }
        }



        
        }
    }

