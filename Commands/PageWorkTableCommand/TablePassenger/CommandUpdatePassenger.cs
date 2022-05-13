using AirlineProgram.Commands.Base;
using AirlineProgram.ModelDB;
using AirlineProgram.ViewModel;
using System.Linq;
using System.Windows.Controls;

namespace AirlineProgram.Commands.PageWorkTableCommand.TablePassenger
{
    public class CommandUpdatePassenger : Command
    {
        public override bool CanExecute(object parameter) //Проверка на нажатие на кнопку
        {
            if (parameter is null)
            {
                return false;
            }
            else
            {
                if ((parameter as DataGrid).SelectedItem != null)
                {
                    return true;
                }
                return false;
            }
        }

        public override void Execute(object parameter) //Дествия при нажатие на кнопку
        {
            using (DbAirlineEntities db = new DbAirlineEntities())
            {
                var updatePassenger = ViewModelWorkTable.selectedPassengers; //Получаем данные выбранного пасажира
                var passenger = db.Passengers.FirstOrDefault(fl => fl.Passenger_code == updatePassenger.Passenger_code); //Ищем пасажира в БД по коду выбранного пасажира(updatePassenger)
                passenger.Surname = updatePassenger.Surname;
                passenger.Firstname = updatePassenger.Firstname;
                passenger.Lastname = updatePassenger.Lastname;
                passenger.PassportSeries = updatePassenger.PassportSeries;
                passenger.Visa = updatePassenger.Visa;

                db.SaveChanges();
            }
        }
    }
}
