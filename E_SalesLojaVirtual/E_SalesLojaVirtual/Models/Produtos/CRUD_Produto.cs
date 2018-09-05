using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace E_SalesLojaVirtual.Models.Produtos
{
    public class CRUD_Produto
    {
        public static List<Produto> GetProdutos(tipoProduto tipo)
        {
            List<Produto> listaProdutos = new List<Produto>();
            XElement xml = XElement.Load(HttpContext.Current.Server.MapPath("~/App_Data/Produtos.xml"));

            foreach (XElement x in xml.Elements().Where(x => x.Attribute("idTipo").Value == Convert.ToString((int)tipo)))
            {
                Produto Produto = new Produto()
                {
                    id = Convert.ToInt64(x.Attribute("id").Value),
                    descricao = x.Attribute("descricao").Value,
                    valor = Convert.ToDouble(x.Attribute("valor").Value),
                    idTipo = Convert.ToInt32(x.Attribute("idTipo").Value),
                    imagem = "/Imagens/" + tipo.ToString() + "/" + x.Attribute("imagem").Value
                };

                listaProdutos.Add(Produto);
            }
            return listaProdutos;
        }
    }
}