using BRQ.HRTProject.Aplicacao.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BRQ.HRTProject.Aplicacao.Interfaces
{
    public interface ICadastroPessoaService 
    {
        void Add(CadastroPessoaViewModel obj);
        void Update(EditarPessoaViewModel obj, int idPessoa);

        bool CpfExists(String cpf);
    }
}
