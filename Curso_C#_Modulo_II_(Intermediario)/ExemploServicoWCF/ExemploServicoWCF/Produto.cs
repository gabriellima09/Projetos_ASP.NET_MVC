using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ExemploServicoWCF
{
    [DataContract]
    public class Produto
    {
        [IgnoreDataMember]
        public int id { get; set; }
        [DataMember]
        public string nome { get; set; }
        [DataMember]
        public decimal preco { get; set; }
    }
}