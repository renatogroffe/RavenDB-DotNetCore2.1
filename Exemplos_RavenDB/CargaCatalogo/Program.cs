using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Raven.Client.Documents;

namespace CargaCatalogo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Para criar um servidor do RavenDB via Docker utilizar:
            // docker run -d -p 8080:8080 -p 38888:38888 ravendb/ravendb

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile($"appsettings.json");
            var configuration = builder.Build();

            var documentStore = new DocumentStore()
            {
                Urls = new string[] { configuration.GetConnectionString("ConexaoRavenDB") }
            };
            documentStore.Initialize();

            using (var session = documentStore.OpenSession("DBCatalogo"))
            {
                Console.WriteLine("Incluir produtos...");
                Carga.InserirDadosProdutos(session);

                Console.WriteLine("Incluir serviços...");
                Carga.InserirDadosServicos(session);
            }

            documentStore.Dispose();

            Console.WriteLine("Finalizado!");
            Console.ReadKey();
        }
    }
}