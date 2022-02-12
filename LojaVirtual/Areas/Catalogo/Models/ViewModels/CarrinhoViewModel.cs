using LojaDeMateriais.Models;
using LojaVirtual.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Areas.Catalogo.Models
{
    public class CarrinhoViewModel
    {
        public List<Produto> Produtos { get; set; }

        public List<Vendas> Vendas { get; set; }

        public float ValorTotal { get; set; }
    }
}
