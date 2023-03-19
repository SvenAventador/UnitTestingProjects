using System;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using UnitTestingApplication.Models;

namespace UnitTestingApplication.Classes
{
    /// <summary>
    /// Методы для будущего тестирования.
    /// </summary>
    public static class Methods
    {
        /// <summary>
        /// Авторизация пользователя. 
        /// </summary>
        /// <param name="login"> Логин пользователя. </param>
        /// <param name="password"> Пароль пользователя. </param>
        /// <returns> Результат авторизации. </returns>
        public static string AuthUser(string login, string password)
        {
            var error = new StringBuilder();

            if (string.IsNullOrEmpty(login))
                error.AppendLine("Пожалуйста, введите логин!");
            if (!Validation.ValidateEmail(login))
                error.AppendLine("Пожалуйста, введите корректную почту!");
            if (string.IsNullOrEmpty(password))
                error.AppendLine("Пожалуйста, введите пароль!");
            if (!string.IsNullOrEmpty(Validation.ValidatePassword(password)))
                error.AppendLine(Validation.ValidatePassword(password));

            if (error.Length > 0)
            {
                MessageBox.Show(error.ToString(),
                                "Внимание!",
                                MessageBoxButton.OK,
                                MessageBoxImage.Error);
                return "Failed!";
            }

            var user = UnitTestingDatabaseEntities.GetContext()
                                                  .Users
                                                  .FirstOrDefault(x => (x.UserLogin == login) &&
                                                                       (x.UserPassword == password));

            if (user == null)
            {
                MessageBox.Show("Не правильно введен логин или пароль. Проверьте свои данные!",
                                "Внимание!",
                                MessageBoxButton.OK,
                                MessageBoxImage.Error);
                return "Failed!";
            }

            if (user.UserRole == 0)
            {
                Manager.MainFrame.Navigate(new Pages.UserPage.UserPage());
                Manager.CurrentUser = user;
                return "Success!";
            }

            if (user.UserRole == 1)
            {
                Manager.MainFrame.Navigate(new Pages.AdminPages.AdminPage());
                Manager.CurrentUser = user;
                return "Success!";
            }

            return "Failed!";
        }

        /// <summary>
        /// Регистрация пользователя. 
        /// </summary>
        /// <param name="login"> Логин пользователя. </param>
        /// <param name="password"> Пароль пользователя. </param>
        /// <returns> Результат регистрации. </returns>
        public static string RegUser(string login, string password)
        {
            var error = new StringBuilder();

            if (string.IsNullOrEmpty(login))
                error.AppendLine("Пожалуйста, введите логин!");
            if (!Validation.ValidateEmail(login))
                error.AppendLine("Пожалуйста, введите корректную почту!");
            if (string.IsNullOrEmpty(password))
                error.AppendLine("Пожалуйста, введите пароль!");
            if (!string.IsNullOrEmpty(Validation.ValidatePassword(password)))
                error.AppendLine(Validation.ValidatePassword(password));

            if (error.Length > 0)
            {
                MessageBox.Show(error.ToString(),
                                "Внимание!",
                                MessageBoxButton.OK,
                                MessageBoxImage.Error);
                return "Failed!";
            }

            var user = new Users()
            {
                UserLogin = login,
                UserPassword = password
            };

            try
            {
                UnitTestingDatabaseEntities.GetContext()
                                           .Users
                                           .Add(user);
                UnitTestingDatabaseEntities.GetContext().SaveChanges();
                MessageBox.Show("Успешная регистрация!",
                                "Успех!",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
                Manager.CurrentUser = user;
                Manager.MainFrame.Navigate(new Pages.UserPage.UserPage());
                return "Success!";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(),
                                "Внимание!",
                                MessageBoxButton.OK,
                                MessageBoxImage.Error);
                return "Failed!";
            }
        }

        /// <summary>
        /// Вывод данных в таблицу.
        /// </summary>
        /// <returns> Результат вывода данных таблицу.</returns>
        public static string GetContextIntoDataGrid(DataGrid DBGridModel)
        {
            try
            {
                DBGridModel.ItemsSource = UnitTestingDatabaseEntities.GetContext()
                                                                     .Goods
                                                                     .OrderBy(x => x.GoodsName)
                                                                     .ToList();
                return "Success!";
            }
            catch(Exception)
            {
                return "Failed!";
            }
        }

        /// <summary>
        /// Добавление / изменение данных в Базу Данных. 
        /// </summary>
        /// <param name="currentGoods"> Таблица с товарами. </param>
        /// <returns> Результат добавления / изменения данных. </returns>
        public static string AddAndEditData(Goods currentGoods, TextBox imagePath)
        {
            var error = new StringBuilder();

            currentGoods.GoodsImage = imagePath.Text;

            if (string.IsNullOrEmpty(currentGoods.GoodsName))
                error.AppendLine("Пожалуйста, введите имя!");
            if (currentGoods.GoodsPrice < 1000)
                error.AppendLine("Извините, но цена не может быть меньше 1000 рублей!");
            if (currentGoods.GoodsPrice < 0)
                error.AppendLine("Извините, но количество товара не может быть отрицательным!");
            if (string.IsNullOrEmpty(currentGoods.GoodsImage))
                error.AppendLine("Пожалуйста, выберите изображение!");

            if (error.Length > 0)
            {
                MessageBox.Show(error.ToString(),
                                "Внимание!",
                                MessageBoxButton.OK,
                                MessageBoxImage.Error);
                return "Failed!";
            }
            
            if (currentGoods.Id == 0)
                UnitTestingDatabaseEntities.GetContext()
                                           .Goods
                                           .Add(currentGoods);

            try
            {
                UnitTestingDatabaseEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена успешно!",
                                "Внимание!",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
                Manager.MainFrame.GoBack();
                return "Success!";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(),
                                "Внимание!",
                                MessageBoxButton.OK,
                                MessageBoxImage.Error);
                return "Failed!";
            }
        }
    }
}
