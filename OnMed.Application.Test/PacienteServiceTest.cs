using Moq;
using OnMed.Application.Service;
using OnMed.Application.Service.Interface;
using OnMed.Application.ViewModal;
using OnMed.Domain.Repository;
using System;
using Xunit;

namespace OnMed.Application.Test
{
    public class PacienteServiceTest
    {
       
        [Fact]
        public void SalvarItemTest_QuandoSalvarNoBanco_RetornoOK()
        {
            PacienteViewModel pacienteView = new PacienteViewModel();
            pacienteView.Nome = "Teste";
            pacienteView.Nacimento = DateTime.Parse("2000/01/01T13:00:20");
            pacienteView.DataConsultaInicial = DateTime.Parse("2040-12-29T20:12:07.6030998-03:00");
            pacienteView.DataConsultaFinal = DateTime.Parse("2040-12-29T20:12:07.6030998-03:00");
            pacienteView.Observacao = "leo";


            PacienteService paciente = new PacienteService();

            var resultadoEsperado = paciente.SalvarItem(pacienteView);

            Assert.True(resultadoEsperado);
        }
    }
}
