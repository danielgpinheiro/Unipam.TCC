namespace Unipam.TCC.DAL.Entity
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class TCCModel : DbContext
    {
        public TCCModel()
            : base("name=TCC_Context")
        {
        }

        public virtual DbSet<Aluno> Alunoes { get; set; }
        public virtual DbSet<Curso> Cursoes { get; set; }
        public virtual DbSet<Entrega> Entregas { get; set; }
        public virtual DbSet<Etapa> Etapas { get; set; }
        public virtual DbSet<Nota> Notas { get; set; }
        public virtual DbSet<Orientacao> Orientacaos { get; set; }
        public virtual DbSet<Papel> Papels { get; set; }
        public virtual DbSet<Pessoa> Pessoas { get; set; }
        public virtual DbSet<Professor> Professors { get; set; }
        public virtual DbSet<Projeto> Projetoes { get; set; }
        public virtual DbSet<Situacao> Situacaos { get; set; }
        public virtual DbSet<SituacaoProjeto> SituacaoProjetoes { get; set; }
        public virtual DbSet<TipoEntrega> TipoEntregas { get; set; }
        public virtual DbSet<TipoOrientacao> TipoOrientacaos { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aluno>()
                .HasMany(e => e.Projetoes)
                .WithRequired(e => e.Aluno)
                .HasForeignKey(e => e.IdPessoaAluno)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Curso>()
                .Property(e => e.NomeCurso)
                .IsUnicode(false);

            modelBuilder.Entity<Curso>()
                .HasMany(e => e.Alunoes)
                .WithRequired(e => e.Curso)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Entrega>()
                .HasMany(e => e.Notas)
                .WithRequired(e => e.Entrega)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Etapa>()
                .Property(e => e.NotaMinima)
                .HasPrecision(6, 2);

            modelBuilder.Entity<Etapa>()
                .HasMany(e => e.Entregas)
                .WithRequired(e => e.Etapa)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Nota>()
                .Property(e => e.Valor)
                .HasPrecision(6, 2);

            modelBuilder.Entity<Papel>()
                .Property(e => e.Descricao)
                .IsUnicode(false);

            modelBuilder.Entity<Papel>()
                .HasMany(e => e.Usuarios)
                .WithMany(e => e.Papels)
                .Map(m => m.ToTable("UsuarioPapel").MapLeftKey("IdPapel").MapRightKey("IdUsuario"));

            modelBuilder.Entity<Pessoa>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<Pessoa>()
                .HasOptional(e => e.Aluno)
                .WithRequired(e => e.Pessoa);

            modelBuilder.Entity<Pessoa>()
                .HasOptional(e => e.Professor)
                .WithRequired(e => e.Pessoa);

            modelBuilder.Entity<Professor>()
                .HasMany(e => e.Orientacaos)
                .WithRequired(e => e.Professor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Projeto>()
                .Property(e => e.NomeProjeto)
                .IsUnicode(false);

            modelBuilder.Entity<Projeto>()
                .Property(e => e.NotaProjeto)
                .HasPrecision(6, 2);

            modelBuilder.Entity<Projeto>()
                .HasMany(e => e.Entregas)
                .WithRequired(e => e.Projeto)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Projeto>()
                .HasMany(e => e.Orientacaos)
                .WithRequired(e => e.Projeto)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Projeto>()
                .HasMany(e => e.SituacaoProjetoes)
                .WithRequired(e => e.Projeto)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Situacao>()
                .Property(e => e.Descricao)
                .IsUnicode(false);

            modelBuilder.Entity<Situacao>()
                .HasMany(e => e.SituacaoProjetoes)
                .WithRequired(e => e.Situacao)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TipoEntrega>()
                .Property(e => e.Descricao)
                .IsUnicode(false);

            modelBuilder.Entity<TipoEntrega>()
                .HasMany(e => e.Etapas)
                .WithRequired(e => e.TipoEntrega)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TipoOrientacao>()
                .Property(e => e.Descricao)
                .IsUnicode(false);

            modelBuilder.Entity<TipoOrientacao>()
                .HasMany(e => e.Orientacaos)
                .WithRequired(e => e.TipoOrientacao)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.NomeUsuario)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Senha)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Pessoas)
                .WithRequired(e => e.Usuario)
                .WillCascadeOnDelete(false);
        }
    }
}
