using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiCatalog.Migrations
{
    /// <inheritdoc />
    public partial class PopulaProdutos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("INSERT INTO Produtos (Nome, Descricao, Preco, ImagemUrl, Estoque, DataCadastro, CategoriaId)\r\n" +
                "VALUES('Coca-Cola Diet', 'Refrigerante de Cola 350 ml',5.45, 'cocacola.jpg',50,now(),1);");

            mb.Sql("INSERT INTO Produtos (Nome, Descricao, Preco, ImagemUrl, Estoque, DataCadastro, CategoriaId)\r\n" +
                "VALUES('Empada', 'Empada de frango',6.85, 'empada.jpg',50,now(),2);");

            mb.Sql("INSERT INTO Produtos (Nome, Descricao, Preco, ImagemUrl, Estoque, DataCadastro, CategoriaId)\r\n" +
            "VALUES('Pudim', 'Pudim de leite condensado 100g',5.45, 'Pudim.jpg',50,now(),3);");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("Delete from Produtos");
        }
    }
}
