using BRQ.HRTProject.Aplicacao.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BRQ.HRTProject.Aplicacao.Interfaces
{
    public interface IBeneficioService
    {
        void Add(CadastroBeneficioViewModel obj);
        IEnumerable<BeneficioViewModel> GetAll();
        BeneficioViewModel GetById(int id);
        void Update(CadastroBeneficioViewModel obj, int id);


    }
}
