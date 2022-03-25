using System;
using ConsoleAppProject.Helpers;

namespace ConsoleAppProject.App04
{
    public class NewsApp
    {
        //public NewsFeed NewsFeed { get; set; }
        public DateTime Timestamp { get; }
        public string[] Choices = { "Add Photo Post", "Add Message Post", "Display All Posts" };

        public NewsApp()
        {
            //NewsFeed = new NewsFeed();
            Timestamp = DateTime.Now;
        }

        ///<summary>
        /// This app will allow the user to add messages and photos
        /// to a list of posts, which will then display them.
        ///</summary>
        /// <author>
        /// Tomás Pinto Version 21st March 2022
        /// </author>
        public void Run()
        {
            AddMessagePost();
        }

        private void AddMessagePost()
        {
            ConsoleHelper.OutputHeading("Add Message");

            Console.Write("Please enter the author's name > ");
            string author = Console.ReadLine();

            Console.Write("Please enter the message > ");
            string message = Console.ReadLine();

            //MessagePost post = new MessagePost();
            //NewsFeed.AddPost(post);

            Console.WriteLine();
            Console.WriteLine($"    Author: {author}");
            Console.WriteLine($"    Message: {message}");
            Console.WriteLine($"    Time Elpased: {FormatElapsedTime(Timestamp)}");
            Console.WriteLine();
        }

        public String FormatElapsedTime(DateTime time)
        {
            DateTime current = DateTime.Now;
            TimeSpan timePast = current - time;

            long seconds = (long)timePast.TotalSeconds;
            long minutes = seconds / 60;

            if (minutes > 0)
            {
                return minutes + " minutes ago";
            }
            else
            {
                return seconds + " seconds ago";
            }
        }
    }
}
