using System;
using System.Collections.Generic;

namespace BRQ.HRTProject.Dominio.Entidades
{
    public partial class Pessoas
    {
        public Pessoas()
        {
            Candidaturas = new HashSet<Candidaturas>();
            Contatos = new HashSet<Contatos>();
            Experiencias = new HashSet<Experiencias>();
            SkillPessoa = new HashSet<SkillPessoa>();
            Usuarios = new HashSet<Usuarios>();
            Vagas = new HashSet<Vagas>();
        }

        public int Id { get; set; }
        public string Matricula { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Complemento { get; set; }
        public int? NumeroEndereco { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }
        public bool StatusAlocacao { get; set; }

        public ICollection<Candidaturas> Candidaturas { get; set; }
        public ICollection<Contatos> Contatos { get; set; }
        public ICollection<Experiencias> Experiencias { get; set; }
        public ICollection<SkillPessoa> SkillPessoa { get; set; }
        public ICollection<Usuarios> Usuarios { get; set; }
        public ICollection<Vagas> Vagas { get; set; }
    }
}
