using BRQ.HRTProject.Dominio.Entidades;
using BRQ.HRTProject.Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BRQ.HRTProject.Infra.Data.Repositorios
{
    public class UsuarioRepository : RepositoryBase<Usuarios>, IUsuarioRepository
    {
        public UsuarioRepository(ContextoHRT dbContext) : base(dbContext)
        {
        }

        public Usuarios BuscarPorEmailSenha(string email, string senha)
        {
            using (ContextoHRT ctx = new ContextoHRT())
            {
                Usuarios usuarioBuscado = ctx.Usuarios.Include(y => y.FkPessoaNavigation).Include(x => x.FkTipoUsuarioNavigation).Where(x => x.Email == email && x.Senha == senha).FirstOrDefault();
                return usuarioBuscado;
            }
        }

        public bool EmailExists(string email)
        {
            using(ContextoHRT ctx = new ContextoHRT())
            {
                return ctx.Usuarios.AsNoTracking().Where(x => x.Email == email).FirstOrDefault() != null ? true : false;
            }
        }
    }
}
