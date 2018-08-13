using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APICatalogo
{
    public class Produto
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Tipo { get; set; }
        public double Preco { get; set; }
        public Fornecedor DadosFornecedor { get; set; }
    }

    public class Fornecedor
    {
        public string Codigo { get; set; }
        public string Nome { get; set; }
    }

    public class Servico
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public double ValorHora { get; set; }
    }
}