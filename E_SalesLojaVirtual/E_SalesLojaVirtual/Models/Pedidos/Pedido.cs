using E_SalesLojaVirtual.Models.CarrinhoDeCompras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace E_SalesLojaVirtual.Models.Pedidos
{
    public class Pedido
    {
        public string id { get; set; }
        public double valorPedido { get; set; }
        public string dataPedido { get; set; }
        public Carrinho carrinho { get; set; }

        //public void SalvarPedido(string s)
        //{
        //    TratamentoXML.SalvarStringXmlParaArquivoXml(s, HttpContext.Current.Server.MapPath("~/App_Data/Pedidos.xml"));
        //}
    }
}