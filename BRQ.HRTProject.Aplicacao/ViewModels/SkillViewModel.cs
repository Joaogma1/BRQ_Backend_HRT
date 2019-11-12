
using System;
using System.Collections.Generic;
using System.Text;

namespace BRQ.HRTProject.Aplicacao.ViewModels
{
    public class SkillViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public TipoSkillViewModel FkIdTipoSkillNavigation { get; set; }
        public ICollection<SkillPessoaViewModel> SkillPessoa { get; set; }
    }
}
