using ExemploServicoWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ExemploServicoWebAPI.Controllers
{
    public class WebAPIController : ApiController
    {
        private static IEnumerable<Fornecedor> ObterFornecedores()
        {
            var list = new List<Fornecedor>();

            list.Add(new Fornecedor() { id = list.Count + 1, nome = "ABCD LDTA.", email = "abcd@empresa.com.br" });
            list.Add(new Fornecedor() { id = list.Count + 1, nome = "EFGH S.A.", email = "efgh@empresa.com.br" });

            return list;
        }

        // GET api/<controller>
        public IEnumerable<Fornecedor> Get()
        {
            return ObterFornecedores();
        }

        // GET api/<controller>/5
        public Fornecedor Get(int id)
        {
            return ObterFornecedores().FirstOrDefault(x => x.id == id);
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}