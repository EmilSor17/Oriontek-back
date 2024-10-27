﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oriontek.Infraestructure.Data;

#nullable disable

namespace Oriontek.Infraestructure.Migrations
{
    [DbContext(typeof(DatContext))]
    [Migration("20241027040509_DeletingCascade")]
    partial class DeletingCascade
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Oriontek.Core.Entities.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("House")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("IdPerson")
                        .HasColumnType("int");

                    b.Property<string>("Neighborhood")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("IdPerson")
                        .IsUnique();

                    b.ToTable("Direcciones", (string)null);
                });

            modelBuilder.Entity("Oriontek.Core.Entities.Identification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("IdPerson")
                        .HasColumnType("int");

                    b.Property<string>("IdentificationNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("IdentificationType")
                        .HasMaxLength(20)
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdPerson")
                        .IsUnique();

                    b.ToTable("Identificaciones", (string)null);
                });

            modelBuilder.Entity("Oriontek.Core.Entities.IdGeneral", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("IdPerson")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdPerson")
                        .IsUnique();

                    b.ToTable("IdGeneral", (string)null);
                });

            modelBuilder.Entity("Oriontek.Core.Entities.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("IdPerson")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Personas", (string)null);
                });

            modelBuilder.Entity("Oriontek.Core.Entities.Address", b =>
                {
                    b.HasOne("Oriontek.Core.Entities.Person", "Person")
                        .WithOne("Address")
                        .HasForeignKey("Oriontek.Core.Entities.Address", "IdPerson")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("Oriontek.Core.Entities.Identification", b =>
                {
                    b.HasOne("Oriontek.Core.Entities.Person", "Person")
                        .WithOne("Identification")
                        .HasForeignKey("Oriontek.Core.Entities.Identification", "IdPerson")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("Oriontek.Core.Entities.IdGeneral", b =>
                {
                    b.HasOne("Oriontek.Core.Entities.Person", "Person")
                        .WithOne("IdGeneral")
                        .HasForeignKey("Oriontek.Core.Entities.IdGeneral", "IdPerson")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("Oriontek.Core.Entities.Person", b =>
                {
                    b.Navigation("Address")
                        .IsRequired();

                    b.Navigation("IdGeneral")
                        .IsRequired();

                    b.Navigation("Identification")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
