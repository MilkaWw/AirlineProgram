using AirlineProgram.ViewModel;
using System.Linq;
using System.Windows.Controls;

namespace AirlineProgram.View.Pages
{
    public partial class PageViewTickets : Page
    {
        public PageViewTickets()
        {
            InitializeComponent();
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)  //Поиск
        {
            var tb = sender as TextBox;
            if (tb.Text != "")
            {
                var filteredList = ViewModelPageViewTickets.CollectonPassengerTickets.Where(t => t.Flights.Flight_name.ToLower().Contains(tb.Text.ToLower())); //Получаем список по введенному тексту в TextBox(Поиск)
                dgInfoTickets.ItemsSource = null; //Обнуляем список
                dgInfoTickets.ItemsSource = filteredList;  //Обновляем список
            }
            else
            {
                dgInfoTickets.ItemsSource = ViewModelPageViewTickets.CollectonPassengerTickets; //Первоначальный список
            }
        }
    }
}
