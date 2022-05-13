using AirlineProgram.Commands.Base;
using AirlineProgram.ModelDB;
using AirlineProgram.ViewModel;
using System.Linq;
using System.Windows;

namespace AirlineProgram.Commands
{
    public class CommandBuyTicket : Command
    {
        public override bool CanExecute(object parameter)
        {
            if (parameter is null) return false;

            var parameterButton = (object[])parameter;
            var selectedItem = parameterButton[2];
            if (selectedItem is null) return false;
            return true;
        }

        public override void Execute(object parameter)
        {
            var parameterButton = (object[])parameter;
            var tbFlightName = (string)parameterButton[0];
            var btnBuy = (double)parameterButton[1];

            using(DbAirlineEntities db = new DbAirlineEntities())
            {
                var sqlPassengerLogin_Code = (from passenger in db.Passengers.ToList()
                                           where passenger.PassengerLogin == ViewModelWindowPassenger.loginPassenger
                                           select passenger.Passenger_code).SingleOrDefault();
                var sqlFlightName_Code = (from flight in db.Flights.ToList()
                                           where flight.Flight_name == tbFlightName
                                           select flight.Flight_code).SingleOrDefault();

                if(sqlFlightName_Code != 0 && sqlFlightName_Code != 0)
                {
                    Tickets newFlight = new Tickets()
                    { 
                        Passenger_code = sqlPassengerLogin_Code,
                        Flight_code = sqlFlightName_Code
                    };
                    db.Tickets.Add(newFlight);
                    db.SaveChanges();

                    var res = MessageBox.Show("Вы действительно хотите купить этот билет!", "Оплата", MessageBoxButton.YesNo);

                    switch (res)
                    { 
                        case MessageBoxResult.Yes:
                            break;
                        case MessageBoxResult.No:
                            db.Tickets.Remove(newFlight);
                            db.SaveChanges();
                            break;
                    }
                }
            }
        }
    }
}
