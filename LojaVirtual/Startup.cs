using LojaDeMateriais.Context;
using LojaDeMateriais.Models;
using LojaDeMateriais.Repositories;
using LojaDeMateriais.Repositories.Interfaces;
using LojaVirtual.Repositories;
using LojaVirtual.Repositories.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddMvc();
            services.AddControllersWithViews();
            services.AddDbContext<ApplicationContext>(options =>
            options.UseMySql(Configuration.GetConnectionString("ApplicationContext"),
                    builder => builder.MigrationsAssembly("LojaVirtual")));
            //Parametros de UseMySql(var 1, var 2) -> Nome da classe de conexao com DbContext e nome do projeto Assembly

            services.AddTransient<IColaboradorRepository, ColaboradorRepository>();
            services.AddTransient<IProdutoRepository, ProdutoRepository>();
            services.AddTransient<IVendaRepository, VendaRepository>();
            services.AddTransient<IVendasRepository, VendasRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Produto}/{action=List}/{id?}");
            });
        }
    }
}
