using AirlineProgram.Commands.Base;
using AirlineProgram.ModelDB;
using System.Linq;
using System.Windows.Controls;

namespace AirlineProgram.Commands.PageWorkTableCommand
{
    public class CommandDeleteFlight : Command
    {
        public override bool CanExecute(object parameter) //Проверка
        {
            if (parameter is null)
            {
                return false;
            }
            else
            {
                var parameters = (object[])parameter;
                var tbString = (string)parameters[0];
                if (string.IsNullOrWhiteSpace(tbString))
                {
                    return false;
                }
                return true;
            }
        }

        public override void Execute(object parameter) //ДеЙствие
        {
            var parameters = (object[])parameter;
            var tbString = (string)parameters[0];
            var dataGrid = (DataGrid)parameters[1];

            using (DbAirlineEntities db = new DbAirlineEntities())
            {
                var sql = (from flight in db.Flights.ToList()
                           where flight.Flight_code.ToString() == tbString
                           select flight).SingleOrDefault();
                if(sql != null)
                {
                    db.Flights.Remove(sql);
                    db.SaveChanges();
                    dataGrid.ItemsSource = DbAirlineEntities.GetContext().Flights.ToList(); //Обновление данных в DataGrid
                    dataGrid.Items.Refresh();
                }
            }
        }
    }
}
