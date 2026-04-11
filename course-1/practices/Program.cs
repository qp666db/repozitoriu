using System;

namespace tralalakla
{
    public interface IPlayable
    {
        void Play();
    }

    public class Guitar : IPlayable
    {
        public void Play()
        {
            Console.WriteLine("Гитара играет аккорды");
        }
    }

    public class Piano : IPlayable
    {
        public void Play()
        {
            Console.WriteLine("Пианино играет ноты");
        }
    }

    public class Drum : IPlayable
    {
        public void Play()
        {
            Console.WriteLine("Барабан бьет ритм");
        }
    }


    public interface IReadable
    {
        void Read(string filename);
    }

    public interface IWritable
    {
        void Write(string filename, string content);
    }

    public interface ISavable
    {
        void Save();
    }

    public class TextDocument : IReadable, IWritable, ISavable
    {
        private string content;

        public void Read(string filename)
        {
            Console.WriteLine($"Чтение из файла {filename}");
            content = "Текст из файла";
        }

        public void Write(string filename, string content)
        {
            Console.WriteLine($"Запись в файл {filename}: {content}");
            this.content = content;
        }

        public void Save()
        {
            Console.WriteLine($"Файл сохранен. Содержимое: {content}");
        }
    }


    public interface IDocumentExporter
    {
        string FormatName { get; }
        void Export(string content);

        void ShowInfo(string content)
        {
            Console.WriteLine($"Экспорт в формат {FormatName}: {content}");
        }
    }


    public class TxtExporter : IDocumentExporter
    {
        public string FormatName => "TXT";

        public void Export(string content)
using System;

namespace InterfacePractice
{
    // --- ЗАДАНИЕ 1 ---
    public interface IPlayable
    {
        void Play();
    }

    public class Guitar : IPlayable
    {
        public void Play() => Console.WriteLine("Гитара играет аккорды");
    }

    public class Piano : IPlayable
    {
        public void Play() => Console.WriteLine("Пианино играет мелодию");
    }

    public class Drum : IPlayable
    {
        public void Play() => Console.WriteLine("Барабан отбивает ритм");
    }

    // --- ЗАДАНИЕ 2 ---
    public interface IReadable { void Read(string filename); }
    public interface IWritable { void Write(string filename, string content); }
    public interface ISavable { void Save(); }

    public class TextDocument : IReadable, IWritable, ISavable
    {
        private string content;

        public void Read(string filename)
        {
            Console.WriteLine($"Чтение из файла {filename}");
            content = "Текст из файла";
        }

        public void Write(string filename, string content)
        {
            Console.WriteLine($"Запись в файл {filename}: {content}");
            this.content = content;
        }

        public void Save()
        {
            Console.WriteLine($"Файл сохранён. Содержимое: {content}");
        }
    }

    // --- ЗАДАНИЕ 3 ---
    public interface IDocumentExporter
    {
        string FormatName { get; }
        void Export(string content);

        // Реализация метода по умолчанию (доступна в C# 8.0+)
        void ShowInfo(string content)
        {
            Console.WriteLine($"\nЭкспорт в формат {FormatName}: {content}");
        }
    }

    public class TxtExporter : IDocumentExporter
    {
        public string FormatName => "TXT";
        public void Export(string content) => Console.WriteLine("Сохраняем текстовый файл...");
    }

    public class PdfExporter : IDocumentExporter
    {
        public string FormatName => "PDF";
        public void Export(string content) => Console.WriteLine("Создаём PDF-документ...");
    }

    class Program
    {
        static void Main(string[] args)
        {
            // ПРОВЕРКА ЗАДАНИЯ 1
            Console.WriteLine("--- Задание 1: Музыкальные инструменты ---");
            IPlayable[] instruments = { new Guitar(), new Piano(), new Drum() };
            foreach (var i in instruments) i.Play();

            // ПРОВЕРКА ЗАДАНИЯ 2
            Console.WriteLine("\n--- Задание 2: Работа с документом ---");
            TextDocument doc = new TextDocument();
            doc.Read("data.txt");
            doc.Write("data.txt", "Привет, мир!");
            doc.Save();

            // ПРОВЕРКА ЗАДАНИЯ 3
            Console.WriteLine("\n--- Задание 3: Экспорт документов ---");
            IDocumentExporter[] exporters = { new TxtExporter(), new PdfExporter() };
            foreach (var e in exporters)
            {
                e.ShowInfo("Hello World!");
                e.Export("Hello World!");
            }

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}
   foreach (var instrument in instruments)
            {
                instrument.Play();
            }

            Console.WriteLine("Задание 2");
            TextDocument doc = new TextDocument();
            doc.Read("data.txt");
            doc.Write("data.txt", "Привет, мир!");
            doc.Save();

            Console.WriteLine("Задание 3");
            IDocumentExporter[] exporters =
            {
                new TxtExporter(),
                new PdfExporter()
            };

            foreach (var exporter in exporters)
            {
                exporter.ShowInfo("Hello World!");
                exporter.Export("Hello World!");

            }
        }
    }
}


