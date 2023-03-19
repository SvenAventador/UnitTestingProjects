using System;
using System.Windows;
using UnitTestingApplication.Classes;

namespace UnitTestingApplication
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new Pages.AdminPages.AdminPage());
            Manager.MainFrame = MainFrame;
        }

        /// <summary>
        /// Вернуться на предыдущую страницу.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.GoBack();
        }

        /// <summary>
        /// Корректное отображение кнопки "Назад".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainFrame_ContentRendered(object sender, EventArgs e)
        {
            if (MainFrame.CanGoBack)           
                BtnBack.Visibility = Visibility.Visible;
            else            
                BtnBack.Visibility = Visibility.Hidden;           
        }
    }
}
