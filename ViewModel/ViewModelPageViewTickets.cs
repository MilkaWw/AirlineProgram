using AirlineProgram.Commands.Base;
using AirlineProgram.ModelDB;
using AirlineProgram.View.Windows;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace AirlineProgram.ViewModel
{
    public class ViewModelPageViewTickets
    {
        #region Коллекции и списки Билетов
        private ObservableCollection<Tickets> collectionTickets;

        private static List<Tickets> collectionPassengerTickets = new List<Tickets>();
        public static List<Tickets> CollectonPassengerTickets { get => collectionPassengerTickets; set => collectionPassengerTickets = value; }
        #endregion

        public static Tickets SelectedTickets { get; set; } //выбраный элемент в DataGrid

        int passengerCode = (from passenger in DbAirlineEntities.GetContext().Passengers.ToList()
                             where passenger.PassengerLogin == ViewModelWindowPassenger.loginPassenger
                             select passenger.Passenger_code).SingleOrDefault(); //Получаем код-пассажира из веденного логина при авторизации.
        #region Комманды
        public Command ClickBtnTicketViewCommand { get; }
        private bool CanClickBtnTicketViewCommandExecute(object p) //Проверка на возможность нажатия на кнопку
        {
            if (p is null) return false;
            return true;
        }
        private void OnClickBtnTicketViewCommandExecuted(object p) //Дествия которые выполняет кнопка при нажатие
        {
            var windowTicket = new WindowPrintTicket();
            windowTicket.Show();
        }
        #endregion

        public ViewModelPageViewTickets()
        {
            collectionTickets = new ObservableCollection<Tickets>(DbAirlineEntities.GetContext().Tickets.ToList()); //Получаем данные из БД
            var tickets = collectionTickets.Where(t => t.Passenger_code == passengerCode).ToList();//Поиск купленных билетов конкретного пассажира
            collectionPassengerTickets = tickets;//Присваиваем пустому списку билеты пассажира

            ClickBtnTicketViewCommand = new LambdaCommand(OnClickBtnTicketViewCommandExecuted, CanClickBtnTicketViewCommandExecute);//Команда нажатия на кнопку "Показать билеты"
        }
    }
}
