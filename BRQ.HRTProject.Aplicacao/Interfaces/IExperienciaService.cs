using BRQ.HRTProject.Aplicacao.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BRQ.HRTProject.Aplicacao.Interfaces
{
    public interface IExperienciaService
    {
        void Update(CadastroExperienciaViewModel obj, int id, int idPessoa);
        IEnumerable<ExperienciaViewModel> GetAll(int userId);
        IEnumerable<ExperienciaViewModel> ListarTodasExperiencias();
        ExperienciaViewModel BuscarExperienciaPorId(int id);
        void Add(CadastroExperienciaViewModel obj, int id);
    }
}
