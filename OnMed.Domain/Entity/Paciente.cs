using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OnMed.Domain.Entity
{
    public class Paciente
    {
        
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public DateTime Nacimento { get; set; }
        public DateTime DataConsultaInicial { get; set; }
        public DateTime DataConsultaFinal { get; set; }
        public string Observacao { get; set; }

        public Paciente()
        {
            
        }

        public Paciente(string nome, DateTime nacimento, DateTime dataconsultainicial, DateTime dataconsultafinal, string observacao)
        {
            this.Nome = nome;
            this.Nacimento = nacimento;
            this.DataConsultaInicial = dataconsultainicial;
            this.DataConsultaFinal = dataconsultafinal;
            this.Observacao = observacao;
        }
    }
}
