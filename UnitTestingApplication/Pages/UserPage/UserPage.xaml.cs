using System.Windows.Controls;
using UnitTestingApplication.Classes;

namespace UnitTestingApplication.Pages.UserPage
{
    /// <summary>
    /// Логика взаимодействия для UserPage.xaml
    /// </summary>
    public partial class UserPage : Page
    {
        public UserPage()
        {
            InitializeComponent();
            Methods.GetContextIntoDataGrid(DBGridModel);
        }
    }
}
