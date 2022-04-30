﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SistemaIndustrial.Repositories.Context;

#nullable disable

namespace SistemaIndustrial.Repositories.Migrations
{
    [DbContext(typeof(SisIndContext))]
    [Migration("20220425163907_inicial")]
    partial class inicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SistemaIndustrial.Domain.Entities.Animal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasColumnName("Id")
                        .HasColumnOrder(0);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Preco")
                        .HasPrecision(6, 2)
                        .HasColumnType("decimal(6,2)");

                    b.HasKey("Id");

                    b.ToTable("Animal", (string)null);
                });

            modelBuilder.Entity("SistemaIndustrial.Domain.Entities.CompraGado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasColumnName("Id")
                        .HasColumnOrder(0);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DataEntrega")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdPecuarista")
                        .HasColumnType("INT");

                    b.HasKey("Id");

                    b.HasIndex("IdPecuarista");

                    b.ToTable("CompraGado", (string)null);
                });

            modelBuilder.Entity("SistemaIndustrial.Domain.Entities.CompraGadoItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasColumnName("Id")
                        .HasColumnOrder(0);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("IdAnimal")
                        .HasColumnType("INT");

                    b.Property<int>("IdCompraGado")
                        .HasColumnType("INT");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.HasKey("Id", "IdAnimal", "IdCompraGado");

                    b.HasIndex("IdAnimal");

                    b.HasIndex("IdCompraGado");

                    b.ToTable("CompraGadoItem", (string)null);
                });

            modelBuilder.Entity("SistemaIndustrial.Domain.Entities.Pecuarista", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasColumnName("Id")
                        .HasColumnOrder(0);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Pecuarista", (string)null);
                });

            modelBuilder.Entity("SistemaIndustrial.Domain.Entities.CompraGado", b =>
                {
                    b.HasOne("SistemaIndustrial.Domain.Entities.Pecuarista", "Pecuarista")
                        .WithMany()
                        .HasForeignKey("IdPecuarista")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pecuarista");
                });

            modelBuilder.Entity("SistemaIndustrial.Domain.Entities.CompraGadoItem", b =>
                {
                    b.HasOne("SistemaIndustrial.Domain.Entities.Animal", "Animal")
                        .WithMany()
                        .HasForeignKey("IdAnimal")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SistemaIndustrial.Domain.Entities.CompraGado", "CompraGado")
                        .WithMany()
                        .HasForeignKey("IdCompraGado")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Animal");

                    b.Navigation("CompraGado");
                });
#pragma warning restore 612, 618
        }
    }
}
