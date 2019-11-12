using BRQ.HRTProject.Aplicacao.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BRQ.HRTProject.Aplicacao.Interfaces
{
    public interface IEmpresaService
    {
        void Add(CadastroEmpresaViewModel obj);
        IEnumerable<EmpresaViewModel> GetAll();
        EmpresaViewModel GetById(int id);
        void Update(CadastroEmpresaViewModel obj, int id);
    }
}
