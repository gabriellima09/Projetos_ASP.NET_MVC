using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ExemploServicoWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Servico01" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Servico01.svc or Servico01.svc.cs at the Solution Explorer and start debugging.
    public class Servico01 : IServico01
    {
        public string DoWork()
        {
            return "Serviço Online - Esta mensagem veio de um serviço WCF";
        }

        public Produto PromocaoDia()
        {
            return new Produto() { id = 1, nome = "Mouse", preco = 15.99M };
        }
    }
}
