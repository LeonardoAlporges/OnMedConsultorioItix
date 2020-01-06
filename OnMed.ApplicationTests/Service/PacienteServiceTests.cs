using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OnMed.Application.Service;
using OnMed.Application.Service.Interface;
using OnMed.Application.ViewModal;
using OnMed.Domain.Repository;
using OnMed.Infra.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnMed.Application.Service.Tests
{
    [TestClass()]
    public class PacienteServiceTests
    {

        [TestMethod()]
        public void SalvarItemTest_QuandoSalvarNoBanco_RetornoOK()
        {
            PacienteViewModel pacienteView = new PacienteViewModel();
            pacienteView.Nome = "Teste";
            pacienteView.Nacimento = DateTime.Parse("2000/01/01");
            pacienteView.DataConsultaInicial = DateTime.Parse("2020-12-25");
            pacienteView.DataConsultaFinal = DateTime.Parse("2020-12-30");
            pacienteView.Observacao = "leo";

            Mock<IPacienteService> mock = new Mock<IPacienteService>();
            mock.Setup(x => x.SalvarItem(pacienteView));

            var resultadoEsperado = mock.Object.SalvarItem(pacienteView);

            Assert.AreEqual("certo", resultadoEsperado);
        }
    }
}