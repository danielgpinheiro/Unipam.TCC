namespace Unipam.TCC.DAL.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SituacaoProjeto")]
    public partial class SituacaoProjeto
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdProjeto { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdSituacao { get; set; }

        public DateTime DataAlteracao { get; set; }

        public virtual Projeto Projeto { get; set; }

        public virtual Situacao Situacao { get; set; }
    }
}
