using System.Windows;
using System.Windows.Controls;
using UnitTestingApplication.Classes;

namespace UnitTestingApplication.Pages.AuthenticationPages
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        public AuthorizationPage()
        {
            InitializeComponent();
        }

        private void BtnReg_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new RegistrationPage());
        }

        private void BtnAuth_Click(object sender, RoutedEventArgs e)
        {
            Methods.AuthUser(LoginTB.Text, PasswordTB.Password);
        }
    }
}
