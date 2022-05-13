using AirlineProgram.Commands.Base;
using AirlineProgram.ModelDB;
using AirlineProgram.ViewModel;
using System.Linq;
using System.Windows;

namespace AirlineProgram.Commands.SettingsCommand
{
    public class CommandSetingsAdmincs : Command
    {
        public override bool CanExecute(object parameter) => true;

        public override void Execute(object parameter)
        {
            var infoPassenger = (object[])parameter;

            using (DbAirlineEntities db = new DbAirlineEntities())
            {
                var sqlAdmin = (from adm in db.Admins.ToList()
                                where adm.AdminLogin == ViewModelWindowAdmin.loginAdmin
                                select adm).FirstOrDefault();

                if (sqlAdmin != null)
                {
                    sqlAdmin.Surname = infoPassenger[0].ToString();
                    sqlAdmin.Firstname = infoPassenger[1].ToString();
                    sqlAdmin.Lastname = infoPassenger[2].ToString();

                    db.SaveChanges();
                    MessageBox.Show("Данные успешно измененны", "", MessageBoxButton.OK);
                }
            }
        }
    }
}
