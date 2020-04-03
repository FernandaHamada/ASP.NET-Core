using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace web
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //TEMPORÁRIO cria uma nova instanica do serviço solicitado
//           services.AddTransient<ICatalog, Catalog>();
//           services.AddTransient<IReport, Report>();

            // ÚNICA INSTANCIA deste serviço para cada requisição através do navegador
//           services.AddScoped<ICatalog, Catalog>();
//           services.AddScoped<IReport, Report>();

            // INSTANCIA ÚNICA, trabalha com a mesma instancia
            Catalog catalog = new Catalog();
            services.AddSingleton<ICatalog> (catalog);
            services.AddSingleton<IReport> (new Report(catalog));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Mecanismo de injeção de dependência, criando uma nova instancia da classe Catalog a partir da interface Icatalog
            ICatalog catalog = serviceProvider.GetService<ICatalog>();
            IReport report = serviceProvider.GetService<IReport>();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await report.Print(context);
                });
            });
        }
    }
}
