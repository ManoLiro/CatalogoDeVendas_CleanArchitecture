using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchMvc.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("INSERT INTO Products (Name, Description, Price, Stock, Image, CategoryId)" +
                "VALUES" +
                "('Caneta esferográfica', 'Caneta azul com tinta de secagem rápida', 2.50, 100, 'caneta.jpg', 1)," +
                "('Mochila escolar', 'Mochila resistente com vários compartimentos', 89.90, 30, 'mochila.jpg', 1)," +
                "('Régua 30cm', 'Régua de plástico transparente', 4.75, 80, 'regua.jpg', 1)," +
                "('Fone de ouvido Bluetooth', 'Fone sem fio com cancelamento de ruído', 129.90, 20, 'fone.jpg', 3)," +
                "('Mouse sem fio', 'Mouse óptico com conexão Bluetooth', 59.90, 40, 'mouse.jpg', 3)," +
                "('Teclado mecânico', 'Teclado gamer com iluminação RGB', 249.90, 15, 'teclado.jpg', 3)," +
                "('Bolsa transversal', 'Bolsa de couro sintético com alça ajustável', 119.90, 25, 'bolsa.jpg', 2)," +
                "('Óculos de sol', 'Óculos com proteção UV e lentes polarizadas', 79.90, 50, 'oculos.jpg', 2)," +
                "('Relógio digital', 'Relógio resistente à água com display LED', 149.90, 10, 'relogio.jpg', 2)");


        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("DELETE FROM Products");
        }
    }
}
