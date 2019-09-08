using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CIP.API.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cronograma",
                columns: table => new
                {
                    CronogramaId = table.Column<Guid>(nullable: false),
                    OcorrenciaId = table.Column<Guid>(nullable: false),
                    DataHoraAcao = table.Column<DateTime>(nullable: false),
                    Etapa = table.Column<int>(nullable: false),
                    PlanoDeAcao = table.Column<string>(nullable: true),
                    Norma = table.Column<string>(nullable: true),
                    Executado = table.Column<bool>(nullable: false),
                    Resultado = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cronograma", x => x.CronogramaId);
                });

            migrationBuilder.CreateTable(
                name: "Emissor",
                columns: table => new
                {
                    EmissorId = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Senha = table.Column<string>(nullable: true),
                    PermissaoVisualizacao = table.Column<bool>(nullable: false),
                    PermissaoCadastro = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emissor", x => x.EmissorId);
                });

            migrationBuilder.CreateTable(
                name: "Insumo",
                columns: table => new
                {
                    InsumoId = table.Column<Guid>(nullable: false),
                    Tipo = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Insumo", x => x.InsumoId);
                });

            migrationBuilder.CreateTable(
                name: "Setor",
                columns: table => new
                {
                    SetorId = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Setor", x => x.SetorId);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    StatusId = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.StatusId);
                });

            migrationBuilder.CreateTable(
                name: "TipoOcorrencia",
                columns: table => new
                {
                    TipoOcorrenciaId = table.Column<Guid>(nullable: false),
                    Tipo = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoOcorrencia", x => x.TipoOcorrenciaId);
                });

            migrationBuilder.CreateTable(
                name: "Ocorrencia",
                columns: table => new
                {
                    OcorrenciaId = table.Column<Guid>(nullable: false),
                    TipoOcorrenciaId = table.Column<Guid>(nullable: false),
                    InsumoId = table.Column<Guid>(nullable: false),
                    EmissorId = table.Column<Guid>(nullable: false),
                    SetorId = table.Column<Guid>(nullable: false),
                    CronogramaId = table.Column<Guid>(nullable: false),
                    StatusId = table.Column<Guid>(nullable: false),
                    Titulo = table.Column<string>(nullable: true),
                    DataHora = table.Column<DateTime>(nullable: false),
                    Descricao = table.Column<string>(nullable: true),
                    Consequencias = table.Column<string>(nullable: true),
                    Prioridade = table.Column<int>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    DivulgadoInternamente = table.Column<bool>(nullable: false),
                    DivulgadoExternamente = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ocorrencia", x => x.OcorrenciaId);
                    table.ForeignKey(
                        name: "FK_Ocorrencia_Cronograma_CronogramaId",
                        column: x => x.CronogramaId,
                        principalTable: "Cronograma",
                        principalColumn: "CronogramaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ocorrencia_Emissor_EmissorId",
                        column: x => x.EmissorId,
                        principalTable: "Emissor",
                        principalColumn: "EmissorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ocorrencia_Insumo_InsumoId",
                        column: x => x.InsumoId,
                        principalTable: "Insumo",
                        principalColumn: "InsumoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ocorrencia_Setor_SetorId",
                        column: x => x.SetorId,
                        principalTable: "Setor",
                        principalColumn: "SetorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ocorrencia_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "StatusId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ocorrencia_TipoOcorrencia_TipoOcorrenciaId",
                        column: x => x.TipoOcorrenciaId,
                        principalTable: "TipoOcorrencia",
                        principalColumn: "TipoOcorrenciaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ocorrencia_CronogramaId",
                table: "Ocorrencia",
                column: "CronogramaId");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ocorrencia");

            migrationBuilder.DropTable(
                name: "Cronograma");

            migrationBuilder.DropTable(
                name: "Emissor");

            migrationBuilder.DropTable(
                name: "Insumo");

            migrationBuilder.DropTable(
                name: "Setor");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "TipoOcorrencia");
        }
    }
}
