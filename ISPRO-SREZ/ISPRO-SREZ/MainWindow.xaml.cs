using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ISPRO_SREZ
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public class Client
        {
            public string LastName { get; set; }
            public string FirstName { get; set; }
            public string Patronymic { get; set; }
        }
        public class Telephone
        {
            public int Articul { get; set; }
            public string NameTelephone { get; set; }
            public string Category { get; set; }
            public decimal Cost { get; set; }
            public int Count { get; set; }
            public string Manufacturer { get; set; }
        }
        public class Sale
        {
            public DateTime DateSale { get; set; }
            public Client Client { get; set; }
            public List<Telephone> Telephones { get; set; }

        }

        public MainWindow()
        {
            InitializeComponent();
        }


        private void btnChekWord_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCheckExcel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnOtchetWord_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnOtchetExcel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            string start = "";
            string end = "";
            try
            {
                DateTime? selectedDate = dpStart.SelectedDate;
                if (selectedDate.HasValue)
                {
                    start = selectedDate.Value.ToString("dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture);
                }
                DateTime? selectedDateEnd = dpStart.SelectedDate;
                if (selectedDateEnd.HasValue)
                {
                    end = selectedDateEnd.Value.ToString("dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture);
                }
                using (HttpClient client = new HttpClient())
                {
                    string query =
                        $"https://localhost:7100/api/Sale?dateStart={start}&dateEnd={end}";
                    string response = client.PostAsync(query, null).Result.Content.ReadAsStringAsync().Result;
                    List<Sale> saleList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Sale>>(response);
                    dgSale.ItemsSource = saleList;                  
                }
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }
            
        }
    }
}
