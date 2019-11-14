
using System;
using System.Collections.Generic;
using System.Text;

namespace BRQ.HRTProject.Aplicacao.ViewModels
{
    public class SkillViewModel
    {

        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public int FkTipoSkill { get; set; }

        public TipoSkillViewModel FkTipoSkillNavigation { get; set; }
        public ICollection<SkillPessoaViewModel> SkillPessoa { get; set; }
    }
}
