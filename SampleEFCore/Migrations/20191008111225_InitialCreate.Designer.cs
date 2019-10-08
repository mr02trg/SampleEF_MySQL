﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SampleEFCore;

namespace SampleEFCore.Migrations
{
    [DbContext(typeof(BaseContext))]
    [Migration("20191008111225_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("SampleEFCore.Model.MyValue", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("MyValues");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Name = "Value1"
                        },
                        new
                        {
                            Id = 2L,
                            Name = "Value2"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}