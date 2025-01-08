using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiCatalog.Model
{
    [Table("Produtos")]
    public class Produtos
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(80)]
        public string?  Nome { get; set; }

        [Required]
        [StringLength(300)]
        public string? Descricao { get; set; }

        [Required]
        [Column(TypeName ="decimal(10,2)")]
        public decimal Preco { get; set; }

        [Required]
        [StringLength(300)]
        public string? ImagemURL { get; set; }
        public float Estoque { get; set; }
        public DateTime DataCadastro { get; set; }

        public int CategoriaId { get; set; }
        public Categoria? Categoria { get; set; }
    }
}
