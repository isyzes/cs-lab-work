using System.Text;
using System.Text.RegularExpressions;

namespace lab2_app
{
    public class Lab2Task1
    {
        public static bool Run(string input) {
            if (string.IsNullOrEmpty(input)) {
                return false;
            }

            for (int i = 0; i < input.Length - 1; i++) {
                if (input[i] == input[i + 1]) {
                    return true;
                }
            }

            return false;
        }
    }

    public class Lab2Task2
    {
        public void Run(params string[] input) {
            string combined;
            int bufferSize = ProcessStrings(out combined, input);

            Console.WriteLine($"Результирующая строка: {combined}");
            Console.WriteLine($"Размер буфера: {bufferSize}");
        }


        private int ProcessStrings(out string result, params string[] input) 
        {
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < input.Length; i++) {
                stringBuilder.Append(ReverseString(input[i]));
                stringBuilder.Append(';');
            }

            stringBuilder.Capacity = stringBuilder.Length;
            result = stringBuilder.ToString();

            return stringBuilder.Capacity;
        }

        string ReverseString(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;
            
            char[] charArray = input.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }

    public class Lab2Task3
    {
        public static void Run(string message, char character)
        {
            if (string.IsNullOrEmpty(message))
            {
                Console.WriteLine("Сообщение пустое");
                return;
            }

            string escapedChar = Regex.Escape(character.ToString());
            
            string pattern = $@"\b\w*{escapedChar}\b";
            
            string result = Regex.Replace(message, pattern, string.Empty);
            
            result = Regex.Replace(result, @"\s{2,}", " ").Trim();
            
            Console.WriteLine($"Результат: {result}");
        }
    }

    public class Lab2Task4
    {
        public static int Run(string dateTimeString) 
        {
            DateTime currentDate;

            if (!DateTime.TryParse(dateTimeString, out currentDate))
            {
                Console.WriteLine("Некорректный формат даты и времени");
                return -100005;
            }

            DateTime nextNewYear = new DateTime(currentDate.Year, 1, 1).AddYears(1);

            TimeSpan timeLeft = nextNewYear - currentDate;

            return (int)timeLeft.TotalMinutes;
        }
    }
}