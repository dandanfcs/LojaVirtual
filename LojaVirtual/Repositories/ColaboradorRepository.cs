using LojaDeMateriais.Context;
using LojaDeMateriais.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaDeMateriais.Repositories
{
    public class ColaboradorRepository : BaseRepository<Colaborador>, IColaboradorRepository
    {
        public ColaboradorRepository(ApplicationContext context) : base(context)
        {
        }

        public void AdicionarColaborador(Colaborador colab)
        {
            context.Add(colab);
            context.SaveChanges();
        }
        public bool Logar(string email, string senha)
        {
            return VerificarSeExisteColaborador(email, senha);
        }

        private bool VerificarSeExisteColaborador(string email, string senha)
        {
            var colaboradores = dbSet.ToList();

            foreach (var colarborador in colaboradores)
            {
                if (colarborador.Email == email && colarborador.Senha == senha)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
