﻿// <auto-generated />
using System;
using CIP.API.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CIP.API.Migrations
{
    [DbContext(typeof(CIPContext))]
    [Migration("20190905190950_Update2")]
    partial class Update2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CIP.API.Entities.Cronograma", b =>
                {
                    b.Property<Guid>("CronogramaId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DataHoraAcao");

                    b.Property<int>("Etapa");

                    b.Property<bool>("Executado");

                    b.Property<string>("Norma");

                    b.Property<Guid>("OcorrenciaId");

                    b.Property<string>("PlanoDeAcao");

                    b.Property<string>("Resultado");

                    b.HasKey("CronogramaId");

                    b.ToTable("Cronograma");
                });

            modelBuilder.Entity("CIP.API.Entities.Emissor", b =>
                {
                    b.Property<Guid>("EmissorId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("Nome");

                    b.Property<bool>("PermissaoCadastro");

                    b.Property<bool>("PermissaoVisualizacao");

                    b.Property<string>("Senha");

                    b.HasKey("EmissorId");

                    b.ToTable("Emissor");
                });

            modelBuilder.Entity("CIP.API.Entities.Insumo", b =>
                {
                    b.Property<Guid>("InsumoId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descricao");

                    b.Property<string>("Tipo");

                    b.HasKey("InsumoId");

                    b.ToTable("Insumo");
                });

            modelBuilder.Entity("CIP.API.Entities.Ocorrencia", b =>
                {
                    b.Property<Guid>("OcorrenciaId")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Ativo");

                    b.Property<string>("Consequencias");

                    b.Property<DateTime>("DataHora");

                    b.Property<string>("Descricao");

                    b.Property<bool>("DivulgadoExternamente");

                    b.Property<bool>("DivulgadoInternamente");

                    b.Property<Guid>("EmissorId");

                    b.Property<Guid>("InsumoId");

                    b.Property<int>("Prioridade");

                    b.Property<Guid>("SetorId");

                    b.Property<Guid>("StatusId");

                    b.Property<Guid>("TipoOcorrenciaId");

                    b.Property<string>("Titulo");

                    b.HasKey("OcorrenciaId");

                    b.ToTable("Ocorrencia");
                });

            modelBuilder.Entity("CIP.API.Entities.Setor", b =>
                {
                    b.Property<Guid>("SetorId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descricao");

                    b.Property<string>("Nome");

                    b.HasKey("SetorId");

                    b.ToTable("Setor");
                });

            modelBuilder.Entity("CIP.API.Entities.Status", b =>
                {
                    b.Property<Guid>("StatusId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descricao");

                    b.Property<string>("Nome");

                    b.HasKey("StatusId");

                    b.ToTable("Status");
                });

            modelBuilder.Entity("CIP.API.Entities.TipoOcorrencia", b =>
                {
                    b.Property<Guid>("TipoOcorrenciaId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descricao");

                    b.Property<string>("Tipo");

                    b.HasKey("TipoOcorrenciaId");

                    b.ToTable("TipoOcorrencia");
                });
#pragma warning restore 612, 618
        }
    }
}