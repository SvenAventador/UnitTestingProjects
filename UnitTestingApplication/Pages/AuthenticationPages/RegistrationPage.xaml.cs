using System.Windows;
using System.Windows.Controls;
using UnitTestingApplication.Classes;

namespace UnitTestingApplication.Pages.AuthenticationPages
{
    /// <summary>
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }

        private void BtnAuth_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AuthorizationPage());
        }

        private void BtnReg_Click(object sender, RoutedEventArgs e)
        {
            Methods.RegUser(LoginTB.Text, PasswordTB.Password);
        }
    }
}
