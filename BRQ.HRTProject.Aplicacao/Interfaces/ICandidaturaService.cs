using BRQ.HRTProject.Aplicacao.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BRQ.HRTProject.Aplicacao.Interfacess
{
    public interface ICandidaturaService
    {
        void Candidatar(CandidaturaViewModel dadosCandidatura);
        void CancelarCandidatura(int id);
        List<ListarCandidaturaViewModel> ListarCandidaturasPorVagas(int idVaga);
    }
}
