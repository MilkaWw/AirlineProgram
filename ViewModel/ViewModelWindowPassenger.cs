using AirlineProgram.ModelDB;
using System.Linq;

namespace AirlineProgram.ViewModel
{
    public class ViewModelWindowPassenger
    {
        #region Поля
        private static string FullNamePassenger;//Полное имя пассажира(Главное меню)
        public static string loginPassenger; //Здесь логин(Пассажира)
        #endregion

        public static string LoginPassenger//Получение информации о пассажире через веденный логин
        {
            get => FullNamePassenger;
            set
            {
                using (DbAirlineEntities db = new DbAirlineEntities())
                {
                    var passenger = (from sqlpassenger in db.Passengers.ToList()
                                    where sqlpassenger.PassengerLogin == value
                                    select sqlpassenger).FirstOrDefault();

                    loginPassenger = passenger.PassengerLogin;
                    FullNamePassenger = passenger.Firstname + " " + passenger.Lastname;
                }
            }
        }
    }
}
