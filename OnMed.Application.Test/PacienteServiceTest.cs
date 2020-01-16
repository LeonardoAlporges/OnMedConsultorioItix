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
        private readonly Mock<IPacienteRepository> pacienteRepositoryMock;

        public PacienteServiceTest()
        {
            this.pacienteRepositoryMock = new Mock<IPacienteRepository>();
        }
        [Fact]
        public void SalvarItemTest_QuandoSalvarNoBanco_RetornoOK()
        {
            PacienteViewModel pacienteView = new PacienteViewModel();
            pacienteView.Nome = "Teste";
            pacienteView.Nacimento = DateTime.Parse("2000/01/01T13:00:20");
            pacienteView.DataConsultaInicial = DateTime.Parse("2040-12-29T20:12:07.6030998-03:00");
            pacienteView.DataConsultaFinal = DateTime.Parse("2040-12-29T20:12:07.6030998-03:00");
            pacienteView.Observacao = "leo";

            this.pacienteRepositoryMock.Setup(x => x.BuscarData(pacienteView.DataConsultaInicial)).Returns(true);

            var pacienteService = new PacienteService(pacienteRepositoryMock.Object);

            var resultadoEsperado = pacienteService.SalvarItem(pacienteView);

            Assert.True(resultadoEsperado);
        }
        [Fact]
        public void DataTest_RangerDatas_RetornoTrue()
        {
            DateTime DataInicio = DateTime.Parse("2040-12-29T20:12:07.6030998-03:00");

            var  resultado = this.pacienteRepositoryMock.Setup(x => x.BuscarData(DataInicio)).Returns(true);

            var pacienteService = new PacienteService(pacienteRepositoryMock.Object);

            var resultadoEsperado = pacienteService.BuscarData(DataInicio);

            Assert.True(resultadoEsperado);
        }
    }
}

