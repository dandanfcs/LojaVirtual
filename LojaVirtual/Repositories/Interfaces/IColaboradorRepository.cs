using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaDeMateriais.Models
{
   public interface IColaboradorRepository
    {
       void AdicionarColaborador(Colaborador colab);
       bool Logar(string email, string senha);
    }
}
