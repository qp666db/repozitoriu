using System;

public class Movie
{
    public string Title { get; set; }
    public string Genre { get; set; }
    public double Rating { get; set; }

    public Movie(string title, string genre, double rating)
    {
        Title = title;
        Genre = genre;
        Rating = rating;
    }


    public Movie(string title) : this(title, "Неизвестен", 0) { }

    public Movie() : this("Без названия", "Неизвестен", 0) { }

    public void PrintInfo()
    {
        Console.WriteLine($"Название: {Title}, жанр: {Genre}, рейтинг: {Rating}");
    }
}


public class Device
{
    public string Name { get; set; }

    public void TurnOn()
    {
        Console.WriteLine($"{Name}: Устройство вкл.");
    }

 
    public virtual void Beep()
    {
        Console.WriteLine("Устройство даёт сигнал.");
    }
}

public class Kettle : Device
{
    public void Boil()
    {
        Console.WriteLine("Чайник кипятит воду.");
    }

    public override void Beep()
    {
        Console.WriteLine("Чайник пикнул: пи-пи!");
    }
}

public class Toaster : Device
{
    public void Toast()
    {
        Console.WriteLine("Тостер поджаривает хлеб.");
    }

    public override void Beep()
    {
        Console.WriteLine("Тостер пикнул: динь!");
    }
}

class Program
{
    static void Main()
    {

        Console.WriteLine("Фильмы");
        var m1 = new Movie();
        var m2 = new Movie("Матрица");
        var m3 = new Movie("Начало", "Фантастика", 9);

        m1.PrintInfo();
        m2.PrintInfo();
        m3.PrintInfo();


        Console.WriteLine("\nУстройства");

        var kettle = new Kettle { Name = "Redmond" };
        kettle.TurnOn();
        kettle.Boil();
        kettle.Beep();

        Console.WriteLine();

        var toaster = new Toaster { Name = "Philips" };
        toaster.TurnOn();
        toaster.Toast();
        toaster.Beep();
    }
}