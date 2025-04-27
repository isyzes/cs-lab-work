namespace lab1_app
{
    public class Lab1
    {
        private readonly Random random = new Random();

        public void RunTask1() {
            int arraySize = ReadArraySize();
            int min = ReadMinValue();
            int max = ReadMaxValue();
            int[] array = GenerateArray(arraySize, min, max);
            PrintArray(array);
        }

        public void RunTask2() {
            int arraySize = ReadSquareArraySize();
            int min = ReadMinValue();
            int max = ReadMaxValue();
            int[,] array = GenerateSquareArray(arraySize, min, max);
            PrintSquareArray(array);
        }

        public void RunTask3() {
            int arraySize = ReadSerratedArraySize();
            int min = ReadMinValue();
            int max = ReadMaxValue();
            int[][] array = GenerateSerratedArray(arraySize, min, max);
            PrintSerratedArray(array);
        }

        private void PrintSquareArray(int[,] array) {
            Console.WriteLine("Текущий массив:");

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

        private void PrintSerratedArray(int[][] array) {
            Console.WriteLine("Текущий массив:");

            for(int i = 0; i < array.Length; i++) {
                PrintArray(array[i], false);
                Console.WriteLine("");
            }
        }


        private void PrintArray(int[] array, bool isLog = true) {
            if(isLog) {
                Console.WriteLine("Текущий массив:");
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

        private int ReadArraySize() {
            Console.WriteLine("Введите размер массива:");
            return ReadIntFromConsole();
        }

        private int ReadSquareArraySize() {
            Console.WriteLine("Введите размер квадратного массива:");
            return ReadIntFromConsole();
        }

        private int ReadSerratedArraySize() {
            Console.WriteLine("Введите размер зубчатого массива:");
            return ReadIntFromConsole();
        }

        private int ReadMaxValue() {
            Console.WriteLine("Введите максимальное значение:");
            return ReadIntFromConsole();
        }

        private int ReadMinValue() {
            Console.WriteLine("Введите минимальное значение:");
            return ReadIntFromConsole();
        }

        private int ReadIntFromConsole() {
            while(true) {
                string? input = Console.ReadLine();

                bool result = int.TryParse(input, out var number);

                if(result == true) {
                    return number;
                } else {
                    Console.WriteLine($"'{input}' - не является числолом, повторите введите число: ");
                }
            }   
        }
    }
}