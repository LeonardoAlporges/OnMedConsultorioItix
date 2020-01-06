using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using OnMed.Application.Service;
using OnMed.Application.Service.Interface;
using OnMed.Domain.Repository;
using OnMed.Infra.Data.Context;
using OnMed.Infra.Data.Repository;

namespace OnMedConsultorio
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
            services.AddCors(options =>
            {
                options.AddPolicy("EnableCORS", buider =>
                {
                    buider
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .Build();
                });
            });
            services.AddScoped<IPacienteService, PacienteService>();
            services.AddScoped<IPacienteRepository, PacienteRepository>();
            services.AddControllers();
            services.AddDbContextPool<OnMedContext>(this.Builder());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors("EnableCORS");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        public Action<DbContextOptionsBuilder> Builder()
        {
            Action<SqlServerDbContextOptionsBuilder> sqlOptions = null;
            var migrationsAssemblyName = "OnMed.Infra.Data.Migrations";
            if (!string.IsNullOrEmpty(migrationsAssemblyName))
                sqlOptions = (options) => options.MigrationsAssembly(migrationsAssemblyName);

            return options => options.UseSqlServer(this.Configuration.GetSection("ConnectionStrings:DefaultConnection").Value, sqlOptions);
        }

    }
}
