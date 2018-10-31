using LojaNet.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaNET.DAL
{
    public class LojaContext : DbContext
    {
        public LojaContext() : base(DBHelper.connString)
        {
            var chamada = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }

        public DbSet<Produto> Produtos { get; set; }

    }
}
