﻿using LojaVirtual.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Repositories.Interfaces
{
    public interface IVendaRepository
    {
        void InicializarPedido(Venda venda);
        Venda BuscarVendaAberta();
    }
}
