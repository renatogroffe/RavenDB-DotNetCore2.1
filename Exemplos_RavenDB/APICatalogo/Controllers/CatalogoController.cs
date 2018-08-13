using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Raven.Client.Documents;

namespace APICatalogo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogoController : ControllerBase
    {
        private IConfiguration _configuration;

        public CatalogoController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet("produtos/{codigo}")]
        public ActionResult<Produto> GetProduto(string codigo)
        {
            Produto prod = null;
            if (codigo.StartsWith("PROD"))
            {
                var documentStore = new DocumentStore()
                {
                    Urls = new string[] { _configuration.GetConnectionString("ConexaoRavenDB") }
                };
                documentStore.Initialize();

                using (var session = documentStore.OpenSession("DBCatalogo"))
                {
                    prod = session.Query<Produto>()
                        .FirstOrDefault(p => p.Id == codigo);
                }

                documentStore.Dispose();
            }

            if (prod != null)
                return prod;
            else
                return NotFound();
        }

        [HttpGet("servicos/{codigo}")]
        public ActionResult<Servico> GetServico(string codigo)
        {
            Servico serv = null;
            if (codigo.StartsWith("SERV"))
            {
                var documentStore = new DocumentStore()
                {
                    Urls = new string[] { _configuration.GetConnectionString("ConexaoRavenDB") }
                };
                documentStore.Initialize();

                using (var session = documentStore.OpenSession("DBCatalogo"))
                {
                    serv = session.Query<Servico>()
                        .FirstOrDefault(s => s.Id == codigo);
                }

                documentStore.Dispose();
            }

            if (serv != null)
                return serv;
            else
                return NotFound();
        }
    }
}