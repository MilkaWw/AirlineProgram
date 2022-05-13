using System.Windows;
using System.Windows.Controls;

namespace AirlineProgram.View.Windows
{
    public partial class WindowPrintTicket : Window
    {
        public WindowPrintTicket()
        {
            InitializeComponent();
        }

        private void PrintTicket(object sender, RoutedEventArgs e) //Кнопка печати билета
        {
            try
            {
                (sender as Button).Visibility = Visibility.Hidden;  //Скрываем кнопку "Печать", для того чтобы отобразить билет без нее.
                PrintDialog printDialog = new PrintDialog();
                if (printDialog.ShowDialog() == true)   //Показываем меню поиска принтера
                {
                    printDialog.PrintVisual(windowPrint, "Ticket");
                }
            }
            finally
            {
                (sender as Button).Visibility = Visibility.Visible; //Делаем кнопку "Печать" видимой, для того чтобы повторить нажатие на нее.
            }
        }
    }
}
