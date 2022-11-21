using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend_ToyStore.Migrations
{
    public partial class Tablaajuste : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "RestriccionEdad",
                table: "juguetes",
                type: "int",
                maxLength: 3,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 3);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "RestriccionEdad",
                table: "juguetes",
                type: "int",
                maxLength: 3,
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 3,
                oldNullable: true);
        }
    }
}
