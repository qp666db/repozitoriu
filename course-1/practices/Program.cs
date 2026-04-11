using System;

namespace InterfacesDemo
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
        {
            Console.WriteLine("Сохраняем текстовый файл.");
        }
    }

    public class PdfExporter : IDocumentExporter
    {
        public string FormatName => "PDF";

        public void Export(string content)
        {
            Console.WriteLine("Создаtм PDF-документ.");
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Задание 1");
            IPlayable[] instruments =
            {
                new Guitar(),
                new Piano(),
                new Drum()
            };

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


