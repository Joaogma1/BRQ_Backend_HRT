
using BRQ.HRTProject.Aplicacao.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BRQ.HRTProject.Aplicacao.Interfaces
{
    public interface IVagaService
    {
        void CadastrarVaga(CadastroVagaViewModel dadosVaga);

        void AtribuirFuncionarioVaga(int idVaga, int idFuncionario);

        void EditarVaga(EdicaoVagaViewModel dadosVaga,  int id);

        List<VagaViewModel> ListarVagas();

        VagaViewModel GetByID(int id);
    }
}
