using System.Windows.Controls;
using UnitTestingApplication.Models;

namespace UnitTestingApplication.Classes
{
    /// <summary>
    /// Взаимодействие с объектами.
    /// </summary>
    public static class Manager
    {
        /// <summary>
        /// Навигация по страницам.
        /// </summary>
        public static Frame MainFrame { get; set; }

        /// <summary>
        /// Получение текущего пользователя.
        /// </summary>
        public static Users CurrentUser { get; set; }

        /// <summary>
        /// Получение роли пользователя.
        /// </summary>
        public static int CheckUserRole => CurrentUser.UserRole;
    }
}
