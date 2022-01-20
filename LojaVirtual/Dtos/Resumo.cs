﻿using LojaDeMateriais.Models;
using LojaVirtual.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Dtos
{
    public class Resumo
    {
        public List<Produto> Produtos {get; set;}

        public Vendas Vendas { get; set; }

    }
}