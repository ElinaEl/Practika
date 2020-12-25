using System;
using System.Configuration;

namespace Practica_news
{
    class Program
    {
        static void Main(string[] args)
        {

            string answer;

            var connectionApi = new ConnectionApi();

            Console.Write("Желаете увидеть новости? ");
            answer = Console.ReadLine();
            Console.WriteLine();
            connectionApi.api(answer, ConfigurationManager.AppSettings["ApiId"]);
        }
    }
}
