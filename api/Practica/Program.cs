
using System;
using System.Configuration;




namespace practica
{
    class Program
    {
        static void Main(string[] args)
        {

            string town;

            var ConnectionAPI = new ConnectionAPI();
            Console.Write("Enter the name of the city: ");
            town = Console.ReadLine();
            Console.WriteLine();
            ConnectionAPI.api(town, ConfigurationManager.AppSettings["apiId"]);
        }
    }
    }

