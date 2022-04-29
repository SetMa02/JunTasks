using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

namespace Library
{
    class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();
            bool isExit = false;

            while (isExit == false)
            {
                Console.WriteLine("1. Добавить книгу \n" +
                                  "2. Удалить книгу \n" +
                                  "3. Поиск книги \n" +
                                  "4. Выход");

                switch (Console.ReadLine())
                {
                    case "1":
                        library.AddBook();
                        break;
                    case "2":
                        library.RemoveBook();
                        break;
                    case "3":
                        library.Search();
                        break;
                    case "4":
                        isExit = true;
                        break;
                    default:
                        Console.WriteLine("Неверный ввод");
                        break;
                }
            }
        }
    }

    class Library
    {
        private List<Book> _books;

        public Library()
        {
            _books = new List<Book>();
        }

        public void AddBook()
        {
            string name;
            string author;
            string year;
            Console.WriteLine("Введите название книги:");
            name = Console.ReadLine();
            Console.WriteLine("Введите автора книги:");
            author = Console.ReadLine();
            Console.WriteLine("Введите год выпуска книги:");
            year = Console.ReadLine();

            Book book = new Book(name, author, year);
            _books.Add(book);
        }

        public void RemoveBook()
        {
            int bookToRemove;
            ShowBooks();
            Console.WriteLine("Какую книгу нужно убрать?");
            if (Int32.TryParse(Console.ReadLine(), out bookToRemove))
            {
                if (bookToRemove >= 0 && bookToRemove <= _books.Count )
                {
                    _books.RemoveAt(bookToRemove);
                }
            }
        }

        public void Search()
        {
            Console.WriteLine("1. Поиск по названию" +
                              "\n2. Поиск по Автору" +
                              "\n3. Поиск по году");

            switch (Console.ReadLine())
            {
                case "1":
                    SearchByName();
                    break;
                case "2":
                    SearchByAuthor();
                    break;
                case "3":
                    SearchByYear();
                    break;
                default:
                    Console.WriteLine("Неверный ввод");
                    break;
            }
        }

        private void SearchByName()
        {
            Console.WriteLine("Введите название книги");
            string name = Console.ReadLine();
            
            foreach (var book in _books)
            {
                if (book.Name.Contains(name))
                {
                    Console.WriteLine($"{_books.IndexOf(book)}. {book.Name}");
                }
            }
        }
        
        private void SearchByAuthor()
        {
            Console.WriteLine("Введите автора книги");
            string author = Console.ReadLine();
            
            foreach (var book in _books)
            {
                if (book.Name.Contains(author))
                {
                    Console.WriteLine($"{_books.IndexOf(book)}. {book.Name}");
                }
            }
        }
        
        private void SearchByYear()
        {
            Console.WriteLine("Введите год выпуска книги");
            string year = Console.ReadLine();
            
            foreach (var book in _books)
            {
                if (book.Name.Contains(year))
                {
                    Console.WriteLine($"{_books.IndexOf(book)}. {book.Name}");
                }
            }
        }

        public void ShowBooks()
        {
            foreach (var book in _books)
            {
                Console.WriteLine($"{_books.IndexOf(book)}. {book.Name}");
            }
        }
    }

    class Book
    {
        private string _name;
        private string _author;
        private string _year;

        public string Name => _name;
        public string Author => _author;
        public string Year => _year;

        public Book(string name, string author, string year)
        {
            _name = name;
            _author = author;
            _year = year;
        }
    }
}