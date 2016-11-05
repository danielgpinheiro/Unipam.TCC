namespace Unipam.TCC.DAL.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Pessoa")]
    public partial class Pessoa
    {
        [Key]
        public int IdPessoa { get; set; }

        public int IdUsuario { get; set; }

        [Required]
        [StringLength(200)]
        public string Nome { get; set; }

        public virtual Aluno Aluno { get; set; }

        public virtual Usuario Usuario { get; set; }

        public virtual Professor Professor { get; set; }
    }
}
