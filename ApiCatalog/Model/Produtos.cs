namespace ApiCatalog.Model
{
    public class Produtos
    {
        public int ProdutoId { get; set; }
        public string?  Nome { get; set; }
        public string? Descricao { get; set; }
        public decimal Preco { get; set; }
        public string? ImagemURL { get; set; }
        public float Estoque { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
