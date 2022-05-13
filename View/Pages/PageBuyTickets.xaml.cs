using AirlineProgram.ViewModel;
using System.Linq;
using System.Windows.Controls;

namespace AirlineProgram.View.Pages
{
    public partial class PageBuyTickets : Page
    {
        public PageBuyTickets()
        {
            InitializeComponent();
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)  //Поиск
        {
            var tb = sender as TextBox;
            if (tb.Text != "")
            {
                var filteredList = ViewModelBuyTickets.FlightsCollection.Where(t => t.Flight_name.ToLower().Contains(tb.Text.ToLower()));  //Получаем список по введенному тексту в TextBox(Поиск)
                lvTicket.ItemsSource = null; //Обнуляем список
                lvTicket.ItemsSource = filteredList; //Обновляем список
            }
            else
            {
                lvTicket.ItemsSource = ViewModelBuyTickets.FlightsCollection; //Первоначальный список
            }
        }
    }
}
