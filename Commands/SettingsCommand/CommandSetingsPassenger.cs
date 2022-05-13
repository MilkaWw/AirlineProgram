using AirlineProgram.Commands.Base;
using AirlineProgram.ModelDB;
using AirlineProgram.ViewModel;
using System.Linq;
using System.Windows;

namespace AirlineProgram.Commands.SettingsCommand
{
    public class CommandSetingsPassenger : Command
    {
        public override bool CanExecute(object parameter) => true; //Проверка на нажатие на кнопку

        public override void Execute(object parameter) //Действия которые выполняет кнопка
        {
            var infoPassenger = (object[])parameter;

            using(DbAirlineEntities db = new DbAirlineEntities())
            {
                var sqlPassenger = (from passeng in db.Passengers.ToList()
                                    where passeng.PassengerLogin == ViewModelWindowPassenger.loginPassenger
                                    select passeng).FirstOrDefault();   //Получаем пассажира
               
                if(sqlPassenger != null)
                {
                    sqlPassenger.Surname = infoPassenger[0].ToString();
                    sqlPassenger.Firstname = infoPassenger[1].ToString();
                    sqlPassenger.Lastname = infoPassenger[2].ToString();
                    sqlPassenger.PassportSeries = infoPassenger[3].ToString();
                    sqlPassenger.Visa = infoPassenger[4].ToString();

                    db.SaveChanges();
                    MessageBox.Show("Данные успешно измененны", "", MessageBoxButton.OK);
                }
            }
        }
    }
}
