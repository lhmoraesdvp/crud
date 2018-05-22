namespace Crud_LuisMoraes.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Uf")]
    public partial class Uf
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Uf()
        {
            Estabelecimentos = new HashSet<Estabelecimentos>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string estado { get; set; }

        [Required]
        [StringLength(2)]
        public string sigla { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Estabelecimentos> Estabelecimentos { get; set; }
    }
}
