using BRQ.HRTProject.Aplicacao.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BRQ.HRTProject.Aplicacao.Interfaces
{
    public interface IContatoService
    {
        void Add(CadastroContatoViewModel obj);
        void Update(CadastroContatoViewModel obj, int id);
    }
}
