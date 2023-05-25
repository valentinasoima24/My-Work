using iQuest.BooksAndNews.Application.DataAccess;
using iQuest.BooksAndNews.Application.Publications;
using iQuest.BooksAndNews.Application.Subscribers;
using System;
using System.Collections.Generic;
using System.Linq;
using static iQuest.BooksAndNews.Application.Publications.BookPrintedEventHandler;
using static iQuest.BooksAndNews.Application.Publications.NewspaperPrintedEventHandler;

namespace iQuest.BooksAndNews.Application.Publishers
{
    // todo: This class must be implemented.

    /// <summary>
    /// This is the class that will publish books and newspapers.
    /// It must offer a mechanism through which different other classes can subscribe ether
    /// to books or to newspaper.
    /// When a book or newspaper is published, the PrintingOffice must notify all the corresponding
    /// subscribers.
    /// </summary>
    /// 
    public class PrintingOffice
    {
        public event BookPrint BookPrintEventHandler;
        public event NewspaperPrint NewspaperPrintEventHandler;

        private readonly IBookRepository bookRepository;
        private readonly INewspaperRepository newspaperRepository;
        private readonly ILog log;


        public PrintingOffice(IBookRepository bookRepository, INewspaperRepository newspaperRepository, ILog log)
        {
            this.bookRepository = bookRepository??throw new ArgumentNullException(nameof(bookRepository));
            this.newspaperRepository = newspaperRepository ?? throw new ArgumentNullException(nameof(newspaperRepository));
            this.log = log ?? throw new ArgumentNullException(nameof(log));

        }

        public void PrintRandom(int bookCount, int newspaperCount)
        {
            PrintOneBook(bookCount);
            PrintOneNewspaper(newspaperCount);
        }

        private void PrintOneBook(int booksNumber)
        {
            for(int i=0; i < booksNumber; i++)
            {
                Book book = bookRepository.GetRandom();
                log.WriteInfo($"Book {book.Title} by {book.Author} was printed.");


                BookPrintEventHandler?.Invoke(book);
            }
        }

        private void PrintOneNewspaper(int newspapersNumber)
        {
            for (int i = 0; i < newspapersNumber; i++)
            {
                Newspaper newspaper = newspaperRepository.GetRandom();
                log.WriteInfo($"{newspaper.Title} newspaper was printed.");


                NewspaperPrintEventHandler?.Invoke(newspaper);
            }
        }
    }
}