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
        IEnumerable<CandidaturaPorPessoaViewModel> GetByUserId(int userId);
        IEnumerable<CandidaturaPorVagaViewModel> GetByVagaId(int vagaId);
    }
}
