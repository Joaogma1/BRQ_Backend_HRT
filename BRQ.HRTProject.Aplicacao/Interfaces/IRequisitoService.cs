
using BRQ.HRTProject.Aplicacao.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BRQ.HRTProject.Aplicacao.Interfaces
{
    public interface IRequisitoService
    {
        void CadastrarRequisito(RequisitoViewModel dadosRequisito);

        void EditarRequisito(RequisitoViewModel dadosRequisitos, int id);

        List<RequisitoViewModel> ListarRequisitos();

        RequisitoViewModel GetByID(int id);
    }
}
