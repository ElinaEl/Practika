using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using Practica;

class ConnectionAPI
{
    public void api(string town, string key)
    {
        string zp = "http://api.openweathermap.org/data/2.5/weather?q=" + town + "&units=metric&appid=" + key;
        HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(zp);
        HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();

        using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
        {
            string result = streamReader.ReadToEnd();
            Info info = JsonConvert.DeserializeObject<Info>(result);

            Console.WriteLine($"Temperature in {info.Name}: {info.Main.}°C \n");
        }
        Console.ReadLine();
    }
}
