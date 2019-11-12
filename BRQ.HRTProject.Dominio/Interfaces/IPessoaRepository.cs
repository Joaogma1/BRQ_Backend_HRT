﻿using BRQ.HRTProject.Dominio.Entidades;
using BRQ.HRTProject.Dominio.Interfaces;
using System.Collections.Generic;

namespace BRQ.HRTProject.Dominio.Interfaces
{
    public interface IPessoaRepository : IBaseRepository<Pessoas>
    {
        Pessoas BuscarPessoaPorMatricula(string matricula);

        void AtribuirSKill(SkillPessoa dados);

        void DesAtribuirSkill(int id);

        List<Pessoas> BuscarTodosDados();
        Pessoas BuscarTodosDadosPorID(int id);
    }
}