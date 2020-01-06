﻿using OnMed.Application.Service.Interface;
using OnMed.Application.ViewModal;
using OnMed.Domain.Repository;
using OnMed.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnMed.Application.Service
{
    public class PacienteService : IPacienteService
    {
        private IPacienteRepository pacienteRepository;

        public PacienteService()
        {
        }


        public PacienteService(IPacienteRepository pacienteRepositoryParam)
        {
            this.pacienteRepository = pacienteRepositoryParam;
        }

        public IEnumerable<PacienteViewModel> ObterPaciente()
        {
            var listaPaciente = this.pacienteRepository.ObterPaciente();
            var listaPacienteViewModel = new List<PacienteViewModel>();
            foreach (var paciente in listaPaciente)
            {
                var pacienteViewModel = new PacienteViewModel(paciente.Nome, paciente.Nacimento, paciente.DataConsultaInicial, paciente.DataConsultaFinal, paciente.Observacao);
                listaPacienteViewModel.Add(pacienteViewModel);
            }
            return listaPacienteViewModel;
        }

        public bool SalvarItem(PacienteViewModel pacienteViewModel)
        {
            var teste = this.pacienteRepository.BuscaNome(pacienteViewModel.DataConsultaInicial);
            if(teste == false)
            {
                Console.WriteLine("Mesmo Ranger");
                return false;
            }
            else
            {
                var Paciente = new Paciente(pacienteViewModel.Nome, pacienteViewModel.Nacimento, pacienteViewModel.DataConsultaInicial, pacienteViewModel.DataConsultaFinal, pacienteViewModel.Observacao);
                this.pacienteRepository.SalvarItem(Paciente);
                
                return true;

            }

            
        }
    }
}
