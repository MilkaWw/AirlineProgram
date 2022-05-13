using AirlineProgram.ModelDB;
using System.Linq;

namespace AirlineProgram.ViewModel
{
    public class ViewModelWindowAdmin
    {
        #region Поля
        private static string FullNameAdmin;//Полное имя админа(Главное меню)
        public static string loginAdmin; // Здесь храниться логин(Админа)
        #endregion

        public static string LoginAdmin//Получение информации о админе через веденный логин
        {
            get => FullNameAdmin;
            set
            {
                using (DbAirlineEntities db = new DbAirlineEntities())
                {
                    var admin = (from sqladmin in db.Admins.ToList()
                                 where sqladmin.AdminLogin == value
                                 select sqladmin).FirstOrDefault();

                    loginAdmin = admin.AdminLogin;
                    FullNameAdmin = admin.Firstname + " " + admin.Lastname;
                }
            }
        }
    }
}
