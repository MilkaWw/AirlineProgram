using AirlineProgram.Commands.Base;
using AirlineProgram.ModelDB;
using System.Linq;
using System.Windows.Controls;

namespace AirlineProgram.Commands.PageWorkTableCommand
{
    public class CommandAddFlight : Command
    {
        public override bool CanExecute(object parameter) => true; //проверка

        public override void Execute(object parameter)
        {
            using (DbAirlineEntities db = new DbAirlineEntities())
            {
                db.Flights.Add(new Flights());
                db.SaveChanges();
                (parameter as DataGrid).ItemsSource = DbAirlineEntities.GetContext().Flights.ToList(); //обновление DataGrid
                (parameter as DataGrid).Items.Refresh();
            }
        }
    }
}
