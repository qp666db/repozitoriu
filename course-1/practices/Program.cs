using System;

namespace  balabolka;
    public abstract class Shape
    {
        public abstract string Name { get; }
        public abstract double GetArea();
        public void Print() => Console.WriteLine($"{Name}: площадь = {GetArea():F2}");
    }

    public class Circle : Shape
    {
        public double Radius { get; set; }
        public override string Name => "Круг";
        public override double GetArea() => Math.PI * Math.Pow(Radius, 2);
    }

    public class Rectangle : Shape
    {
        public double Width { get; set; }
        public double Height { get; set; }
        public override string Name => "Прямоугольник";
        public override double GetArea() => Width * Height;
    }


    public abstract class Animal
    {
        public string Name { get; set; }
        public Animal(string name)
        {
            Name = name;
            Console.WriteLine($"Создано животное: {Name}");
        }
        public void Eat() => Console.WriteLine($"{Name} ест.");
        public abstract void MakeSound();
    }

    public class Dog : Animal
    {
        public Dog(string name) : base(name) { }
        public override void MakeSound() => Console.WriteLine($"{Name}: Гав-гав!");
    }

    public class Cat : Animal
    {
        public Cat(string name) : base(name) { }
        public override void MakeSound() => Console.WriteLine($"{Name}: Мяу!");
    }


    public abstract class Transport
    {
        public void Move()
        {
            Start();
            MoveCore();
            Stop();
        }
        protected void Start() => Console.WriteLine("Старт");
        protected void Stop() => Console.WriteLine("Стоп");
        protected abstract void MoveCore();
    }

    public class Car : Transport
    {
        protected override void MoveCore() => Console.WriteLine("Машина едет по дороге");
    }

    public class Boat : Transport
    {
        protected override void MoveCore() => Console.WriteLine("Лодка плывёт по воде");
    }


    public abstract class DocumentExporter
    {
        public abstract string FormatName { get; }
        public abstract void Export(string content);
        public void ShowInfo(string content)
        {
            Console.WriteLine($"Экспорт в формат {FormatName}: {content}");
        }
    }

    public class TxtExporter : DocumentExporter
    {
        public override string FormatName => "TXT";
        public override void Export(string content) => Console.WriteLine("Сохраняем текстовый файл");
    }

    public class PdfExporter : DocumentExporter
    {
        public override string FormatName => "PDF";
        public override void Export(string content) => Console.WriteLine("Создаём PDF-документ");
    }

 
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("\nЗАДАНИЕ 1");
            Shape[] shapes = {
                new Circle { Radius = 5 },
                new Rectangle { Width = 4, Height = 10 }
            };
            foreach (var s in shapes) s.Print();

            
            Console.WriteLine("\nЗАДАНИЕ 2");
            Animal[] animals = {
                new Dog("Рекс"),
                new Cat("Мурка")
            };
            foreach
(var a in animals) 
            { 
                a.Eat();
a.MakeSound(); 
            }

            
            Console.WriteLine("\nЗАДАНИЕ 3");
Transport[] transports = {
                new Car(),
                new Boat()
            };
foreach (var t in transports)
{
    t.Move();
}


Console.WriteLine("\nЗАДАНИЕ 4");
DocumentExporter[] exporters = {
                new TxtExporter(),
                new PdfExporter()
            };
foreach (var e in exporters)
{
    e.ShowInfo("Hello world!");
    e.Export("Hello world!");
}

        }
    }