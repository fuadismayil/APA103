using _10_GenericTypesCollections.Models;
using System.Net;

namespace _10_GenericTypesCollections
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Book book1 = new Book(1, "Martin Eden", "Jack London", 1909, 400);
            Book book2 = new Book(2, "1984", "George Orwell", 1949, 328);
            Book book3 = new Book(3, "Animal Farm", "George Orwell", 1945, 112);
            Book book4 = new Book(4, "Ag Gemi", "Cingiz Aytmatov", 1970, 200);
            Book book5 = new Book(5, "Qiriq Budaq", "Elcin", 1998, 350);

            book1.DisplayInfo();
            book2.DisplayInfo();
            book3.DisplayInfo();
            book4.DisplayInfo();
            book5.DisplayInfo();
            Console.WriteLine();

            Library<Book> milliKitabxana = new Library<Book>("Milli  Kitabxana");
            milliKitabxana.Add(book1);
            milliKitabxana.Add(book2);
            milliKitabxana.Add(book3);
            milliKitabxana.Add(book4);
            milliKitabxana.Add(book5);
            Console.WriteLine();

            Console.WriteLine(milliKitabxana.Count());
            Console.WriteLine();

            milliKitabxana.FindByIndex(0).DisplayInfo();
            milliKitabxana.FindByIndex(2).DisplayInfo();
            Console.WriteLine();

            milliKitabxana.GetAll().ForEach(book => book.DisplayInfo());
            Console.WriteLine();

            List<Member> members = new List<Member>();

            Member member1 = new Member(1, "Ali Memmedov", "ali@mail.com");
            Member member2 = new Member(2, "Leyla Hasanova", "leyla@mail.com");
            Member member3 = new Member(3, "Vuqar Aliyev", "vuqar@mail.com");

            member1.BorrowBook(book1);
            member1.BorrowBook(book2);
            member1.DisplayBorrowedBooks();
            Console.WriteLine();

            member1.ReturnBook(1);
            member1.DisplayBorrowedBooks();
            Console.WriteLine();

            member1.BorrowBook(book3);
            member1.BorrowBook(book4);
            member1.BorrowBook(book5);
            Console.WriteLine();

            BookManager bookManager = new BookManager();
            bookManager.AddBook(book1);
            bookManager.AddBook(book2);
            bookManager.AddBook(book3);
            bookManager.AddBook(book4);
            bookManager.AddBook(book5);

            foreach (var book in bookManager.GetBooksByAuthor("George Orwell"))
            {
                book.DisplayInfo();
            }
            foreach (var book in bookManager.GetBooksByAuthor("Cingiz Aytmatov"))
            {
                book.DisplayInfo();
            }
            foreach (var book in bookManager.GetBooksByAuthor("Jack London"))
            {
                book.DisplayInfo();
            }
            foreach (var book in bookManager.GetBooksByAuthor("rando,"))
            {
                book.DisplayInfo();
            }
            Console.WriteLine();

            bookManager.AddToWaitingQueue("Nigar");
            bookManager.AddToWaitingQueue("Resad");
            bookManager.AddToWaitingQueue("Sebine");
            Console.WriteLine();
            Console.WriteLine($"Novbedeki insan sayi: {bookManager.WaitingQueue.Count}");
            Console.WriteLine($"Xidmet edilir: {bookManager.ServeNextInQueue()}");
            Console.WriteLine($"Novbedeki insan sayi: {bookManager.WaitingQueue.Count}");
            Console.WriteLine($"Xidmet edilir: {bookManager.ServeNextInQueue()}");
            Console.WriteLine($"Novbedeki insan sayi: {bookManager.WaitingQueue.Count}");
            Console.WriteLine($"Xidmet edilir: {bookManager.ServeNextInQueue()}");
            Console.WriteLine($"Novbedeki insan sayi: {bookManager.WaitingQueue.Count}");
            Console.WriteLine();

            bookManager.ReturnBook(book1);
            bookManager.ReturnBook(book2);
            bookManager.ReturnBook(book3);
            Console.WriteLine(bookManager.RecentlyReturned.Count);
            Console.WriteLine($"Son qaytarilan kitab: {bookManager.GetLastReturnedBook().Title}");
            bookManager.GetLastReturnedBook();
            Console.WriteLine();

            bookManager.RecentlyReturned.Pop();
            Console.WriteLine(bookManager.RecentlyReturned.Count);
            Console.WriteLine($"Son qaytarilan kitab: {bookManager.GetLastReturnedBook().Title}");

            bookManager.SearchByTitle("1984").DisplayInfo();
            if (bookManager.SearchByTitle("Harry Potter") == null)
            {
                Console.WriteLine("null");
            }
            Console.WriteLine();

            Console.WriteLine($"Umumi kitab sayi: {bookManager.Books.Count}");
            Console.WriteLine($"Umumi uzv sayi: {members.Count}");
            Console.WriteLine($"Novbede nefer sayi: {bookManager.WaitingQueue.Count}");
            Console.WriteLine($"Stack-de kitab sayi: {bookManager.RecentlyReturned.Count}");
            Console.WriteLine();

            int oldestBook = int.MaxValue;
            foreach (var book in bookManager.Books)
            {
                if (oldestBook > book.Year)
                {
                    oldestBook = book.Year;
                }
            }
            Console.WriteLine(oldestBook);
            Console.WriteLine();

            int newestBook = int.MinValue;
            foreach (var book in bookManager.Books)
            {
                if (newestBook < book.Year)
                {
                    newestBook = book.Year;
                }
            }
            Console.WriteLine(newestBook);


        }
    }
}