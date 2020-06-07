using System;
using System.Linq;
using System.Collections.Generic;

namespace Articles
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string[] articleArgs = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);

            string title = articleArgs[0];
            string content = articleArgs[1];
            string author = articleArgs[2];

            Article article = new Article(title, content, author);

            int countOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < countOfCommands; i++)
            {
                string[] commandArgs = Console.ReadLine().Split(new string[] {": "}, StringSplitOptions.RemoveEmptyEntries);

                string command = commandArgs[0];
                string value = commandArgs[1];

                if (command == "Edit")
                {
                    string currentContent = commandArgs[1];
                    article.Edit(currentContent);
                }
                else if (command == "ChangeAuthor")
                {
                    string currentAuthor = commandArgs[1];
                    article.ChangeAuthor(currentAuthor);
                }
                else if (command == "Rename")
                {
                    string currentTitle = commandArgs[1];
                    article.Rename(currentTitle);
                }
            }

            Console.WriteLine(article);
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

            public void Edit(string newContent)
            {
                this.Content = newContent;
            }

            public void ChangeAuthor(string newAuthor)
            {
                this.Author = newAuthor;
            }

            public void Rename(string newTitle)
            {
                this.Title = newTitle;
            }

            public override string ToString()
            {
                return $"{this.Title} - {this.Content}: {this.Author}";
            }
        }
    }
}