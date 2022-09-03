﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using proyectoef;

#nullable disable

namespace proyectoef.Migrations
{
    [DbContext(typeof(TareasContext))]
    partial class TareasContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("proyectoef.Models.Categoria", b =>
                {
                    b.Property<Guid>("CategoriaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("Peso")
                        .HasColumnType("int");

                    b.HasKey("CategoriaId");

                    b.ToTable("Categoria", (string)null);

                    b.HasData(
                        new
                        {
                            CategoriaId = new Guid("4e26179c-6a70-41bc-8e78-69c6b77cb98a"),
                            Nombre = "Actividades pendientes",
                            Peso = 20
                        },
                        new
                        {
                            CategoriaId = new Guid("4e26179c-6a70-41bc-8e78-69c6b77cb902"),
                            Nombre = "Actividades personales",
                            Peso = 50
                        },
                        new
                        {
                            CategoriaId = new Guid("4e26179c-6a70-41bc-8e78-69c6b77cb903"),
                            Nombre = "Actividades laborales",
                            Peso = 70
                        });
                });

            modelBuilder.Entity("proyectoef.Models.Tarea", b =>
                {
                    b.Property<Guid>("TareaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoriaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<int>("PrioridadTarea")
                        .HasColumnType("int");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("TareaId");

                    b.HasIndex("CategoriaId");

                    b.ToTable("Tarea", (string)null);

                    b.HasData(
                        new
                        {
                            TareaId = new Guid("4e26179c-6a70-41bc-8e78-69c6b77cb910"),
                            CategoriaId = new Guid("4e26179c-6a70-41bc-8e78-69c6b77cb98a"),
                            FechaCreacion = new DateTime(2022, 9, 2, 17, 55, 14, 404, DateTimeKind.Local).AddTicks(2638),
                            PrioridadTarea = 1,
                            Titulo = "Pago de servicios públicos"
                        },
                        new
                        {
                            TareaId = new Guid("4e26179c-6a70-41bc-8e78-69c6b77cb911"),
                            CategoriaId = new Guid("4e26179c-6a70-41bc-8e78-69c6b77cb902"),
                            FechaCreacion = new DateTime(2022, 9, 2, 17, 55, 14, 404, DateTimeKind.Local).AddTicks(2659),
                            PrioridadTarea = 0,
                            Titulo = "Terminar de ver pelicula en Netflix"
                        },
                        new
                        {
                            TareaId = new Guid("4e26179c-6a70-41bc-8e78-69c6b77cb912"),
                            CategoriaId = new Guid("4e26179c-6a70-41bc-8e78-69c6b77cb903"),
                            FechaCreacion = new DateTime(2022, 9, 2, 17, 55, 14, 404, DateTimeKind.Local).AddTicks(2664),
                            PrioridadTarea = 2,
                            Titulo = "Terminar Reporte"
                        });
                });

            modelBuilder.Entity("proyectoef.Models.Tarea", b =>
                {
                    b.HasOne("proyectoef.Models.Categoria", "Categoria")
                        .WithMany("Tareas")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("proyectoef.Models.Categoria", b =>
                {
                    b.Navigation("Tareas");
                });
#pragma warning restore 612, 618
        }
    }
}
