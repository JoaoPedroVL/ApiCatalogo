using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiCatalog.Migrations
{
    /// <inheritdoc />
    public partial class PopulaCategorias : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            // Insere os dados na tabela Categorias
            mb.Sql("INSERT INTO Categorias (Nome, ImagemURL) VALUES ('Bebidas', 'bebidas.jpg');");
            mb.Sql("INSERT INTO Categorias (Nome, ImagemURL) VALUES ('Lanches', 'lanches.jpg');");
            mb.Sql("INSERT INTO Categorias (Nome, ImagemURL) VALUES ('Sobremesas', 'sobremesas.jpg');");
            mb.Sql("INSERT INTO Categorias (Nome, ImagemURL) VALUES ('Doces', 'doces.jpg');");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            // Remove apenas os registros adicionados
            mb.Sql("DELETE FROM Categorias WHERE Nome IN ('Bebidas', 'Lanches', 'Sobremesas', 'Doces');");
        }
    }
}
