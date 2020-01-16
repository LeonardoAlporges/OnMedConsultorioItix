using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnMed.Application.Service.Interface;
using OnMed.Application.ViewModal;
using OnMed.Infra.Data.Context;

namespace OnMedConsultorio.api.Controllers
{
    [Route("api/pacientes")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private IPacienteService pacienteService;
        private readonly OnMedContext _context;

        

        public PacienteController(IPacienteService parametroPacienteService)
        {
            this.pacienteService = parametroPacienteService;
        }

        [HttpGet]
        public IEnumerable<PacienteViewModel> GetProdutos()
        {
            var lista = this.pacienteService.ObterPaciente();
            return lista;
        }

        [HttpPost]
        public ActionResult PostItem([FromBody]PacienteViewModel pacienteViewModel)
        {
            var resultado = this.pacienteService.CompararDatas(pacienteViewModel.DataConsultaFinal, pacienteViewModel.DataConsultaInicial);
            
            if (resultado == "Ok")
            {
                var SalvoSucesso = this.pacienteService.Salvo(pacienteViewModel);

                if (SalvoSucesso == true)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            else 
            {
                return BadRequest();
            }
        }
    }
}