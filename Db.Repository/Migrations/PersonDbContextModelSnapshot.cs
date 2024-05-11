﻿// <auto-generated />
using System;
using Db.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Db.Repository.Migrations
{
    [DbContext(typeof(PersonDbContext))]
    partial class PersonDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DTOs.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("date");

                    b.Property<int>("IsDelete")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("DTOs.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(75)");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("Date");

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("Date");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<byte>("Gender")
                        .HasColumnType("tinyint");

                    b.Property<string>("HomeNumber")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("IsDelete")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("OfficeNumber")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PIN")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("PersonalNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(18)");

                    b.Property<string>("Picture")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("People");
                });

            modelBuilder.Entity("DTOs.PersonRelations", b =>
                {
                    b.Property<int>("FromId")
                        .HasColumnType("int");

                    b.Property<int>("ToId")
                        .HasColumnType("int");

                    b.Property<byte>("RelationType")
                        .HasColumnType("tinyint");

                    b.HasKey("FromId", "ToId");

                    b.HasIndex("ToId");

                    b.ToTable("PersonRelations");
                });

            modelBuilder.Entity("DTOs.Person", b =>
                {
                    b.HasOne("DTOs.City", "City")
                        .WithMany("People")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("DTOs.PersonRelations", b =>
                {
                    b.HasOne("DTOs.Person", "FromPerson")
                        .WithMany("FromRelationships")
                        .HasForeignKey("FromId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DTOs.Person", "ToPerson")
                        .WithMany("ToRelationships")
                        .HasForeignKey("ToId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("FromPerson");

                    b.Navigation("ToPerson");
                });

            modelBuilder.Entity("DTOs.City", b =>
                {
                    b.Navigation("People");
                });

            modelBuilder.Entity("DTOs.Person", b =>
                {
                    b.Navigation("FromRelationships");

                    b.Navigation("ToRelationships");
                });
#pragma warning restore 612, 618
        }
    }
}
