using Magazin_odejdi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.ComponentModel.DataAnnotations;
using System.Drawing;

#nullable disable

namespace EventManager.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Clothes_Store.Model.Clothes", b =>
            {
                b.Property<string>("Naimenovanie")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("string");
                
                SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<string>("Naimenovanie"));

                b.Property<string>("Category")
                    .HasColumnType("string");

                b.Property<string>("Size")
                    .HasColumnType("string");

                b.Property<string>("Color")
                    .HasColumnType("string");

                b.Property<string>("Material")
                    .HasColumnType("string");

                b.Property<double>("Price")
                    .HasColumnType("double");

                b.HasKey("Naimenovanie");

                b.ToTable("Clothes");
            });

            modelBuilder.Entity("Clothes_Store.Model.Buyer", b =>
            {
                b.Property<string>("FIO")
                    .HasColumnType("string");

                SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<string>("FIO"));

                b.Property<string>("Telefon")
                    .HasColumnType("string");

                b.Property<string>("Email")
                    .HasColumnType("string");

                b.Property<DataType>("Data_BirthDay")
                    .HasColumnType("DataType");

                b.HasKey("FIO");

                b.ToTable("Buyer");
            });
#pragma warning restore 612, 618
        }
    }
}
