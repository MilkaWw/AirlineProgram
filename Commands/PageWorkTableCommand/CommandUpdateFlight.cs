using AirlineProgram.Commands.Base;
using AirlineProgram.ModelDB;
using AirlineProgram.ViewModel;
using System.Linq;
using System.Windows.Controls;

namespace AirlineProgram.Commands.PageWorkTableCommand
{
    public class CommandUpdateFlight : Command
    {
        public override bool CanExecute(object parameter) //Проверка
        {
            if(parameter is null)
            {
                return false;
            }
            else
            {
                var parameters = (object[])parameter;
                if((parameters[4] as DataGrid).SelectedItem != null)
                {
                    return true;
                }
                return false;
            }
        }

        public override void Execute(object parameter)
        {
            var parameters = (object[])parameter;
            using (DbAirlineEntities db = new DbAirlineEntities())
            {
                var updateFlight = ViewModelWorkTable.selectedFlights; //Выбраный рейс
                var flight = db.Flights.FirstOrDefault(fl => fl.Flight_code == updateFlight.Flight_code); //Ищем рейс по коду выбранного рейса

                if(flight != null)
                {
                    //Обновление строчек в рейсе
                    flight.Flight_name = updateFlight.Flight_name;
                    flight.Departure_dateTime = updateFlight.Departure_dateTime;
                    flight.Arrival_dateTime = updateFlight.Arrival_dateTime;
                    flight.Place = updateFlight.Place;
                    flight.Price = updateFlight.Price;

                    #region LINQ-ЗАПРОСЫ(Название => код)
                    var airline = (from air in db.Airlines.ToList()
                                   where air.Airline_name == parameters[0].ToString()
                                   select air.Airline_code).FirstOrDefault();

                    if(airline == 0)
                    {
                        Airlines newAirline = new Airlines { Airline_name = parameters[0].ToString() };
                        db.Airlines.Add(newAirline);
                        db.SaveChanges();

                        flight.Airline_code = newAirline.Airline_code; //обновление нового значения
                    }
                    else
                    {
                        flight.Airline_code = airline; //обновление существующего значения
                    }

                    var airplane = (from air_plane in db.Airplanes.ToList()
                                   where air_plane.Airplane_name == parameters[1].ToString()
                                   select air_plane.Airplane_code).FirstOrDefault();

                    if (airplane == 0)
                    {
                        Airplanes newAirplane = new Airplanes { Airplane_name = parameters[1].ToString() };
                        db.Airplanes.Add(newAirplane);
                        db.SaveChanges();

                        flight.Airplane_code = newAirplane.Airplane_code; //обновление нового значения
                    }
                    else
                    {
                        flight.Airplane_code = airplane; //обновление существующего значения
                    }

                    var airportDeparture = (from airport1 in db.Airports.ToList()
                                            where airport1.Airport_name == parameters[2].ToString()
                                            select airport1.Airport_code).FirstOrDefault();

                    if (airportDeparture == 0)
                    {
                        Airports newAirportDeparture = new Airports { Airport_name = parameters[2].ToString() };
                        db.Airports.Add(newAirportDeparture);
                        db.SaveChanges();

                        flight.Departure_airport = newAirportDeparture.Airport_code; //обновление нового значения
                    }
                    else
                    {
                        flight.Departure_airport = airportDeparture; //обновление существующего значения
                    }

                    var airportArrival = (from airport in db.Airports.ToList()
                                          where airport.Airport_name == parameters[3].ToString()
                                          select airport.Airport_code).FirstOrDefault();

                    if (airportArrival == 0)
                    {
                        Airports newAirportArival = new Airports { Airport_name = parameters[3].ToString() };
                        db.Airports.Add(newAirportArival);
                        db.SaveChanges();

                        flight.Departure_airport = newAirportArival.Airport_code; //обновление нового значения
                    }
                    else
                    {
                        flight.Arrival_airport = airportArrival; // обновление существующего значения
                    }
                    #endregion

                    db.SaveChanges();

                    (parameters[4] as DataGrid).ItemsSource = db.Flights.ToList(); //Обновляем данные в DataGrid
                    (parameters[4] as DataGrid).Items.Refresh();
                }

            }
        }
    }
}
