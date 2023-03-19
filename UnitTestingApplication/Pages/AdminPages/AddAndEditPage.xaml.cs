using System.Windows.Controls;
using System.Windows;
using UnitTestingApplication.Models;
using UnitTestingApplication.Classes;
using Microsoft.Win32;
using System.IO;
using static System.Net.Mime.MediaTypeNames;
using static System.Net.WebRequestMethods;

namespace UnitTestingApplication.Pages.AdminPages
{
    /// <summary>
    /// Логика взаимодействия для AddAndEditPage.xaml
    /// </summary>
    public partial class AddAndEditPage : Page
    {
        private readonly Goods _currentGoods = new Goods();
        public AddAndEditPage(Goods goods)
        {
            InitializeComponent();

            if (goods != null)
                _currentGoods = goods;

            DataContext = _currentGoods;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            Methods.AddAndEditData(_currentGoods, FilePath);
        }

        private void SelectImageBtn_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog()
            {
                DefaultExt = "*.png;*.jpg",
                Filter = "Image files (*.jpg, *.png) | *.jpg; *.png",
                Title = "Выберите файл"
            };

            if (!(openFileDialog.ShowDialog()) == true)
            {
                return;
            }

            FilePath.Text = openFileDialog.FileName;
        }
    }
}
