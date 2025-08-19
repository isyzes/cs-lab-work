using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cs_lab_work.lab6
{
    public class Lab6
    {
        static string currentPath = Directory.GetCurrentDirectory();
        public static void Run()
        {
            while (true)
            {
                Console.WriteLine($"\nТекущий каталог: {currentPath}");
                Console.WriteLine("Меню:");
                Console.WriteLine("1 – Установить текущий диск/каталог");
                Console.WriteLine("2 – Вывести список каталогов");
                Console.WriteLine("3 – Вывести список файлов");
                Console.WriteLine("4 – Показать содержимое файла по номеру");
                Console.WriteLine("5 – Создать каталог");
                Console.WriteLine("6 – Удалить каталог по номеру (если пустой)");
                Console.WriteLine("7 – Удалить файлы по номерам");
                Console.WriteLine("8 – Найти файлы по дате создания");
                Console.WriteLine("9 – Найти текст в текстовых файлах");
                Console.WriteLine("0 – Выход");
                Console.Write("Выберите пункт: ");

                string input = Console.ReadLine();
                Console.WriteLine();

                Console.Clear();

                switch (input)
                {
                    case "1": ChangeDirectory(); break;
                    case "2": ListDirectories(); break;
                    case "3": ListFiles(); break;
                    case "4": ShowFileContent(); break;
                    case "5": CreateDirectory(); break;
                    case "6": DeleteDirectory(); break;
                    case "7": DeleteFiles(); break;
                    case "8": FindFilesByDate(); break;
                    case "9": FindTextInFiles(); break;
                    case "0": return;
                    default: Console.WriteLine("Неверный ввод!"); break;
                }
            }
        }

        static void ChangeDirectory()
        {
            Console.Write("Введите путь: ");
            string path = Console.ReadLine();
            if (Directory.Exists(path))
            {
                currentPath = path;
            }
            else
            {
                Console.WriteLine("Каталог не найден.");
            }
        }

        static void ListDirectories()
        {
            try
            {
                var dirs = Directory.GetDirectories(currentPath);
                if (dirs.Length == 0) Console.WriteLine("Нет подкаталогов.");
                else
                    for (int i = 0; i < dirs.Length; i++)
                        Console.WriteLine($"{i + 1}. {Path.GetFileName(dirs[i])}");
            }
            catch (Exception ex) { Console.WriteLine($"Ошибка: {ex.Message}"); }
        }

        static void ListFiles()
        {
            try
            {
                var files = Directory.GetFiles(currentPath);
                if (files.Length == 0) Console.WriteLine("Нет файлов.");
                else
                    for (int i = 0; i < files.Length; i++)
                        Console.WriteLine($"{i + 1}. {Path.GetFileName(files[i])}");
            }
            catch (Exception ex) { Console.WriteLine($"Ошибка: {ex.Message}"); }
        }

        static void ShowFileContent()
        {
            var files = Directory.GetFiles(currentPath);
            if (files.Length == 0) { Console.WriteLine("Нет файлов."); return; }

            ListFiles();
            Console.Write("Введите номер файла: ");
            if (int.TryParse(Console.ReadLine(), out int num) && num > 0 && num <= files.Length)
            {
                try
                {
                    Console.WriteLine(File.ReadAllText(files[num - 1]));
                }
                catch (Exception ex) { Console.WriteLine($"Ошибка: {ex.Message}"); }
            }
            else Console.WriteLine("Неверный номер.");
        }

        static void CreateDirectory()
        {
            Console.Write("Введите имя нового каталога: ");
            string name = Console.ReadLine();
            string path = Path.Combine(currentPath, name);
            try
            {
                Directory.CreateDirectory(path);
                Console.WriteLine("Каталог создан.");
            }
            catch (Exception ex) { Console.WriteLine($"Ошибка: {ex.Message}"); }
        }

        static void DeleteDirectory()
        {
            var dirs = Directory.GetDirectories(currentPath);
            if (dirs.Length == 0) { Console.WriteLine("Нет каталогов."); return; }

            ListDirectories();
            Console.Write("Введите номер каталога: ");
            if (int.TryParse(Console.ReadLine(), out int num) && num > 0 && num <= dirs.Length)
            {
                try
                {
                    Directory.Delete(dirs[num - 1]);
                    Console.WriteLine("Каталог удален.");
                }
                catch (Exception ex) { Console.WriteLine($"Ошибка: {ex.Message}"); }
            }
            else Console.WriteLine("Неверный номер.");
        }

        static void DeleteFiles()
        {
            var files = Directory.GetFiles(currentPath);
            if (files.Length == 0) { Console.WriteLine("Нет файлов."); return; }

            ListFiles();
            Console.Write("Введите номера файлов через пробел: ");
            var input = Console.ReadLine().Split();
            foreach (var s in input)
            {
                if (int.TryParse(s, out int num) && num > 0 && num <= files.Length)
                {
                    try
                    {
                        File.Delete(files[num - 1]);
                        Console.WriteLine($"Файл {Path.GetFileName(files[num - 1])} удалён.");
                    }
                    catch (Exception ex) { Console.WriteLine($"Ошибка: {ex.Message}"); }
                }
            }
        }

        static void FindFilesByDate()
        {
            Console.Write("Введите дату (гггг-мм-дд): ");
            if (DateTime.TryParse(Console.ReadLine(), out DateTime date))
            {
                try
                {
                    var files = Directory.GetFiles(currentPath, "*", SearchOption.AllDirectories)
                                        .Where(f => File.GetCreationTime(f).Date == date.Date)
                                        .ToList();
                    if (files.Count == 0) Console.WriteLine("Файлы не найдены.");
                    else foreach (var f in files) Console.WriteLine(f);
                }
                catch (Exception ex) { Console.WriteLine($"Ошибка: {ex.Message}"); }
            }
            else Console.WriteLine("Неверная дата.");
        }

        static void FindTextInFiles()
        {
            Console.Write("Введите текст для поиска: ");
            string text = Console.ReadLine();

            try
            {
                var files = Directory.GetFiles(currentPath, "*.*", SearchOption.AllDirectories);
                var found = new List<string>();
                foreach (var f in files)
                {
                    try
                    {
                        string content = File.ReadAllText(f);
                        if (content.Contains(text, StringComparison.OrdinalIgnoreCase))
                            found.Add(f);
                    }
                    catch { } // Игнорируем ошибки чтения
                }
                if (found.Count == 0) Console.WriteLine("Файлы не найдены.");
                else foreach (var f in found) Console.WriteLine(f);
            }
            catch (Exception ex) { Console.WriteLine($"Ошибка: {ex.Message}"); }
        }
        
        
    }
}