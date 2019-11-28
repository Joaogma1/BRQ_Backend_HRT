using BRQ.HRTProject.Aplicacao.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BRQ.HRTProject.Aplicacao.Interfaces
{
    public interface IContatoService
    {
        void Add(CadastroContatoViewModel obj, int idPessoa);
        void Update(CadastroContatoViewModel obj, int id);
        void Remove(int id);
    }
}
