using iQuest.BooksAndNews.Application.Publishers;
using System;
using iQuest.BooksAndNews;
using iQuest.BooksAndNews.Application.Publications;
using System.Collections.Generic;
using System.Linq;

namespace iQuest.BooksAndNews.Application.Subscribers
{
    // todo: This class must be implemented.

    /// <summary>
    /// This is a subscriber that is interested to receive notification whenever news
    /// are printed.
    ///
    /// Subscribe to the printing office and log each news that was printed.
    /// </summary>
    ///

    public class NewsHunter 
    {
        public readonly string name;
        private readonly PrintingOffice printingOffice;
        private readonly ILog log;

        public NewsHunter(string name, PrintingOffice printingOffice, ILog log)
        {
            this.name = name ?? throw new ArgumentNullException(nameof(name));
            this.printingOffice = printingOffice ?? throw new ArgumentNullException(nameof(printingOffice));
            this.log = log ?? throw new ArgumentNullException(nameof(log));

            printingOffice.NewspaperPrintEventHandler += NewspaperWasPrinted;
        }

        private void NewspaperWasPrinted(Newspaper newspaper)
        {
            log.WriteInfo($"{newspaper.Title} was printed. Hope you enjoy it!");
        }
    }
}