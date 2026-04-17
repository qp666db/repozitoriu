using System;
using System.Runtime.InteropServices;



public class Book
{
    private string _title;
    private string _author;
    private int _year;
    private int _pages;

    public string Title
    {
        get => _title;
        set
        {
            if (!string.IsNullOrEmpty(value)) _title = value;
        }
    }

    public string Author
    {
        get => _author;
        set
        {
            if (!string.IsNullOrEmpty(value)) _author = value;
        }
    }

    public int Year
    {
        get => _year;
        set
        {
            if (value > 0) _year = value;
        }
    }

    public int Pages
    {
        get => _pages;
        set
        {
            if (value > 0) _pages = value;
        }
    }

    public Book(string title, string author, int year, int pages)
    {
        Title = title;
        Author = author;
        Year = year;
        Pages = pages;
    }

    public virtual void ShowInfo()
    {
        Console.WriteLine($"Книга: {Title}, Автор: {Author}, Год: {Year}, Страниц: {Pages}");
    }
}
public class Textbook : Book
{
    public string Subject { get; set; }

    public Textbook(string title, string author, int year, int pages, string subject)
        : base(title, author, year, pages)
    {
        Subject = subject;
    }

    public override void ShowInfo()
    {
        Console.WriteLine($"Учебник: {Title}, Предмет: {Subject}, Автор: {Author}, Год: {Year}, Страниц: {Pages}");
    }
}

public class FictionBook : Book
{
    public string Genre { get; set; }

    public FictionBook(string title, string author, int year, int pages, string genre)
        : base(title, author, year, pages)
    {
        Genre = genre;
    }

    public override void ShowInfo()
    {
        Console.WriteLine($"Художественная книга: {Title}, Жанр: {Genre}, Автор: {Author}, Год: {Year}, Страниц: {Pages}");
    }
}

public class Reader
{
    public string Name { get; set; }
    public int Id { get; set; }
    private List<Book> _borrowedBooks = new List<Book>();

    public Reader(string name, int id)
    {
        Name = name;
        Id = id;
    }

    public void BorrowBook(Book book)
    {
        _borrowedBooks.Add(book);
        Console.WriteLine($"{Name} взял книгу \"{book.Title}\"");
    }

    public void ShowBorrowedBooks()
    {
        Console.WriteLine($"Книги у {Name}:");
        foreach (var book in _borrowedBooks)
        {
            book.ShowInfo();
        }
    }
}
public interface ILibraryManagement
{
    void AddBook(Book book);
    bool RemoveBook(Book book);
    List<Book> SearchByAuthor(string author);
    void ListBooks();
}

public class Library : ILibraryManagement
{
    private List<Book> _books = new List<Book>();

    public void AddBook(Book book)
    {
        _books.Add(book);
        Console.WriteLine($"Книга \"{book.Title}\" добавлена в библиотеку.");
    }

    public bool RemoveBook(Book book)
    {
        bool removed = _books.Remove(book);
        if (removed)
            Console.WriteLine($"Книга \"{book.Title}\" удалена из библиотеки.");
        return removed;
    }

    public List<Book> SearchByAuthor(string author)
    {
        return _books.Where(b => b.Author == author).ToList();
    }

    public void ListBooks()
    {
        Console.WriteLine("Список книг в библиотеке:");
        foreach (var book in _books)
        {
            book.ShowInfo();
        }
    }

    public void IssueBook(Book book, Reader reader)
    {
        if (_books.Contains(book))
        {
            reader.BorrowBook(book);
            _books.Remove(book);
        }
        else
        {
            Console.WriteLine($"Книга \"{book.Title}\" сейчас недоступна.");
        }
    }

    public void ReturnBook(Book book)
    {
        _books.Add(book);
        Console.WriteLine($"Книга \"{book.Title}\" возвращена в библиотеку.");
    }
}

public abstract class Publication
{
    public abstract void GetInfo();
}

public class BookPublication : Publication
{
    private Book _book;

    public BookPublication(Book book)
    {
        _book = book;
    }

    public override void GetInfo()
    {
        _book.ShowInfo();
    }
}
class Program
{
    static void Main()
    {
        Library library = new Library();

        Textbook t1 = new Textbook("Математика 101", "Иванов", 2020, 300, "Математика");
        FictionBook f1 = new FictionBook("Война и мир", "Толстой", 1869, 1200, "Роман");

        library.AddBook(t1);
        library.AddBook(f1);
        library.ListBooks();

        Reader reader = new Reader("Алексей", 1);

        library.IssueBook(t1, reader);
        reader.ShowBorrowedBooks();

        library.ListBooks();

        library.ReturnBook(t1);
        library.ListBooks();

        Publication pub = new BookPublication(f1);
        pub.GetInfo();
    }
}


