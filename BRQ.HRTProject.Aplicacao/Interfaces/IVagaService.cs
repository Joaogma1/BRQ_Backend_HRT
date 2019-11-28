
using BRQ.HRTProject.Aplicacao.ViewModels;
using BRQ.HRTProject.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace BRQ.HRTProject.Aplicacao.Interfaces
{
    public interface IVagaService
    {
        void CadastrarVaga(CadastroVagaViewModel dadosVaga);

        void AtribuirFuncionarioVaga(int idVaga, int idFuncionario);

        void EditarVaga(Vagas dadosVaga);

        List<VagaViewModel> ListarVagas();

        VagaViewModel GetByID(int id);
    }
}
