using Microsoft.EntityFrameworkCore.Migrations;

namespace LanchesMac.Migrations
{
    public partial class popularBanco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Categorias(Nome,Descricao) VALUES('Lanche Normal','Lanche feito com ingredientes normais')");
            migrationBuilder.Sql("INSERT INTO Categorias(Nome,Descricao) VALUES('Lanche Natural','Lanche feito com ingredientes integrais e naturais')");

          
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Categorias");
            migrationBuilder.Sql("DELETE FROM Lanches");
        }
    }
}
