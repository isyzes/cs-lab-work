using System;

namespace DelegatesAndEventsDemo
{
    public delegate void TalkDelegate();
    public delegate void GainWeightDelegate(Pet pet, int value);

    public class Pet
    {
        private TalkDelegate talk;

        public int Weight { get; private set; }
        public int Age { get; private set; }

        private EventHandler<string> weightOrAgeEvent;

        public event EventHandler<string> WeightOrAgeEvent
        {
            add { weightOrAgeEvent += value; }
            remove { weightOrAgeEvent -= value; }
        }

        public Pet(int weight, int age)
        {
            Weight = weight;
            Age = age;
        }

        public void SetTalk(TalkDelegate t)
        {
            talk = t;
        }

        public void Speak()
        {
            talk?.Invoke();
        }

        public void AddTalk(TalkDelegate t)
        {
            talk += t;
        }

        public bool HasSameTalk(Pet other)
        {
            return talk == other.talk;
        }

        public void GainWeight(GainWeightDelegate g, int value)
        {
            g?.Invoke(this, value);

            if (Weight >= 50)
                weightOrAgeEvent?.Invoke(this, $"{nameof(Pet)} переел! Вес: {Weight}");
        }

        public void Birthday()
        {
            Age++;
            if (Age >= 15)
                weightOrAgeEvent?.Invoke(this, $"{nameof(Pet)} состарился! Возраст: {Age}");
        }

        public void AddWeight(int x) => Weight += x;
        public void MultiplyWeight(int x) => Weight *= x;
    }

    class Doctor
    {
        public void OnPetIll(object sender, string msg)
        {
            Console.WriteLine($"Доктор: Питомец заболел! {msg}");
        }
    }

    class Death
    {
        public void OnPetDied(object sender, string msg)
        {
            Console.WriteLine($"Смерть пришла: {msg}");
        }
    }

    class ProgramLab7
    {
        public static void Run()
        {
            Pet cat = new Pet(10, 3);
            Pet dog = new Pet(20, 5);

            cat.SetTalk(() => Console.WriteLine("Мяу!")); 
            dog.SetTalk(delegate { Console.WriteLine("Гав!"); }); 
            cat.Speak();
            dog.Speak();

            dog.AddTalk(() => Console.WriteLine("Ррр!"));
            dog.Speak();

            Console.WriteLine("Одинаково ли говорят? " + cat.HasSameTalk(dog));

            GainWeightDelegate add = (p, v) => p.AddWeight(v);
            GainWeightDelegate multiply = (p, v) => p.MultiplyWeight(v);

            Console.WriteLine($"Вес кота: {cat.Weight}");
            cat.GainWeight(add, 5);
            Console.WriteLine($"Вес кота после еды: {cat.Weight}");
            cat.GainWeight(multiply, 2);
            Console.WriteLine($"Вес кота после умножения: {cat.Weight}");

            Doctor doctor = new Doctor();
            Death death = new Death();

            cat.WeightOrAgeEvent += doctor.OnPetIll;
            cat.WeightOrAgeEvent += death.OnPetDied;

            cat.GainWeight(add, 100); 
            for (int i = 0; i < 20; i++) cat.Birthday();
        }
    }
}
