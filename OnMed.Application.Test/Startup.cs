using Microsoft.Extensions.DependencyInjection;
using OnMed.Application.Service;
using OnMed.Application.Service.Interface;
using OnMed.Domain.Repository;
using OnMed.Infra.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;
using Xunit.DependencyInjection;

[assembly: TestFramework("OnMed.Application.Test.Startup", "AssemblyName")]

namespace OnMed.Application.Test
    {
        public class Startup : DependencyInjectionTestFramework
        {
            public Startup(IMessageSink messageSink) : base(messageSink) { }

            protected override void ConfigureServices(IServiceCollection services)
            {
                services.AddTransient<IPacienteService, PacienteService>();
                services.AddScoped<IPacienteRepository, PacienteRepository>();

        }
        }
    }

