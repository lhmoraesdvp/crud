namespace Crud_LuisMoraes.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Estabelecimentos
    {
        public int id { get; set; }

        [Required]
        [StringLength(18)]
        public string cnpj { get; set; }

        [Required]
        [StringLength(80)]
        public string razaoSocial { get; set; }

        [StringLength(80)]
        public string nomeFantasia { get; set; }

        public int categoriaId { get; set; }

        public bool? status { get; set; }

        [Column(TypeName = "date")]
        public DateTime? dataCadastro { get; set; }

        public int? ufId { get; set; }

        [StringLength(50)]
        public string cidade { get; set; }

        [StringLength(50)]
        public string bairro { get; set; }

        [StringLength(9)]
        public string cep { get; set; }

        [StringLength(50)]
        public string logradouro { get; set; }

        public int? numero { get; set; }
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Informe um email válido...")]
        [StringLength(80)]
        public string email { get; set; }

        [StringLength(13)]
        public string telefone { get; set; }

        public virtual Categorias Categorias { get; set; }

        public virtual Uf Uf { get; set; }
    }
}
