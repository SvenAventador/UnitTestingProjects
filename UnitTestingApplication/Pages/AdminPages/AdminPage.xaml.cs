using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using UnitTestingApplication.Classes;
using UnitTestingApplication.Models;

namespace UnitTestingApplication.Pages.AdminPages
{
    /// <summary>
    /// Логика взаимодействия для AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        public AdminPage()
        {
            InitializeComponent();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddAndEditPage(null));
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddAndEditPage((sender as Button).DataContext as Goods));
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var goodsToRemove = DBGridModel.SelectedItems.Cast<Goods>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {goodsToRemove.Count()} элементов ?", 
                                "Внимание", 
                                MessageBoxButton.YesNo,
                                MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    UnitTestingDatabaseEntities.GetContext()
                                               .Goods
                                               .RemoveRange(goodsToRemove);
                    UnitTestingDatabaseEntities.GetContext()
                                               .SaveChanges();
                    MessageBox.Show("Данные успешно удалены!",
                                    "Внимени!",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Information);

                    DBGridModel.ItemsSource = UnitTestingDatabaseEntities.GetContext()
                                                                         .Goods
                                                                         .OrderBy(x => x.GoodsName)
                                                                         .ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(),
                                    "Внимание!",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Error);
                }
            }
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                UnitTestingDatabaseEntities.GetContext()
                                           .ChangeTracker
                                           .Entries()
                                           .ToList()
                                           .ForEach(p => p.Reload());
                DBGridModel.ItemsSource = UnitTestingDatabaseEntities.GetContext()
                                                                     .Goods
                                                                     .OrderBy(x => x.GoodsName)
                                                                     .ToList();
            }
        }
    }
}
