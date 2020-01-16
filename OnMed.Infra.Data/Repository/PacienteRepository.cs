using OnMed.Domain.Entity;
using OnMed.Domain.Repository;
using OnMed.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnMed.Infra.Data.Repository
{
    public class PacienteRepository : IPacienteRepository
    {
        private OnMedContext context;

        public PacienteRepository(OnMedContext contextParam)
        {
            this.context = contextParam;
        }

        public PacienteRepository()
        {
        }

        public IEnumerable<Paciente> ObterPaciente()
        {
            var listaPaciente = this.context.Set<Paciente>().ToList();
            return listaPaciente;
        }

        public void SalvarItem(Paciente paciente)
        {
                this.context.Set<Paciente>().Add(paciente);
                this.context.SaveChanges();
        }


        public bool BuscarData(DateTime dataInicial)
        {
            var paciente = this.context.Set<Paciente>();
            foreach (Paciente paci in paciente)
            {
                if(paci.DataConsultaFinal > dataInicial && paci.DataConsultaInicial < dataInicial)
                {
                    return false;
                }               
            }
            return true;
           
        }

        
    }
}
