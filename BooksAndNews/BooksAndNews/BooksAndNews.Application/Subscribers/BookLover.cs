using iQuest.BooksAndNews.Application.Publications;
using iQuest.BooksAndNews.Application.Publishers;
using System;

namespace iQuest.BooksAndNews.Application.Subscribers
{
    // todo: This class must be implemented.

    /// <summary>
    /// This is a subscriber that is interested to receive notification whenever a book
    /// is printed.
    ///
    /// Subscribe to the printing office and log each book that was printed.
    /// </summary>
    public class BookLover
    {

        public readonly string name;
        private readonly PrintingOffice printingOffice;
        private readonly ILog log;
        public BookLover(string name, PrintingOffice printingOffice, ILog log)
        {
            this.name = name ?? throw new ArgumentNullException(nameof(name));
            this.printingOffice = printingOffice ?? throw new ArgumentNullException(nameof(printingOffice));
            this.log = log ?? throw new ArgumentNullException(nameof(log));

            printingOffice.BookPrintEventHandler += BookWasPrinted;
        }

        private void BookWasPrinted(Book book)
        {
            log.WriteInfo($"{book.Title} was printed. Hope you enjoy it!");
        }
    }
}
