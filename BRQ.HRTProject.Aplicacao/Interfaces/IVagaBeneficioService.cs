
using BRQ.HRTProject.Aplicacao.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BRQ.HRTProject.Aplicacao.Interfaces
{
    public interface IVagaBeneficioService
    {
        IEnumerable<VagaBeneficioViewModel> GetAll();
        VagaBeneficioViewModel GetById(int id);
        void Add(CadastroVagaBeneficioViewModel obj);
        void Update(CadastroVagaBeneficioViewModel obj, int id);
    }
}
