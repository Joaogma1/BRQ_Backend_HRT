using System;
using System.Collections.Generic;

namespace BRQ.HRTProject.Dominio.Entidades
{
    public partial class Usuarios
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public bool? StatusAtivo { get; set; }
        public int FkTipoUsuario { get; set; }
        public int FkPessoa { get; set; }

        public Pessoas FkPessoaNavigation { get; set; }
        public TiposUsuarios FkTipoUsuarioNavigation { get; set; }
    }
}
