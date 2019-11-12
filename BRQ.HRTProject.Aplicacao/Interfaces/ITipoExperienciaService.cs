
using BRQ.HRTProject.Aplicacao.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BRQ.HRTProject.Aplicacao.Interfaces
{
    public interface ITipoExperienciaService 
    {
        void Update(CadastroTipoExperienciaViewModel obj, int id);
        void Add(CadastroTipoExperienciaViewModel obj);
        IEnumerable<TipoExperienciaViewModel> GetAll();
    }
}
