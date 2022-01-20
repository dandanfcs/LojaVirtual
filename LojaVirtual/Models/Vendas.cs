using LojaDeMateriais.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Models
{
    public class Vendas : BaseModel
    {
        public DateTime data { get; set; }
        public int idVenda { get; set; }
        public int idProduto { get; set; }
    }
}
