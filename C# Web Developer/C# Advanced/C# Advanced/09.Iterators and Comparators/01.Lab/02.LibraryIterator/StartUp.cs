using System;

namespace IteratorsAndComparators
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var library = new Library
            {
                new Book {Title = "Whatever", Year = 2015},
                new Book{Title = "Another Book", Year = 2012}
            };

            foreach (var book in library)
            {
                Console.WriteLine(book.Title);
            }
        }
    }
}
