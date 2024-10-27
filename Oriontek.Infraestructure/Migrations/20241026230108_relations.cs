using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Oriontek.Infraestructure.Migrations
{
    public partial class relations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Direcciones_IdGeneral_IdPerson",
                table: "Direcciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Identificaciones_IdGeneral_IdPerson",
                table: "Identificaciones");

            migrationBuilder.DropIndex(
                name: "IX_Identificaciones_IdPerson",
                table: "Identificaciones");

            migrationBuilder.DropIndex(
                name: "IX_Direcciones_IdPerson",
                table: "Direcciones");

            migrationBuilder.CreateIndex(
                name: "IX_IdGeneral_IdPerson",
                table: "IdGeneral",
                column: "IdPerson",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Identificaciones_IdPerson",
                table: "Identificaciones",
                column: "IdPerson",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Direcciones_IdPerson",
                table: "Direcciones",
                column: "IdPerson",
                unique: true);

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

            migrationBuilder.DropIndex(
                name: "IX_IdGeneral_IdPerson",
                table: "IdGeneral");

            migrationBuilder.DropIndex(
                name: "IX_Identificaciones_IdPerson",
                table: "Identificaciones");

            migrationBuilder.DropIndex(
                name: "IX_Direcciones_IdPerson",
                table: "Direcciones");

            migrationBuilder.CreateIndex(
                name: "IX_Identificaciones_IdPerson",
                table: "Identificaciones",
                column: "IdPerson");

            migrationBuilder.CreateIndex(
                name: "IX_Direcciones_IdPerson",
                table: "Direcciones",
                column: "IdPerson");

            migrationBuilder.AddForeignKey(
                name: "FK_Direcciones_IdGeneral_IdPerson",
                table: "Direcciones",
                column: "IdPerson",
                principalTable: "IdGeneral",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Identificaciones_IdGeneral_IdPerson",
                table: "Identificaciones",
                column: "IdPerson",
                principalTable: "IdGeneral",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
