namespace Unipam.TCC.DAL.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Projeto")]
    public partial class Projeto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Projeto()
        {
            Entregas = new HashSet<Entrega>();
            Orientacaos = new HashSet<Orientacao>();
            SituacaoProjetoes = new HashSet<SituacaoProjeto>();
        }

        [Key]
        public int IdProjeto { get; set; }

        [Required]
        [StringLength(200)]
        public string NomeProjeto { get; set; }

        public decimal? NotaProjeto { get; set; }

        public int IdPessoaAluno { get; set; }

        public virtual Aluno Aluno { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Entrega> Entregas { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Orientacao> Orientacaos { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SituacaoProjeto> SituacaoProjetoes { get; set; }
    }
}
