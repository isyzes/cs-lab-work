namespace lab1_app
{
    public class Lab1Task1 {

        private readonly Random random = new Random();
        private static string MIN_MESSAGE = "Введите минимальное значение:";
        private static string MAX_MESSAGE = "Введите максимальное значение:";
        private static string CURRENT_ARRAY_MESSAGE  = "Текущий массив:";

        public void Run() {
            Console.WriteLine("Задание №1 Одномерный массив целых чисел.");
            int arraySize = ReadIntFromConsole("Введите размер массива:");
            int min = ReadIntFromConsole(MIN_MESSAGE);
            int max = ReadIntFromConsole(MAX_MESSAGE);
            if(min > max) {
                Console.WriteLine("Некорректный диапазон: min не может быть больше max");
                return;
            }
            int[] array = GenerateArray(arraySize, min, max);
            PrintArray(array);
            Run(array);
        }

        private void Run(int[] array) {
            int maxPosition = 0;
            int maxValue = array[maxPosition];

            int minPosition = 0;
            int minValue = array[minPosition];

            for(int i = 0; i < array.Length; i++) {
                int value = array[i];
                if(value > maxValue) {
                    maxPosition = i;
                    maxValue = value;           
                }

                if(minValue > value) {
                    minPosition = i;
                    minValue = value;
                }
            }

            array[maxPosition] = minValue;
            array[minPosition] = maxValue;
            Console.WriteLine("");
            PrintArray(array);
        }

        private int[] GenerateArray(int arraySize, int min, int max) {
            int[] array = new int[arraySize];

            for(int i = 0; i < array.Length; i++) {
                array[i] = GetRandomInt(min, max + 1);
            }

            return array;
        }

        private void PrintArray(int[] array, bool isLog = true) {
            if(isLog) {
                Console.WriteLine(CURRENT_ARRAY_MESSAGE);
            }
            
            Console.Write("[");
            for(int i = 0; i < array.Length; i++) {
                Console.Write(array[i]);
                if(i < array.Length - 1) {
                    Console.Write(", ");
                }
            }
            Console.Write("]");
        }


        private int ReadIntFromConsole(string message) {
            while(true) {
                Console.WriteLine(message);
                string? input = Console.ReadLine();

                bool result = int.TryParse(input, out var number);

                if(result) {
                    return number;
                } else {
                    Console.WriteLine($"'{input}' - не является числолом, повторите введите число: ");
                }
            }   
        }

        public int GetRandomInt(int min , int max) {
            return random.Next(min, max);
        }

    }
    
    public class Lab1Task2 {
        private readonly Random random = new Random();
        private static string MIN_MESSAGE = "Введите минимальное значение:";
        private static string MAX_MESSAGE = "Введите максимальное значение:";
        private static string CURRENT_ARRAY_MESSAGE  = "Текущий массив:";

        public void Run() {
            Console.WriteLine("Задание №2 Квадратный массив.");
            
            int arraySize = ReadIntFromConsole("Введите размер квадратного массива:");
            int min = ReadIntFromConsole(MIN_MESSAGE);
            int max = ReadIntFromConsole(MAX_MESSAGE);
            if(min > max) {
                Console.WriteLine("Некорректный диапазон: min не может быть больше max");
                return;
            }
            int[,] array = GenerateSquareArray(arraySize, min, max);
            PrintSquareArray(array);
            Run(array);
        }

        private void Run(int[,] array) {
            int n = array.GetLength(0);
            double sum = 0;
            int count = 0;

            for (int i = 0; i < n; i++) {
                for (int j = 0; j < n; j++) {
                    if (i + j > n - 1) {
                        sum += array[i, j];
                        count++;
                    }
                }
            }

            double average = count > 0 ? sum / count : 0;
            Console.WriteLine($"Среднее арифметическое элементов под побочной диагональю: {average}");
        }

        private void PrintSquareArray(int[,] array) {
            Console.WriteLine(CURRENT_ARRAY_MESSAGE);

            int rows = array.GetUpperBound(0) + 1;
            int columns = array.Length / rows;

            for(int i = 0; i < rows; i++) {
                Console.Write("[");
                for(int j = 0; j < columns; j++) {
                    Console.Write(array[i, j]);
                    if(j < columns - 1) {
                        Console.Write(", ");
                    }
                }
                Console.Write("]");
                Console.WriteLine("");
            }
        }

        private int ReadIntFromConsole(string message) {
            while(true) {
                Console.WriteLine(message);
                string? input = Console.ReadLine();

                bool result = int.TryParse(input, out var number);

                if(result) {
                    return number;
                } else {
                    Console.WriteLine($"'{input}' - не является числолом, повторите введите число: ");
                }
            }   
        }

        private int[,] GenerateSquareArray(int arraySize, int min, int max) {
            int[,] array = new int[arraySize, arraySize];
            int rows = array.GetUpperBound(0) + 1;
            int columns = array.Length / rows;

            for(int i = 0; i < rows; i++) {
                for(int j = 0; j < columns; j++) {
                    array[i, j] = GetRandomInt(min, max + 1);
                }
            }

            return array;
        }

        public int GetRandomInt(int min , int max) {
            return random.Next(min, max);
        }

    }
    public class Lab1Task3 {
        private readonly Random random = new Random();
        private static string MIN_MESSAGE = "Введите минимальное значение:";
        private static string MAX_MESSAGE = "Введите максимальное значение:";
        private static string CURRENT_ARRAY_MESSAGE  = "Текущий массив:";        

        public void Run() {
            Console.WriteLine("Задание №3 Зубчатый массив");
            int arraySize = ReadIntFromConsole("Введите размер зубчатого массива:");
            int min = ReadIntFromConsole(MIN_MESSAGE);
            int max = ReadIntFromConsole(MAX_MESSAGE);
            if(min > max) {
                Console.WriteLine("Некорректный диапазон: min не может быть больше max");
                return;
            }
            int[][] array = GenerateSerratedArray(arraySize, min, max);
            PrintSerratedArray(array);
            Run(array);
        }

        public void Run(int[][] array) {
            int[] resultArray = new int[array.Length];

            for(int i = 0; i < array.Length; i++) {
                resultArray[i] = array[i].Length;
            }

            PrintArray(resultArray);
        }

        

        private void PrintSerratedArray(int[][] array) {
            Console.WriteLine(CURRENT_ARRAY_MESSAGE);

            for(int i = 0; i < array.Length; i++) {
                PrintArray(array[i], false);
                Console.WriteLine("");
            }
        }


        private void PrintArray(int[] array, bool isLog = true) {
            if(isLog) {
                Console.WriteLine(CURRENT_ARRAY_MESSAGE);
            }
            
            Console.Write("[");
            for(int i = 0; i < array.Length; i++) {
                Console.Write(array[i]);
                if(i < array.Length - 1) {
                    Console.Write(", ");
                }

            }
            Console.Write("]");
        }

        private int[] GenerateArray(int arraySize, int min, int max) {
            int[] array = new int[arraySize];

            for(int i = 0; i < array.Length; i++) {
                array[i] = GetRandomInt(min, max + 1);
            }

            return array;
        }

         private int[][] GenerateSerratedArray(int arraySize, int min, int max) {
            int[][] array = new int[arraySize][];

            for (int i = 0; i < array.Length; i++) {
                int size = GetRandomInt(1, arraySize + 1);
                array[i] = new int[size];
                array[i] = GenerateArray(size, min, max);
            }

            return array;
        }

        public int GetRandomInt(int min , int max) {
            return random.Next(min, max);
        }

        private int ReadIntFromConsole(string message) {
            while(true) {
                Console.WriteLine(message);
                string? input = Console.ReadLine();

                bool result = int.TryParse(input, out var number);

                if(result) {
                    return number;
                } else {
                    Console.WriteLine($"'{input}' - не является числолом, повторите введите число: ");
                }
            }   
        }
    }

    public class Lab1Task4 {
        public static int Run(params int[] numbers) {
            return numbers.Length;
        }
    }
}