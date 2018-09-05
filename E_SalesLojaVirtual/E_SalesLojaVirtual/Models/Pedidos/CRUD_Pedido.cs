using E_SalesLojaVirtual.Models.AutenticacaoCliente;
using E_SalesLojaVirtual.Models.CarrinhoDeCompras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Web.Mvc;
using E_SalesLojaVirtual.Models.Produtos;

namespace E_SalesLojaVirtual.Models.Pedidos
{
    public class CRUD_Pedido
    {
        public void SalvarPedido(Pedido pedido)
        {
            XElement xmlPedidos = XElement.Load(HttpContext.Current.Server.MapPath("~/App_Data/Pedidos.xml"));

            XElement x = new XElement("pedido");
            x.Add(new XAttribute("id", pedido.id));
            x.Add(new XAttribute("valorPedido", pedido.valorPedido));
            x.Add(new XAttribute("dataPedido", pedido.dataPedido));
            x.Add(new XAttribute("idCliente", pedido.carrinho.cliente.id));

            xmlPedidos.Add(x);
            xmlPedidos.Save(HttpContext.Current.Server.MapPath("~/App_Data/Pedidos.xml"));

            SalvarItensPedido(pedido);
        }

        public void SalvarItensPedido(Pedido pedido)
        {
            foreach (var item in pedido.carrinho.produtos)
            {
                XElement xmlItens = XElement.Load(HttpContext.Current.Server.MapPath("~/App_Data/ItensPedidos.xml"));

                XElement y = new XElement("itensPedido");
                y.Add(new XAttribute("id", item.id));
                y.Add(new XAttribute("descricao", item.descricao));
                y.Add(new XAttribute("valor", item.valor));
                y.Add(new XAttribute("idTipo", item.idTipo));
                y.Add(new XAttribute("imagem", item.imagem));
                y.Add(new XAttribute("idPedido", pedido.id));
                y.Add(new XAttribute("idCliente", pedido.carrinho.cliente.id));

                xmlItens.Add(y);
                xmlItens.Save(HttpContext.Current.Server.MapPath("~/App_Data/ItensPedidos.xml"));
            }
        }

        public List<Pedido> ListarPedidos(int idCliente)
        {
            List<Pedido> listaPedidos = new List<Pedido>();
            XElement xml = XElement.Load(HttpContext.Current.Server.MapPath("~/App_Data/Pedidos.xml"));

            foreach (XElement x in xml.Elements().Where(p => p.Attribute("idCliente").Value.Equals(idCliente.ToString())))
            {
                Pedido pedido = new Pedido()
                {
                    id = x.Attribute("id").Value,
                    valorPedido = Convert.ToDouble(x.Attribute("valorPedido").Value),
                    dataPedido = x.Attribute("dataPedido").Value,
                };                

                pedido.carrinho = new Carrinho()
                {
                    produtos = RetornaProdutos(pedido.id)
                };

                listaPedidos.Add(pedido);
            }
            return listaPedidos;
        }

        public List<Produto> RetornaProdutos(string idPedido)
        {
            List<Produto> listaProdutos = new List<Produto>();
            XElement xml = XElement.Load(HttpContext.Current.Server.MapPath("~/App_Data/ItensPedidos.xml"));

            foreach (XElement x in xml.Elements().Where(p => p.Attribute("idPedido").Value.Equals(idPedido)))
            {
                Produto produto = new Produto()
                {
                    id = Convert.ToInt64(x.Attribute("id").Value),
                    descricao = x.Attribute("descricao").Value,
                    valor = Convert.ToDouble(x.Attribute("valor").Value),
                    idTipo = Convert.ToInt32(x.Attribute("idTipo").Value),
                    imagem = x.Attribute("imagem").Value,
                    idPedido = x.Attribute("idPedido").Value
                };
                listaProdutos.Add(produto);
            }
            return listaProdutos;
        }

        public Cliente RetornaCliente(int idCliente)
        {
            List<Cliente> listaClientes = new List<Cliente>();
            XElement xml = XElement.Load(HttpContext.Current.Server.MapPath("~/App_Data/Clientes.xml"));

            foreach (XElement x in xml.Elements().Where(p => p.Attribute("id").Value.Equals(idCliente.ToString())))
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

            return listaClientes.First();
        }
    }
}