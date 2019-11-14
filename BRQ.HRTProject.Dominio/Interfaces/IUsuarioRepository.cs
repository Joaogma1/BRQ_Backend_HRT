using BRQ.HRTProject.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace BRQ.HRTProject.Dominio.Interfaces
{
    public interface IUsuarioRepository
    {
        Usuarios BuscarPorEmailSenha(string email, string senha);
    }
}
