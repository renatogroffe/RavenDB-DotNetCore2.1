using Raven.Client.Documents.Session;

namespace CargaCatalogo
{
    public static class Carga
    {
        public static void InserirDadosProdutos(IDocumentSession session)
        {
            Produto prod00001 = new Produto();
            prod00001.Id = "PROD00001";
            prod00001.Nome = "Detergente";
            prod00001.Tipo = "Limpeza";
            prod00001.Preco = 5.75;
            prod00001.DadosFornecedor = new Fornecedor();
            prod00001.DadosFornecedor.Codigo = "FORN00001";
            prod00001.DadosFornecedor.Nome = "EMPRESA XYZ";
            session.Store(prod00001);

            Produto prod00002 = new Produto();
            prod00002.Id = "PROD00002";
            prod00002.Nome = "Martelo";
            prod00002.Tipo = "Ferramentas";
            prod00002.Preco = 50.70;
            prod00002.DadosFornecedor = new Fornecedor();
            prod00002.DadosFornecedor.Codigo = "FORN00002";
            prod00002.DadosFornecedor.Nome = "ABCD FERRAMENTAS";
            session.Store(prod00002);

            session.SaveChanges();
        }

        public static void InserirDadosServicos(IDocumentSession session)
        {
            Servico serv00001 = new Servico();
            serv00001.Id = "SERV00001";
            serv00001.Nome = "LIMPEZA PREDIAL";
            serv00001.ValorHora = 150.00;
            session.Store(serv00001);

            Servico serv00002 = new Servico();
            serv00002.Id = "SERV00002";
            serv00002.Nome = "GUARDA PATRIMONIAL";
            serv00002.ValorHora = 250.00;
            session.Store(serv00002);

            session.SaveChanges();
        }
    }
}