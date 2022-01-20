using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaDeMateriais.Models
{
    public class Colaborador :BaseModel
    {
        public string Nome { get; set; }
        public string Endereço { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Cpf { get; set; }
        public string Senha { get; set; }
    }
}
