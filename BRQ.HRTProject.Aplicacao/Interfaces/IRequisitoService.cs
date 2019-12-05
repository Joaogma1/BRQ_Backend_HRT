
using BRQ.HRTProject.Aplicacao.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BRQ.HRTProject.Aplicacao.Interfaces
{
    public interface IRequisitoService
    {
        void CadastrarRequisito(CadastroRequisitoViewModel dadosRequisito, int idVaga);

        void EditarRequisito(RequisitoViewModel dadosRequisitos, int id);

        List<RequisitoViewModel> ListarRequisitos();

        RequisitoViewModel GetByID(int id);
    }
}
