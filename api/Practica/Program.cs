using Newtonsoft.Json;
using Practica;
using System;
using System.IO;
using System.Net;


namespace practica
{
    class Program
    {
        static void Main(string[] args)
        {
            //убери в конфиг
            string key = "a5c9fbdf29a1b4415a875b88ad996781";
            string town;

            Console.Write("Enter the name of the city: ");
            town = Console.ReadLine();
            Console.WriteLine();

            string zp = "http://api.openweathermap.org/data/2.5/weather?q=" + town + "&units=metric&appid=" + key;
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(zp);
            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
            {
                string result = streamReader.ReadToEnd();
                Tinfo tinfo = JsonConvert.DeserializeObject<Tinfo>(result);

                Console.WriteLine("The temperature in " + tinfo.Name + ": " + tinfo.Main.info + "°C \n");

            }
            Console.ReadLine();
        }
    }
}
