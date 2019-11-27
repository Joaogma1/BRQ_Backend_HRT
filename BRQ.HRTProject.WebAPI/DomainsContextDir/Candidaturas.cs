using System;
using System.Collections.Generic;

namespace BRQ.HRTProject.WebAPI.DomainsContextDir
{
    public partial class Candidaturas
    {
        public int Id { get; set; }
        public int FkVaga { get; set; }
        public int FkPessoa { get; set; }

        public Pessoas FkPessoaNavigation { get; set; }
        public Vagas FkVagaNavigation { get; set; }
    }
}
