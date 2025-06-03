
namespace cs_lab_work.lab5
{
    public class Runner
    {
        public static void RunLab5Task2()
        {
            var entry1 = new EmailEntry("ivan@example.com", "Ivan");
            var entry2 = new EmailEntry("maria@example.com", "Maria");
            var entry3 = new EmailEntry("peter@example.com", "Peter");

            var list = new MailingList();

            list += entry1;
            list += entry2;
            list += entry3;

            Console.WriteLine(list);

            var maria = list["Maria"];
            Console.WriteLine($"Найден адрес Maria: {maria}");

            list -= entry2;

            Console.WriteLine("После удаления:");
            Console.WriteLine(list);
            
        }
        
        public static void RunLab5Task1()
        {
            var eq1 = new QuadraticEquation(1, -3, 2);
            var eq2 = new QuadraticEquation(-1, 2, 1);
            var eq3 = new QuadraticEquation(1, 0, 1);

            Console.WriteLine("--------Конструкторы и ToString--------");
            Console.WriteLine(eq1);
            Console.WriteLine(eq2);
            Console.WriteLine(eq3);

            Console.WriteLine("\n--------Корни--------");
            Console.WriteLine(string.Join(", ", eq1.FindRoots()));
            Console.WriteLine(string.Join(", ", eq2.FindRoots()));
            Console.WriteLine(string.Join(", ", eq3.FindRoots()));

            Console.WriteLine("\n--------Арифметика--------");
            Console.WriteLine(eq1 + 1);
            Console.WriteLine(eq2 - 2);
            Console.WriteLine(eq1 * 2);
            Console.WriteLine(eq2 / 1);

            Console.WriteLine("\n--------Инкремент/Декремент--------");
            Console.WriteLine(++eq1);
            Console.WriteLine(--eq2);

            Console.WriteLine("\n--------Индексатор--------");
            Console.WriteLine($"eq1[0] = {eq1[0]}, eq1[1] = {eq1[1]}, eq1[2] = {eq1[2]}");

            Console.WriteLine("\n--------Сравнение--------");
            Console.WriteLine($"eq1 == eq2: {eq1 == eq2}");
            Console.WriteLine($"eq1 != eq2: {eq1 != eq2}");
            Console.WriteLine($"eq1 > eq2: {eq1 > eq2}");
            Console.WriteLine($"eq1 < eq2: {eq1 < eq2}");

            Console.WriteLine("\n--------true / false--------");
            if (eq3)
                Console.WriteLine("eq3 имеет корни");
            else
                Console.WriteLine("eq3 не имеет корней");

            Console.WriteLine("\n--------Преобразование типов--------");
            QuadraticEquation eq4 = (QuadraticEquation)5; // 5x^2
            int aCoeff = (int)eq1;
            Console.WriteLine($"eq4: {eq4}");
            Console.WriteLine($"(int)eq1: {aCoeff}");
        }
    }
}