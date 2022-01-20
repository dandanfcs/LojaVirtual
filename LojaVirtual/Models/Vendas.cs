using LojaDeMateriais.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Models
{
    public class Vendas : BaseModel
    {
        public DateTime Data { get; set; }
        public int IdPedido { get; set; }
        public int IdProduto { get; set; }
    }
}
