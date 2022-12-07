using Microsoft.EntityFrameworkCore.Migrations;

namespace Mundo_de_Sombras.Migrations
{
    public partial class AddRecomendados : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Recomendados_de_la_semana",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Terror = table.Column<string>(nullable: true),
                    Sobrenatural = table.Column<string>(nullable: true),
                    Ficcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recomendados_de_la_semana", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Recomendados_de_la_semana");
        }
    }
}
