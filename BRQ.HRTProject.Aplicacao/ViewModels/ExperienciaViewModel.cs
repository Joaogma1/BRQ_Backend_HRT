using System;
using System.Collections.Generic;
using System.Text;

namespace BRQ.HRTProject.Aplicacao.ViewModels
{
#warning
    public class ExperienciaViewModel
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Instituicao { get; set; }
        public string Descricao { get; set; }
        public DateTime? DtInicio { get; set; }
        public DateTime? DtFim { get; set; }
        public int FkTipoExperiencia { get; set; }
        public int FkPessoa { get; set; }
        public TipoExperienciaViewModel FkTipoExperienciaNavigation { get; set; }
    }
}
