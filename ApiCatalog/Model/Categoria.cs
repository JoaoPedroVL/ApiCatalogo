using System.Collections.ObjectModel;

namespace ApiCatalog.Model
{
    public class Categoria
    {
        public Categoria()
        {
            Produtos = new Collection<Produtos>();
        }

        public int CategoriaId { get; set; }
        public string? Nome { get; set; }
        public string? ImagemURL { get; set; }

        public ICollection<Produtos>? Produtos { get; set; }

    }
}
