
using BRQ.HRTProject.Aplicacao.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BRQ.HRTProject.Aplicacao.Interfaces
{
    public interface ITipoContatoService
    {
        void Update(CadastroTipoContatoViewModel obj, int id);
        void Add(CadastroTipoContatoViewModel obj);
        IEnumerable<TipoContatoViewModel> GetAll();
    }
}
