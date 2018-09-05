using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace E_SalesLojaVirtual.Models.AutenticacaoCliente
{
    public class CRUD_Cliente
    {
        public void CadastrarCliente(Cliente cliente)
        {
            XElement xml = XElement.Load(HttpContext.Current.Server.MapPath("~/App_Data/Clientes.xml"));

            XElement x = new XElement("cliente");
            x.Add(new XAttribute("id", (xml.Elements("cliente").ToList().Count()).ToString()));
            x.Add(new XAttribute("nome", cliente.nome));
            x.Add(new XAttribute("sobrenome", cliente.sobrenome));
            x.Add(new XAttribute("email", cliente.email));
            x.Add(new XAttribute("endereco", cliente.endereco));
            x.Add(new XAttribute("senha", cliente.senha));

            xml.Add(x);
            xml.Save(HttpContext.Current.Server.MapPath("~/App_Data/Clientes.xml"));
        }

        public void EditarCliente(Cliente cliente)
        {
            XElement xml = XElement.Load(HttpContext.Current.Server.MapPath("~/App_Data/Clientes.xml"));
            XElement x = xml.Elements().Where(p => p.Attribute("email").Value.Equals(cliente.email.ToString())).First();

            if (x != null)
            {
                x.Attribute("senha").SetValue(cliente.senha);
            }

            xml.Save(HttpContext.Current.Server.MapPath("~/App_Data/Clientes.xml"));
        }

        public void ExcluirCliente(int id)
        {
            XElement xml = XElement.Load(HttpContext.Current.Server.MapPath("~/App_Data/Clientes.xml"));
            XElement x = xml.Elements().Where(p => p.Attribute("id").Value.Equals(id.ToString())).First();

            if (x != null)
            {
                x.Remove();
            }
            xml.Save("Clientes.xml");
        }

        public List<Cliente> ListarClientes()
        {
            List<Cliente> listaClientes = new List<Cliente>();
            XElement xml = XElement.Load(HttpContext.Current.Server.MapPath("~/App_Data/Clientes.xml"));

            foreach (XElement x in xml.Elements())
            {
                Cliente cliente = new Cliente()
                {
                    id = Convert.ToInt32(x.Attribute("id").Value),
                    nome = x.Attribute("nome").Value,
                    email = x.Attribute("email").Value,
                    endereco = x.Attribute("endereco").Value,
                    senha = x.Attribute("senha").Value
                };
                listaClientes.Add(cliente);
            }
            return listaClientes;
        }

        public Cliente RetornaCliente(string email, string senha)
        {
            Cliente cliente = new Cliente();

            cliente = ListarClientes().Find(x => x.email == email && x.senha == senha);

            return cliente;
        }
    }
}