using Microsoft.EntityFrameworkCore.Migrations;

namespace CIP.API.Migrations
{
    public partial class Update2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ocorrencia_Emissor_EmissorId",
                table: "Ocorrencia");

            migrationBuilder.DropForeignKey(
                name: "FK_Ocorrencia_Insumo_InsumoId",
                table: "Ocorrencia");

            migrationBuilder.DropForeignKey(
                name: "FK_Ocorrencia_Setor_SetorId",
                table: "Ocorrencia");

            migrationBuilder.DropForeignKey(
                name: "FK_Ocorrencia_Status_StatusId",
                table: "Ocorrencia");

            migrationBuilder.DropForeignKey(
                name: "FK_Ocorrencia_TipoOcorrencia_TipoOcorrenciaId",
                table: "Ocorrencia");

            migrationBuilder.DropIndex(
                name: "IX_Ocorrencia_EmissorId",
                table: "Ocorrencia");

            migrationBuilder.DropIndex(
                name: "IX_Ocorrencia_InsumoId",
                table: "Ocorrencia");

            migrationBuilder.DropIndex(
                name: "IX_Ocorrencia_SetorId",
                table: "Ocorrencia");

            migrationBuilder.DropIndex(
                name: "IX_Ocorrencia_StatusId",
                table: "Ocorrencia");

            migrationBuilder.DropIndex(
                name: "IX_Ocorrencia_TipoOcorrenciaId",
                table: "Ocorrencia");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Ocorrencia_EmissorId",
                table: "Ocorrencia",
                column: "EmissorId");

            migrationBuilder.CreateIndex(
                name: "IX_Ocorrencia_InsumoId",
                table: "Ocorrencia",
                column: "InsumoId");

            migrationBuilder.CreateIndex(
                name: "IX_Ocorrencia_SetorId",
                table: "Ocorrencia",
                column: "SetorId");

            migrationBuilder.CreateIndex(
                name: "IX_Ocorrencia_StatusId",
                table: "Ocorrencia",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Ocorrencia_TipoOcorrenciaId",
                table: "Ocorrencia",
                column: "TipoOcorrenciaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ocorrencia_Emissor_EmissorId",
                table: "Ocorrencia",
                column: "EmissorId",
                principalTable: "Emissor",
                principalColumn: "EmissorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ocorrencia_Insumo_InsumoId",
                table: "Ocorrencia",
                column: "InsumoId",
                principalTable: "Insumo",
                principalColumn: "InsumoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ocorrencia_Setor_SetorId",
                table: "Ocorrencia",
                column: "SetorId",
                principalTable: "Setor",
                principalColumn: "SetorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ocorrencia_Status_StatusId",
                table: "Ocorrencia",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "StatusId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ocorrencia_TipoOcorrencia_TipoOcorrenciaId",
                table: "Ocorrencia",
                column: "TipoOcorrenciaId",
                principalTable: "TipoOcorrencia",
                principalColumn: "TipoOcorrenciaId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
