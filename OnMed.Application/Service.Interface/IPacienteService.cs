using OnMed.Application.ViewModal;
using OnMed.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnMed.Application.Service.Interface
{
    public interface IPacienteService
    {
        IEnumerable<PacienteViewModel> ObterPaciente();
        bool SalvarItem(PacienteViewModel paciente);
    }
}
