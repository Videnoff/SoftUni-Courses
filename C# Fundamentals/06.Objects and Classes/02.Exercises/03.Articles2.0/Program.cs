using System;
using System.Linq;
using System.Collections.Generic;

namespace Articles2
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int articleNumber = int.Parse(Console.ReadLine());
            List<Article> articles = new List<Article>();

            for (int i = 0; i < articleNumber; i++)
            {
                string[] articleArgs = Console.ReadLine().Split(new string[] {", "}, StringSplitOptions.None);

                string title = articleArgs[0];
                string content = articleArgs[1];
                string author = articleArgs[2];

                Article article = new Article(title, content, author);
                articles.Add(article);
            }

            string input = Console.ReadLine();

            if (input == "title")
            {
                List<Article> sortedArticles = articles.OrderBy(x => x.Title).ToList();
                sortedArticles.ForEach(x => Console.WriteLine(x));
            }
            else if (input == "content")
            {
                List<Article> sortedArticles = articles.OrderBy(x => x.Content).ToList();
                sortedArticles.ForEach(x => Console.WriteLine(x));
            }
            else if (input == "author")
            {
                List<Article> sortedArticles = articles.OrderBy(x => x.Author).ToList();
                sortedArticles.ForEach(x => Console.WriteLine(x));
            }


        }
    }

    class Article
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public string Author { get; set; }

        public Article(string title, string content, string author)
        {
            this.Title = title;
            this.Content = content;
            this.Author = author;
        }

        public override string ToString()
        {
            return string.Format($"{this.Title} - {this.Content}: {this.Author}");
        }
    }
}
