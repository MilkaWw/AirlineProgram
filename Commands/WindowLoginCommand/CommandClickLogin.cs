using AirlineProgram.Commands.Base;
using AirlineProgram.ModelDB;
using AirlineProgram.View.Windows;
using AirlineProgram.ViewModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace AirlineProgram.Commands.WindowLoginCommand
{
    public class CommandClickLogin : Command
    {
        private bool CheckInputLoginAndPassword(TextBox login, PasswordBox password, TextBlock errorMessage) //Метод для проверки textbox
        {
            bool check = true;

            if (string.IsNullOrWhiteSpace(login.Text))
            {
                errorMessage.Text = "";
                errorMessage.Text += "Введите логин";
                check = false;
            }
            else if (string.IsNullOrWhiteSpace(password.Password))
            {
                errorMessage.Text = "";
                errorMessage.Text += "Введите пароль";
                check = false;
            }
            return check;
        }

        public override bool CanExecute(object parameter) => true;

        public override void Execute(object parameter)
        {
            var infoUser = (object[])parameter;
            var role = (ComboBox)infoUser[0];
            var login = (TextBox)infoUser[1];
            var password = (PasswordBox)infoUser[2];
            var errorMessage = (TextBlock)infoUser[3];
            var mainWindow = (Window)infoUser[4];

            using (DbAirlineEntities db = new DbAirlineEntities())
            {
                

                if (role.Text == "Администратор")
                {
                    if (CheckInputLoginAndPassword(login, password, errorMessage))
                    {
                        var sql = (from admin in db.Admins.ToList()
                                   where admin.AdminLogin == login.Text && admin.AdminPassword == password.Password
                                   select admin).SingleOrDefault();
                        if (sql != null)
                        {
                            ViewModelWindowAdmin.LoginAdmin = login.Text;
                            MainWindowAdmin mainWindowAdmin = new MainWindowAdmin();
                            mainWindow.Close();
                            mainWindowAdmin.Show();
                        }
                        else
                        {
                            MessageBox.Show("Неправильно введен логин или пароль!", "Ошибка", MessageBoxButton.OK);
                        }
                    }
                }
                else if (role.Text == "Пользователь")
                {
                    if (CheckInputLoginAndPassword(login, password, errorMessage))
                    {
                        var sql = (from user in db.Passengers.ToList()
                                   where user.PassengerLogin == login.Text && user.PassengerPassword == password.Password
                                   select user).SingleOrDefault();
                        if (sql != null)
                        {
                            ViewModelWindowPassenger.LoginPassenger = login.Text;
                            MainWindowPassenger mainWindowCustomer = new MainWindowPassenger();
                            mainWindow.Close();
                            mainWindowCustomer.Show();
                        }
                        else
                        {
                            MessageBox.Show("Неправильно введен логин или пароль!", "Ошибка", MessageBoxButton.OK);
                        }
                    }
                }
                else
                {
                    errorMessage.Text += "Выберите роль для входа!";
                }
            }
        }
    }
}
