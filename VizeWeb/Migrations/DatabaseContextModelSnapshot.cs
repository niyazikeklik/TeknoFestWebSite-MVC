﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VizeWeb.DatabaseContext2;

namespace VizeWeb.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("VizeWeb.Models.Takim", b =>
                {
                    b.Property<int>("TakimdId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TakimUyeSayisi")
                        .HasColumnType("int");

                    b.HasKey("TakimdId");

                    b.ToTable("Takimlar");
                });

            modelBuilder.Entity("VizeWeb.Models.Uye", b =>
                {
                    b.Property<int>("UyeOkulNo")
                        .HasColumnType("int");

                    b.Property<int?>("TakimID")
                        .HasColumnType("int");

                    b.Property<string>("UyeAdi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UyeAlan")
                        .HasColumnType("int");

                    b.Property<DateTime>("UyeDogumTarihi")
                        .HasColumnType("datetime2");

                    b.Property<string>("UyeMail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UyeTelNo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UyeOkulNo");

                    b.HasIndex("TakimID");

                    b.ToTable("Uyeler");
                });

            modelBuilder.Entity("VizeWeb.Models.Uye", b =>
                {
                    b.HasOne("VizeWeb.Models.Takim", "UyeTakim")
                        .WithMany("TakimUyeleri")
                        .HasForeignKey("TakimID");

                    b.Navigation("UyeTakim");
                });

            modelBuilder.Entity("VizeWeb.Models.Takim", b =>
                {
                    b.Navigation("TakimUyeleri");
                });
#pragma warning restore 612, 618
        }
    }
}
