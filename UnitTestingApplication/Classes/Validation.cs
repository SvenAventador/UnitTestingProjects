using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace UnitTestingApplication.Classes
{
    /// <summary>
    /// Валидация данных.
    /// </summary>
    public static class Validation
    {
        /// <summary>
        /// Валидация почтового адреса.
        /// </summary>
        /// <param name="value"> Введенная почта. </param>
        /// <returns> Валидность почты. </returns>
        public static bool ValidateEmail(string value) => Regex.IsMatch(value, @"(\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*)");

        /// <summary>
        /// Валидация длины пароля.
        /// </summary>
        /// <param name="value"> Введенный пароль. </param>
        /// <returns> Валидность длины. </returns>
        public static bool ValidateLength(string value) => value.Length > 6;

        /// <summary>
        /// Валидация пароля.
        /// </summary>
        /// <param name="value"> Введенный пароль. </param>
        /// <returns> Валидность пароля. </returns>
        public static string ValidatePassword(string value)
        {
            var enLetter = true;
            var numLetter = false;
            var specialSymbols = false;
            var symbols = "(!@#$%^&*_-+=)";

            var error = new StringBuilder();

            for (var i = 0; i < value.Length; i++)
            {
                if (value[i] >= 'А' && value[i] <= 'Я')
                {
                    enLetter = false;
                    break;
                }

                if (char.IsNumber(value[i]))
                    numLetter = true;

                if (symbols.Contains(value[i]))
                    specialSymbols = true;

            }

            if (!enLetter)
                error.AppendLine("В пароле допускаются только английские буквы!");
            if (!numLetter)
                error.AppendLine("В пароле должна присутсовать хотя бы одна цифра!");
            if (!specialSymbols)
                error.AppendLine($"Пароль должен содержать один из следующих символов: {symbols}");

            return error.ToString();
        }
    }
}
