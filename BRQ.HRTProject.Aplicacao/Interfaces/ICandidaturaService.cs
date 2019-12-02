using BRQ.HRTProject.Aplicacao.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BRQ.HRTProject.Aplicacao.Interfaces
{
    public interface ICandidaturaService
    {
        void Add(CandidaturaViewModel obj);
        void Remove(int id);
        IEnumerable<CandidaturaViewModel> GetByUserId(int userId);
        IEnumerable<CandidaturaViewModel> GetByVagaId(int vagaId);
    }
}
