namespace Unipam.TCC.DAL.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Orientacao")]
    public partial class Orientacao
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdPessoa { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short IdTipoOrientacao { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdProjeto { get; set; }

        public DateTime Data { get; set; }

        public virtual Professor Professor { get; set; }

        public virtual Projeto Projeto { get; set; }

        public virtual TipoOrientacao TipoOrientacao { get; set; }
    }
}
