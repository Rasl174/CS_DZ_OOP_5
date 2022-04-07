using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_DZ_OOP_5
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Book> books = new List<Book>();
            Storage storage = new Storage(books);

            Console.WriteLine("Это хранилище с книгами введите что нужно сделать.");
            storage.Work();
        }
    }

    class Storage
    {
        private List<Book> _books;

        public Storage(List<Book> books)
        {
            _books = books;
        }

        public void Work()
        {
            bool isWork = true;

            while (isWork)
            {
                Console.WriteLine("Для добавления книги введите 1");
                Console.WriteLine("Для удаления книги введите 2");
                Console.WriteLine("Для вывода всех книг введите 3");
                Console.WriteLine("Для поиска книги по параметру введите 4");
                Console.WriteLine("Для выхода введите 5 или exit");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        AddBook();
                        break;
                    case "2":
                        DeleteBook();
                        break;
                    case "3":
                        ShowAllBooks();
                        break;
                    case "4":
                        FindByParameter();
                        break;
                    case "5":
                    case "exit":
                        isWork = false;
                        break;
                    default:
                        Console.WriteLine("Не верный ввод повторите попытку!");
                        break;
                }
            }
        }

        private void AddBook()
        {
            Console.Clear();

            int issueYear = 0;
            bool correctInput = false;

            Console.WriteLine("Введите название книги ");
            string name = Console.ReadLine();

            Console.WriteLine("Введите автора книги ");
            string author = Console.ReadLine();

            Console.WriteLine("Введите год книги не более 2022 года");
            while(correctInput == false)
            {
                if(int.TryParse(Console.ReadLine(), out int userInput) == false || userInput < 600 || userInput > 2022)
                {
                    Console.WriteLine("Ввод не корректный введите снова ");
                }
                else
                {
                    issueYear = userInput;
                    correctInput = true;
                }
            }
            Console.Clear();
            Console.WriteLine("Книга добавлена!");
            _books.Add(new Book(name, author, issueYear));
            Console.ReadKey();
        }

        private void DeleteBook()
        {
            Console.Clear();

            if(_books.Count > 0)
            {
                Console.WriteLine("Для удаления книги введите ее название");

                string userInput = Console.ReadLine();

                foreach (var book in _books)
                {
                    if(userInput == book.Name)
                    {
                        _books.Remove(book);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("В хранилише нет книги с таким названием");
                    }
                }
                Console.WriteLine("Книга удалена!");
            }
            else
            {
                Console.WriteLine("В хранилище еще нет книг!");
            }
            Console.ReadKey();
            Console.Clear();
        }

        private void ShowAllBooks()
        {
            Console.Clear();

            if(_books.Count > 0)
            {
                foreach (var book in _books)
                {
                    Console.WriteLine("Автор - " + book.Author + " название - " + book.Name + " год выпуска - " + book.IssueYear);
                }
            }
            else
            {
                Console.WriteLine("В хранилище нет книг");
            }
            Console.ReadKey();
            Console.Clear();
        }

        private void FindByParameter()
        {
            Console.Clear();

            if(_books.Count > 0)
            {
                Console.WriteLine("Введите по какому параметру искать книгу");
                Console.WriteLine("Введите 1 для поиска по автору");
                Console.WriteLine("Введите 2 для поиска по названию");
                Console.WriteLine("Введите 3 для поиска по году выпуска");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        FindByAuthor();
                        break;
                    case "2":
                        FindByName();
                        break;
                    case "3":
                        FindByYear();
                        break;
                    default:
                        Console.WriteLine("Не верный ввод!");
                        break;
                }
            }
            else
            {
                Console.WriteLine("В хранилище еще нет книг");
            }
            Console.ReadKey();
            Console.Clear();
        }

        private void FindByAuthor()
        {
            Console.Clear();
            Console.WriteLine("Введите автора книг");
            string userInput = Console.ReadLine();

            foreach (var book in _books)
            {
                if(book.Author == userInput)
                {
                    Console.WriteLine("Найдена книга с назаванием - " + book.Name + " и годом выпуска - " + book.IssueYear);
                }
                else
                {
                    Console.WriteLine("Такого автора нет!");
                }
            }
            Console.ReadKey();
            Console.Clear();
        }

        private void FindByName()
        {
            Console.Clear();
            Console.WriteLine("Введите название книги");
            string userInput = Console.ReadLine();

            foreach (var book in _books)
            {
                if (book.Name == userInput)
                {
                    Console.WriteLine("Найдена книга с автором - " + book.Author + " и годом выпуска - " + book.IssueYear);
                }
                else
                {
                    Console.WriteLine("Такого автора нет!");
                }
            }
            Console.ReadKey();
            Console.Clear();
        }

        private void FindByYear()
        {
            Console.Clear();
            Console.WriteLine("Введите год выпуска книг");

            bool correctInput = false;

            while(correctInput == false)
            {
                if(int.TryParse(Console.ReadLine(), out int userInput) == false)
                {
                    Console.WriteLine("Не верный ввод повторите попытку");
                }
                else
                {
                    foreach (var book in _books)
                    {
                        if(book.IssueYear == userInput)
                        {
                            Console.WriteLine("Найдена книга - " + book.Name + " автор - " + book.Author);
                        }
                        else
                        {
                            Console.WriteLine("Такой книги нет!");
                        }
                    }
                    correctInput = true;
                }
            }
            Console.ReadKey();
            Console.Clear();
        }
    }

    class Book
    {
        public string Name { get; private set; }

        public string Author { get; private set; }

        public int IssueYear { get; private set; }

        public Book(string name, string author, int issueYear)
        {
            Name = name;
            Author = author;
            IssueYear = issueYear;
        }
    }
}
