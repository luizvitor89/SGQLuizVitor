using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CIP.API.Migrations
{
    public partial class Update1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ocorrencia_Cronograma_CronogramaId",
                table: "Ocorrencia");

            migrationBuilder.DropIndex(
                name: "IX_Ocorrencia_CronogramaId",
                table: "Ocorrencia");

            migrationBuilder.DropColumn(
                name: "CronogramaId",
                table: "Ocorrencia");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CronogramaId",
                table: "Ocorrencia",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Ocorrencia_CronogramaId",
                table: "Ocorrencia",
                column: "CronogramaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ocorrencia_Cronograma_CronogramaId",
                table: "Ocorrencia",
                column: "CronogramaId",
                principalTable: "Cronograma",
                principalColumn: "CronogramaId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
