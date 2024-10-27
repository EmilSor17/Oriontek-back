using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Oriontek.Infraestructure.Migrations
{
    public partial class DeletingCascade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Direcciones_Personas_IdPerson",
                table: "Direcciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Identificaciones_Personas_IdPerson",
                table: "Identificaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_IdGeneral_Personas_IdPerson",
                table: "IdGeneral");

            migrationBuilder.AddForeignKey(
                name: "FK_Direcciones_Personas_IdPerson",
                table: "Direcciones",
                column: "IdPerson",
                principalTable: "Personas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Identificaciones_Personas_IdPerson",
                table: "Identificaciones",
                column: "IdPerson",
                principalTable: "Personas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IdGeneral_Personas_IdPerson",
                table: "IdGeneral",
                column: "IdPerson",
                principalTable: "Personas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Direcciones_Personas_IdPerson",
                table: "Direcciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Identificaciones_Personas_IdPerson",
                table: "Identificaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_IdGeneral_Personas_IdPerson",
                table: "IdGeneral");

            migrationBuilder.AddForeignKey(
                name: "FK_Direcciones_Personas_IdPerson",
                table: "Direcciones",
                column: "IdPerson",
                principalTable: "Personas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Identificaciones_Personas_IdPerson",
                table: "Identificaciones",
                column: "IdPerson",
                principalTable: "Personas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_IdGeneral_Personas_IdPerson",
                table: "IdGeneral",
                column: "IdPerson",
                principalTable: "Personas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
