using AirlineProgram.ModelDB;
using System.Collections.ObjectModel;
using System.Linq;

namespace AirlineProgram.ViewModel
{
    public class ViewModelBuyTickets
    {
        public static ObservableCollection<Flights> FlightsCollection { get; set; } //Коллекция авиарейсов
        public Flights SelectedFlight { get; set; } //Выбранный авиарейс в DataGrid

        public ViewModelBuyTickets()
        {
            FlightsCollection = new ObservableCollection<Flights>(DbAirlineEntities.GetContext().Flights.ToList()); //Получаем данные из БД о авиарейсах
        }
    }
}
