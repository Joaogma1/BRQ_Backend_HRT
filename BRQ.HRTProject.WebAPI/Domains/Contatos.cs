using System;
using System.Collections.Generic;

namespace BRQ.HRTProject.WebAPI.DomainsContextDir
{
    public partial class Contatos
    {
        public int Id { get; set; }
        public string Contato { get; set; }
        public int FkTipoContato { get; set; }
        public int FkPessoa { get; set; }

        public Pessoas FkPessoaNavigation { get; set; }
        public TiposContatos FkTipoContatoNavigation { get; set; }
    }
}
