using OnMed.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnMed.Domain.Repository
{
    public interface IPacienteRepository
    {
        IEnumerable<Paciente> ObterPaciente();
        void SalvarItem(Paciente paciente);
        bool BuscarData(DateTime dataInicial);
    }
}
