namespace Unipam.TCC.DAL.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Situacao")]
    public partial class Situacao
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Situacao()
        {
            SituacaoProjetoes = new HashSet<SituacaoProjeto>();
        }

        [Key]
        public int IdSituacao { get; set; }

        [Required]
        [StringLength(200)]
        public string Descricao { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SituacaoProjeto> SituacaoProjetoes { get; set; }
    }
}
