
using System;
using System.Collections.Generic;
using System.Text;
#warning
namespace BRQ.HRTProject.Aplicacao.ViewModels
{
    public class VagaViewModel
    {
        public string Titulo { get; set; }
        public DateTime DtPublicacao { get; set; }
        public string Descricao { get; set; }
        public string Localidade { get; set; }
        public TimeSpan? HorarioInicio { get; set; }
        public TimeSpan? HorarioFim { get; set; }
        public int TipoVinculo { get; set; }
        public int? FkEmpresa { get; set; }
        public bool? StatusSituacao { get; set; }
        public decimal? Salario { get; set; }
        public int? IdColaborador { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
    }
}
