using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace temperatura
{
    static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            //Conectar no servidor
            var temperatura = new MongoClient("mongodb://localhost:27017");

            //Conectar no Banco de Dados 
            var database = temperatura.GetDatabase("testeTemperaturas");

            //Coleção onde vai armazenar o objeto Teste
            IMongoCollection<DadoTemperatura> colecao = database.GetCollection<DadoTemperatura>("temperaturas");

            InserirTeste(colecao);
        }

        private static void InserirTeste(IMongoCollection<DadoTemperatura> colecao)
        {
            DadoTemperatura d = new DadoTemperatura() { Temperatura = 0.0F, Tempo = 0 };
            colecao.InsertOne(d);
        }
    }
}
