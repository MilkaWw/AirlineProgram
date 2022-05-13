using AirlineProgram.View.Pages;
using System.Windows;

namespace AirlineProgram.View.Windows
{
    public partial class MainWindowPassenger : Window
    {
        public MainWindowPassenger()
        {
            InitializeComponent();
        }

        private void Button_Click_Exit(object sender, RoutedEventArgs e)
        {
            WindowLogin windowLogin = new WindowLogin();
            this.Close();
            windowLogin.Show();
        }

        private void Button_Click_ViewTicket(object sender, RoutedEventArgs e)
        {
            frameNavigPage.Navigate(new PageViewTickets());
        }

        private void Button_Click_BuyTicket(object sender, RoutedEventArgs e)
        {
            frameNavigPage.Navigate(new PageBuyTickets());

        }

        private void Button_Click_Settings(object sender, RoutedEventArgs e)
        {
            frameNavigPage.Navigate(new PageSettingsPassenger());
        }
    }
}
