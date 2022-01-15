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
        public ColaboradorRepository(ApplicationContext context):base(context)
        {
        }

        public void AdicionarColaborador(Colaborador colab)
        {
            context.Add(colab);
            context.SaveChanges();
        }
    }
}
