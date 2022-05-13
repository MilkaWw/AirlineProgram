using AirlineProgram.View.Pages;
using System.Windows;

namespace AirlineProgram.View.Windows
{
    public partial class MainWindowAdmin : Window
    {
        public MainWindowAdmin()
        {
            InitializeComponent();
        }

        private void Button_Click_WorkTable(object sender, RoutedEventArgs e)
        {
            frameNavigPage.Navigate(new PageWorkTable());
        }
        private void Button_Click_Exit(object sender, RoutedEventArgs e)
        {
            WindowLogin windowLogin = new WindowLogin();
            this.Close();
            windowLogin.Show();
        }

        private void Button_Click_Settings(object sender, RoutedEventArgs e)
        {
            frameNavigPage.Navigate(new PageSettingsAdmin());

        }
    }
}
