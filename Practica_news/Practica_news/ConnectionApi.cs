using Newtonsoft.Json;
using Practica_news;
using System;
using System.IO;
using System.Net;

namespace Practica_news
{
    public class ConnectionApi
    {
        public void api(string answer, string key)
        {
            if (answer.ToLower().Equals("да"))
            {
                string url = "http://newsapi.org/v2/top-headlines?country=ru&apiKey=" + key;

                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();


                using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
                {
                    string result = streamReader.ReadToEnd();
                    arrays arrays = JsonConvert.DeserializeObject<arrays>(result);
                    Console.WriteLine("Новости дня:\n");

                    foreach (Artickle article in arrays.Articles)
                    {
                        Console.Write("Источник: {0} \nЗаголовок: {1}\nОписание: {2}\nСсылка на новость в источнике:", article.Source.Name, article.Title, article.Description);
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine(article.Url);
                        Console.ResetColor();
                        Console.WriteLine();
                        Console.WriteLine();
                    }
                }
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("До свидания!");
            }
        }
    }
}

