using BRQ.HRTProject.Aplicacao.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BRQ.HRTProject.Aplicacao.Interfaces
{
    public interface ICandidaturaService
    {
        void Add(CadastroCandidaturaViewModel obj, int idPessoa);
        void Remove(int id);
        IEnumerable<CadastroCandidaturaViewModel> GetByUserId(int userId);
        IEnumerable<CadastroCandidaturaViewModel> GetByVagaId(int vagaId);
    }
}
