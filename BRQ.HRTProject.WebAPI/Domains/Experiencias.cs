using System;
using System.Collections.Generic;

namespace BRQ.HRTProject.WebAPI.DomainsContextDir
{
    public partial class Experiencias
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Instituicao { get; set; }
        public string Descricao { get; set; }
        public DateTime? DtInicio { get; set; }
        public DateTime? DtFim { get; set; }
        public int FkTipoExperiencia { get; set; }
        public int FkPessoa { get; set; }

        public Pessoas FkPessoaNavigation { get; set; }
        public TiposExperiencias FkTipoExperienciaNavigation { get; set; }
    }
}
