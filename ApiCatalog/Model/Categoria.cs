using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiCatalog.Model
{
    [Table("Categorias")] //Data anotaison
    public class Categoria
    {
        public Categoria()
        {
            Produtos = new Collection<Produtos>();
        }
        [Key]
        public int CategoriaId { get; set; }

        [Required] //Data anotaison
        [StringLength(80)] //Data anotaison
        public string? Nome { get; set; }

        [Required] //Data anotaison
        [StringLength(300)] //Data anotaison
        public string? ImagemURL { get; set; }

        public ICollection<Produtos>? Produtos { get; set; }

    }
}
