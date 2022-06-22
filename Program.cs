using System;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;

namespace cSharp_mongodb
{
    class Program
    {
        
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                        .AddUserSecrets<Program>()
                        .Build();

            string mongoString = config["MONGOSTRING"];

            MongoClient dbClient = new MongoClient(mongoString);

            var dbList = dbClient.ListDatabases().ToList();

            Console.WriteLine(" Databases on this server:");

            foreach (var db in dbList)
            {
                Console.WriteLine(db);
            }
        }
    }
}
