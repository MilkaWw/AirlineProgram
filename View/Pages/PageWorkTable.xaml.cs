using AirlineProgram.ViewModel;
using System.Linq;
using System.Windows.Controls;

namespace AirlineProgram.View.Pages
{
    public partial class PageWorkTable : Page
    {
        public PageWorkTable()
        {
            InitializeComponent();
        }

        private void tb_Search_Flights(object sender, TextChangedEventArgs e) //Поиск для авиарейсов
        {
            var tb = sender as TextBox;
           if (tb.Text != "")
            {
                var filteredList = ViewModelWorkTable.CollectionFlights.Where(t => t.Flight_name.ToString().ToLower().Contains(tb.Text.ToLower()));  //Получаем список по введенному тексту в TextBox(Поиск)
                dataGrid.ItemsSource = null; //Обнуляем список
                dataGrid.ItemsSource = filteredList; //Обновляем список
            }
            else
            {
                dataGrid.ItemsSource = ViewModelWorkTable.CollectionFlights; //Первоначальный список
            }
        }

        private void tb_Search_Passenger(object sender, TextChangedEventArgs e) //Поиск для пасажирова
        {
            var tb = sender as TextBox;
            if (tb.Text != "")
            {
                var filteredList = ViewModelWorkTable.CollectionPassengers.Where(t => t.Surname.ToString().ToLower().Contains(tb.Text.ToLower()));  //Получаем список по введенному тексту в TextBox(Поиск)
                dataGrid2.ItemsSource = null; //Обнуляем список
                dataGrid2.ItemsSource = filteredList; //Обновляем список
            }
            else
            {
                dataGrid2.ItemsSource = ViewModelWorkTable.CollectionPassengers; //Первоначальный список
            }
        }
    }
}
