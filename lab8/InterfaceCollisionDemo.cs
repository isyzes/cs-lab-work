using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cs_lab_work.lab8
{
    public interface IInterface1
    {
        void Print();
        void Mult(double factor);
    }

    public interface IInterface2
    {
        void Print();
        void Up();
    }

    public class Class1 : IInterface1, IInterface2
    {
        private double number;
        private string text;

        public Class1(double n, string t)
        {
            number = n;
            text = t;
        }

        public void Print()
        {
            Console.WriteLine($"[СКЛЕИВАНИЕ] Number={number}, Text={text}");
        }

        public void Mult(double factor)
        {
            number *= factor;
            Console.WriteLine($"[IInterface1.Mult] Number={number}");
        }

        void IInterface2.Print()
        {
            Console.WriteLine($"[ЯВНАЯ РЕАЛИЗАЦИЯ для IInterface2] Number={number}, Text={text}");
        }

        public void Up()
        {
            text = text.ToUpper();
            Console.WriteLine($"[IInterface2.Up] Text={text}");
        }

        public void PrintAsInterface2()
        {
            ((IInterface2)this).Print();
        }
    }

    public class Class2 : IInterface2
    {
        private string text;

        public Class2(string t)
        {
            text = t;
        }

        public void Print()
        {
            Console.WriteLine($"[Class2.Print] Text={text}");
        }

        public void Up()
        {
            text = text.ToUpper();
            Console.WriteLine($"[Class2.Up] Text={text}");
        }
    }


    public class InterfaceCollisionDemo
    {
        public static void Run()
        {
            Class1 obj1 = new Class1(10, "hello");

            Console.WriteLine("=== СПОСОБ 1: Склеивание ===");
            obj1.Print();

            Console.WriteLine("\n=== СПОСОБ 2: Явная реализация ===");
            ((IInterface2)obj1).Print();

            Console.WriteLine("\n=== СПОСОБ 3: Переименование ===");
            obj1.PrintAsInterface2(); 

            Console.WriteLine("\n=== Остальные методы ===");
            obj1.Mult(2.7);
            obj1.Up();

            Console.WriteLine("\n=== Class2 ===");
            IInterface2 obj2 = new Class2("world");
            obj2.Print();
            obj2.Up();
        }

    }
}