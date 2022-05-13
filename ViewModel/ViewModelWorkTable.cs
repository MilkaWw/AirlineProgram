using AirlineProgram.ModelDB;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace AirlineProgram.ViewModel
{
    public class ViewModelWorkTable : INotifyPropertyChanged
    {
        private static ObservableCollection<Flights> collectionFlights;
        public static ObservableCollection<Flights> CollectionFlights
        {
            get => collectionFlights;
            set => collectionFlights = value;
        }

        public static Flights selectedFlights;
        public Flights SelectedFlights
        {
            get => selectedFlights;
            set
            {
                selectedFlights = value;
                OnPropertyChanged("SelectedFlights");
            }
        }

        private static ObservableCollection<Passengers> collectionPassengers;
        public static ObservableCollection<Passengers> CollectionPassengers
        {
            get => collectionPassengers;
            set => collectionPassengers = value;
        }

        public static Passengers selectedPassengers; 
        public Passengers SelectedPassengers
        {
            get => selectedPassengers;
            set
            {
                selectedPassengers = value;
                OnPropertyChanged("SelectedPassengers");
            }
        }   //Выбранный пользователь в DataGrid

        public ViewModelWorkTable()
        {
            CollectionFlights = new ObservableCollection<Flights>(DbAirlineEntities.GetContext().Flights.ToList()); 
            CollectionPassengers = new ObservableCollection<Passengers>(DbAirlineEntities.GetContext().Passengers.ToList());
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler CanExecuteChanged;

        protected void OnPropertyChanged([CallerMemberName] string prop = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
