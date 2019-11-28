using System;
using System.Collections.Generic;

namespace BRQ.HRTProject.WebAPI.DomainsContextDir
{
    public partial class Vagas
    {
        public Vagas()
        {
            Candidaturas = new HashSet<Candidaturas>();
            Requisitos = new HashSet<Requisitos>();
        }

        public int Id { get; set; }
        public string Titulo { get; set; }
        public DateTime DtPublicacao { get; set; }
        public string Descricao { get; set; }
        public int? CargaHoraria { get; set; }
        public bool? StatusSituacao { get; set; }
        public int FkEmpresa { get; set; }
        public int? FkPessoa { get; set; }

        public Empresas FkEmpresaNavigation { get; set; }
        public Pessoas FkPessoaNavigation { get; set; }
        public ICollection<Candidaturas> Candidaturas { get; set; }
        public ICollection<Requisitos> Requisitos { get; set; }
    }
}
