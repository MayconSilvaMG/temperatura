using Microsoft.IdentityModel.Protocols;
using MongoDB.Driver;
using System;
using System.Configuration;

namespace temperatura
{
    public class DadoTemperatura
    {
        /*public MongoDatabase Database;
        public String DataBaseName = "Temperatura";
        string conexaoMongoDB = "";

        [Obsolete]
        public DadoTemperatura()
        {

            conexaoMongoDB = ConfigurationManager.ConnectionStrings["testeTemperatura"].ConnectionString;
            var temperatura = new MongoClient(conexaoMongoDB);
            var tempo = temperatura.GetServer();

            Database = tempo.GetDatabase(DataBaseName);
        }*/

        public int Tempo { get; set; }
        public double Temperatura { get; set; }

        public DadoTemperatura(int tempo, double temperatura)
        {
            Tempo = tempo;
            Temperatura = temperatura;
        }

        public DadoTemperatura()
        {
        }
    }
}
