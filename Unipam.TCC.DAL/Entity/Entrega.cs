namespace Unipam.TCC.DAL.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Entrega")]
    public partial class Entrega
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Entrega()
        {
            Notas = new HashSet<Nota>();
        }

        [Key]
        public int IdEntrega { get; set; }

        public int IdProjeto { get; set; }

        public int IdEtapa { get; set; }

        public DateTime Data { get; set; }

        public virtual Etapa Etapa { get; set; }

        public virtual Projeto Projeto { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Nota> Notas { get; set; }
    }
}
