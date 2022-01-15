using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaDeMateriais.Models
{
    public class Produto : BaseModel
    {
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public float Preco { get; set; }
        public string Categoria { get; set; }
        public string Tamanho { get; set; }
        public string Marca { get; set; }
        public string Cor { get; set; }
    }
}
