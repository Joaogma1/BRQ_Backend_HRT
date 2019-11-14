using BRQ.HRTProject.Aplicacao.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BRQ.HRTProject.Aplicacao.Interfaces
{
    public interface ICadastroPessoaService 
    {
        void Add(CadastroPessoaViewModel obj, LoginViewModel usuario);
        void Update(CadastroPessoaViewModel obj, int idPessoa);
    }
}
