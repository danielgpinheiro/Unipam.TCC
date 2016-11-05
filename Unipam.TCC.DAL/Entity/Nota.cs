namespace Unipam.TCC.DAL.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Nota")]
    public partial class Nota
    {
        [Key]
        public int IdNota { get; set; }

        public int IdEntrega { get; set; }

        public DateTime DataAlteracao { get; set; }

        public decimal Valor { get; set; }

        public int IdUsuario { get; set; }

        public virtual Entrega Entrega { get; set; }
    }
}
