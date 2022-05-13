using AirlineProgram.Commands.Base;
using AirlineProgram.ModelDB;
using System.Windows;
using System.Windows.Controls;

namespace AirlineProgram.Commands.WindowLoginCommand
{
    public class CommandClickRegistration : Command
    {
        private bool CheckInputLoginAndPassword(TextBox login, PasswordBox password, PasswordBox checkPassword, TextBlock errorMessage) //Проверка на ввод данных в TextBox
        {
            bool check = true;

            if (string.IsNullOrWhiteSpace(login.Text))
            {
                check = false;
                errorMessage.Text = "";
                errorMessage.Text += "Введите логин";
            }
            else if (string.IsNullOrWhiteSpace(password.Password))
            {
                check = false;
                errorMessage.Text = "";
                errorMessage.Text += "Введите пароль";
            }
            else if (string.IsNullOrWhiteSpace(checkPassword.Password))
            {
                check = false;
                errorMessage.Text = "";
                errorMessage.Text += "Введите повторно пароль";
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
            var checkPassword = (PasswordBox)infoUser[3];
            var errorMessage = (TextBlock)infoUser[4];

            using (DbAirlineEntities db = new DbAirlineEntities())
            {

                Admins admin = new Admins()
                {
                    AdminLogin = login.Text,
                    AdminPassword = password.Password
                };

                Passengers passenger = new Passengers()
                {
                    PassengerLogin = login.Text,
                    PassengerPassword = password.Password
                };

                if (role.Text == "Администратор")
                {
                    if (CheckInputLoginAndPassword(login, password, checkPassword, errorMessage))
                    {
                        if ((admin != null) && checkPassword.Password == admin.AdminPassword)
                        {
                            db.Admins.Add(admin);
                            db.SaveChanges();
                            MessageBox.Show("Регистрация прошла успешна", "", MessageBoxButton.OK);
                        }
                        else
                        {
                            MessageBox.Show("Регистрация прошла неуспешно", "Ошибка", MessageBoxButton.OK);
                        }
                    }
                }
                else if (role.Text == "Пользователь")
                {
                    if (CheckInputLoginAndPassword(login, password, checkPassword, errorMessage))
                    {
                        if ((passenger != null) && checkPassword.Password == passenger.PassengerPassword)
                        {
                            db.Passengers.Add(passenger);
                            db.SaveChanges();
                            MessageBox.Show("Регистрация прошла успешна", "", MessageBoxButton.OK);
                        }
                        else
                        {
                            MessageBox.Show("Регистрация прошла неуспешно", "Ошибка", MessageBoxButton.OK);
                        }
                    }
                }
                else
                {
                    errorMessage.Text += "Выберите роль для регистрации!";
                }
            }
        }
    }
}
