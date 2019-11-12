using System;
using BRQ.HRTProject.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BRQ.HRTProject.Infra.Data
{
    public partial class ContextoHRT : DbContext
    {
        public ContextoHRT()
        {
        }

        public ContextoHRT(DbContextOptions<ContextoHRT> options)
            : base(options)
        {
        }

        public virtual DbSet<Candidaturas> Candidaturas { get; set; }
        public virtual DbSet<Contatos> Contatos { get; set; }
        public virtual DbSet<Empresas> Empresas { get; set; }
        public virtual DbSet<Experiencias> Experiencias { get; set; }
        public virtual DbSet<Pessoas> Pessoas { get; set; }
        public virtual DbSet<Requisitos> Requisitos { get; set; }
        public virtual DbSet<SkillPessoa> SkillPessoa { get; set; }
        public virtual DbSet<Skills> Skills { get; set; }
        public virtual DbSet<TiposContatos> TiposContatos { get; set; }
        public virtual DbSet<TiposExperiencias> TiposExperiencias { get; set; }
        public virtual DbSet<TiposSkills> TiposSkills { get; set; }
        public virtual DbSet<TiposUsuarios> TiposUsuarios { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }
        public virtual DbSet<Vagas> Vagas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=brqsenai.database.windows.net;Initial Catalog=hrt_database;User ID=brqsenai;Password=@Senai132");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Candidaturas>(entity =>
            {
                entity.ToTable("candidaturas");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FkPessoa).HasColumnName("fkPessoa");

                entity.Property(e => e.FkVaga).HasColumnName("fkVaga");

                entity.HasOne(d => d.FkPessoaNavigation)
                    .WithMany(p => p.Candidaturas)
                    .HasForeignKey(d => d.FkPessoa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__candidatu__fkPes__7B5B524B");

                entity.HasOne(d => d.FkVagaNavigation)
                    .WithMany(p => p.Candidaturas)
                    .HasForeignKey(d => d.FkVaga)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__candidatu__fkVag__7A672E12");
            });

            modelBuilder.Entity<Contatos>(entity =>
            {
                entity.ToTable("contatos");

                entity.HasIndex(e => e.Contato)
                    .HasName("UQ__contatos__870056B9E1111306")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Contato)
                    .IsRequired()
                    .HasColumnName("contato")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FkPessoa).HasColumnName("fkPessoa");

                entity.Property(e => e.FkTipoContato).HasColumnName("fkTipoContato");

                entity.HasOne(d => d.FkPessoaNavigation)
                    .WithMany(p => p.Contatos)
                    .HasForeignKey(d => d.FkPessoa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__contatos__fkPess__6A30C649");

                entity.HasOne(d => d.FkTipoContatoNavigation)
                    .WithMany(p => p.Contatos)
                    .HasForeignKey(d => d.FkTipoContato)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__contatos__fkTipo__693CA210");
            });

            modelBuilder.Entity<Empresas>(entity =>
            {
                entity.ToTable("empresas");

                entity.HasIndex(e => e.Nome)
                    .HasName("UQ__empresas__6F71C0DCF06FE0A4")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Experiencias>(entity =>
            {
                entity.ToTable("experiencias");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descricao)
                    .HasColumnName("descricao")
                    .HasColumnType("text");

                entity.Property(e => e.DtFim)
                    .HasColumnName("dtFim")
                    .HasColumnType("date");

                entity.Property(e => e.DtInicio)
                    .HasColumnName("dtInicio")
                    .HasColumnType("date");

                entity.Property(e => e.FkPessoa).HasColumnName("fkPessoa");

                entity.Property(e => e.FkTipoExperiencia).HasColumnName("fkTipoExperiencia");

                entity.Property(e => e.Instituicao)
                    .HasColumnName("instituicao")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasColumnName("titulo")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.FkPessoaNavigation)
                    .WithMany(p => p.Experiencias)
                    .HasForeignKey(d => d.FkPessoa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__experienc__fkPes__5AEE82B9");

                entity.HasOne(d => d.FkTipoExperienciaNavigation)
                    .WithMany(p => p.Experiencias)
                    .HasForeignKey(d => d.FkTipoExperiencia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__experienc__fkTip__59FA5E80");
            });

            modelBuilder.Entity<Pessoas>(entity =>
            {
                entity.ToTable("pessoas");

                entity.HasIndex(e => e.Cpf)
                    .HasName("UQ__pessoas__D836E71FE662BE03")
                    .IsUnique();

                entity.HasIndex(e => e.Matricula)
                    .HasName("UQ__pessoas__30962D15B03C6377")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Bairro)
                    .HasColumnName("bairro")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Cep)
                    .HasColumnName("cep")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Cidade)
                    .HasColumnName("cidade")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Complemento)
                    .HasColumnName("complemento")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasColumnName("cpf")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .HasColumnName("estado")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Logradouro)
                    .HasColumnName("logradouro")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Matricula)
                    .IsRequired()
                    .HasColumnName("matricula")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroEndereco).HasColumnName("numeroEndereco");

                entity.Property(e => e.Pais)
                    .HasColumnName("pais")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Rg)
                    .IsRequired()
                    .HasColumnName("rg")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.StatusAlocacao).HasColumnName("statusAlocacao");
            });

            modelBuilder.Entity<Requisitos>(entity =>
            {
                entity.ToTable("requisitos");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Diferencial).HasColumnName("diferencial");

                entity.Property(e => e.FkSkill).HasColumnName("fkSkill");

                entity.Property(e => e.FkVaga).HasColumnName("fkVaga");

                entity.HasOne(d => d.FkSkillNavigation)
                    .WithMany(p => p.Requisitos)
                    .HasForeignKey(d => d.FkSkill)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__requisito__fkSki__76969D2E");

                entity.HasOne(d => d.FkVagaNavigation)
                    .WithMany(p => p.Requisitos)
                    .HasForeignKey(d => d.FkVaga)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__requisito__fkVag__778AC167");
            });

            modelBuilder.Entity<SkillPessoa>(entity =>
            {
                entity.ToTable("skillPessoa");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FkPessoa).HasColumnName("fkPessoa");

                entity.Property(e => e.FkSkill).HasColumnName("fkSkill");

                entity.HasOne(d => d.FkPessoaNavigation)
                    .WithMany(p => p.SkillPessoa)
                    .HasForeignKey(d => d.FkPessoa)
                    .HasConstraintName("FK__skillPess__fkPes__628FA481");

                entity.HasOne(d => d.FkSkillNavigation)
                    .WithMany(p => p.SkillPessoa)
                    .HasForeignKey(d => d.FkSkill)
                    .HasConstraintName("FK__skillPess__fkSki__619B8048");
            });

            modelBuilder.Entity<Skills>(entity =>
            {
                entity.ToTable("skills");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descricao)
                    .HasColumnName("descricao")
                    .HasColumnType("text");

                entity.Property(e => e.FkTipoSkill).HasColumnName("fkTipoSkill");

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasColumnName("titulo")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.FkTipoSkillNavigation)
                    .WithMany(p => p.Skills)
                    .HasForeignKey(d => d.FkTipoSkill)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__skills__fkTipoSk__7C4F7684");
            });

            modelBuilder.Entity<TiposContatos>(entity =>
            {
                entity.ToTable("tiposContatos");

                entity.HasIndex(e => e.Nome)
                    .HasName("UQ__tiposCon__6F71C0DC978AB59A")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TiposExperiencias>(entity =>
            {
                entity.ToTable("tiposExperiencias");

                entity.HasIndex(e => e.Nome)
                    .HasName("UQ__tiposExp__6F71C0DC04FE19B3")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TiposSkills>(entity =>
            {
                entity.ToTable("tiposSkills");

                entity.HasIndex(e => e.Nome)
                    .HasName("UQ__tiposSki__6F71C0DC91AE2EFF")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TiposUsuarios>(entity =>
            {
                entity.ToTable("tiposUsuarios");

                entity.HasIndex(e => e.Nome)
                    .HasName("UQ__tiposUsu__6F71C0DC14A1BEB7")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.ToTable("usuarios");

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__usuarios__AB6E6164A2DEDA6A")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FkPessoa).HasColumnName("fkPessoa");

                entity.Property(e => e.FkTipoUsuario).HasColumnName("fkTipoUsuario");

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasColumnName("senha")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.StatusAtivo)
                    .IsRequired()
                    .HasColumnName("statusAtivo")
                    .HasDefaultValueSql("((1))");

                entity.HasOne(d => d.FkPessoaNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.FkPessoa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__usuarios__fkPess__5441852A");

                entity.HasOne(d => d.FkTipoUsuarioNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.FkTipoUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__usuarios__fkTipo__534D60F1");
            });

            modelBuilder.Entity<Vagas>(entity =>
            {
                entity.ToTable("vagas");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CargaHoraria).HasColumnName("cargaHoraria");

                entity.Property(e => e.Descricao)
                    .HasColumnName("descricao")
                    .HasColumnType("text");

                entity.Property(e => e.DtPublicacao)
                    .HasColumnName("dtPublicacao")
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FkEmpresa).HasColumnName("fkEmpresa");

                entity.Property(e => e.FkPessoa).HasColumnName("fkPessoa");

                entity.Property(e => e.StatusSituacao)
                    .IsRequired()
                    .HasColumnName("statusSituacao")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasColumnName("titulo")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.FkEmpresaNavigation)
                    .WithMany(p => p.Vagas)
                    .HasForeignKey(d => d.FkEmpresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__vagas__fkEmpresa__71D1E811");

                entity.HasOne(d => d.FkPessoaNavigation)
                    .WithMany(p => p.Vagas)
                    .HasForeignKey(d => d.FkPessoa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__vagas__fkPessoa__72C60C4A");
            });
        }
    }
}
