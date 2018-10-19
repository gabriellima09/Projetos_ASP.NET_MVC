using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LojaNET.DAL
{
    public class SerializadorHelper
    {
        public static void Serializar(string arquivo, object dados)
        {
            using (var stream = new StreamWriter(arquivo))
            {
                var serializador = new XmlSerializer(dados.GetType());
                serializador.Serialize(stream, dados);
            }
        }

        public static object Deserializar(string arquivo, Type tipo)
        {
            object retorno = null;

            using (var stream = new StreamReader(arquivo))
            {
                var serializador = new XmlSerializer(tipo);

                retorno = serializador.Deserialize(stream);
            }

            return retorno;
        }
    }
}
