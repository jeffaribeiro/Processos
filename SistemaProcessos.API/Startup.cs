using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SistemaProcessos.Business.Interfaces;
using SistemaProcessos.Business.Interfaces.Implementacao;
using SistemaProcessos.Data.Context;
using SistemaProcessos.Data.Persistencia;
using SistemaProcessos.Data.Repositorios;
using SistemaProcessos.Domain.Persistencia;
using SistemaProcessos.Domain.Repositorios;
using SistemaProcessos.Services.Implementacao;
using SistemaProcessos.Services.Interfaces;
using Swashbuckle.AspNetCore.Swagger;

namespace SistemaProcessos.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<MyContext, MyContext>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddTransient<IEmpresaService, EmpresaService>();
            services.AddTransient<IProcessoService, ProcessoService>();

            services.AddTransient<IEmpresaBusiness, EmpresaBusiness>();
            services.AddTransient<IProcessoBusiness, ProcessoBusiness>();
            
            services.AddTransient<IEmpresaRepository, EmpresaRepository>();
            services.AddTransient<IProcessoRepository, ProcessoRepository>();

            services.AddMvc();

            services.AddSwaggerGen(x => {
                x.SwaggerDoc("v1", new Info { Title = "SistemaProcessos", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
            app.UseStaticFiles();
            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "SistemaProcessos - V1");
            });
            app.UseDeveloperExceptionPage();
        }

    }
}
