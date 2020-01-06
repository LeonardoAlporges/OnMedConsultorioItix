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
            int result = DateTime.Compare(pacienteViewModel.DataConsultaFinal, pacienteViewModel.DataConsultaInicial);
            if (result < 0)
            {
                Console.WriteLine("Erro!!! Dia final e menor que dia inicial");
                return BadRequest();

            }
            else if (result == 0)
            {
                Console.WriteLine("As datas sao iguais");
                BadRequest();
                return BadRequest();
            }
            else if (result > 0)
            {
               var verificar = this.pacienteService.SalvarItem(pacienteViewModel);

                if (verificar == true)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
    }
}