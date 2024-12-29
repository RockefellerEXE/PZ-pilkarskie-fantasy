﻿// <auto-generated />
using FantasyApp.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FantasyApp.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241229112258_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.27")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("FantasyApp.Models.Druzyna", b =>
                {
                    b.Property<int>("DruzynaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DruzynaId"), 1L, 1);

                    b.Property<int>("Budzet")
                        .HasColumnType("int");

                    b.Property<int>("UzytkownikId")
                        .HasColumnType("int");

                    b.HasKey("DruzynaId");

                    b.HasIndex("UzytkownikId");

                    b.ToTable("Druzyny");
                });

            modelBuilder.Entity("FantasyApp.Models.Klub", b =>
                {
                    b.Property<int>("KlubId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("KlubId"), 1L, 1);

                    b.Property<string>("Nazwa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("KlubId");

                    b.ToTable("Kluby");
                });

            modelBuilder.Entity("FantasyApp.Models.SkladDruzyny", b =>
                {
                    b.Property<int>("DruzynaId")
                        .HasColumnType("int");

                    b.Property<int>("ZawodnikId")
                        .HasColumnType("int");

                    b.HasKey("DruzynaId", "ZawodnikId");

                    b.HasIndex("ZawodnikId");

                    b.ToTable("SkladDruzyny");
                });

            modelBuilder.Entity("FantasyApp.Models.StatystykiZawodnikow", b =>
                {
                    b.Property<int>("StatystykiZawodnikowId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StatystykiZawodnikowId"), 1L, 1);

                    b.Property<int>("Asysty")
                        .HasColumnType("int");

                    b.Property<int>("Bramki")
                        .HasColumnType("int");

                    b.Property<int>("CzerwoneKartki")
                        .HasColumnType("int");

                    b.Property<int>("DruzynaId")
                        .HasColumnType("int");

                    b.Property<int>("KarneSprowadzone")
                        .HasColumnType("int");

                    b.Property<int>("KarneWywalczone")
                        .HasColumnType("int");

                    b.Property<int>("KarneZmarnowane")
                        .HasColumnType("int");

                    b.Property<int>("Punkty")
                        .HasColumnType("int");

                    b.Property<int>("StrzalyObronione")
                        .HasColumnType("int");

                    b.Property<int>("ZawodnikId")
                        .HasColumnType("int");

                    b.Property<int>("ZolteKartki")
                        .HasColumnType("int");

                    b.HasKey("StatystykiZawodnikowId");

                    b.HasIndex("DruzynaId");

                    b.HasIndex("ZawodnikId");

                    b.ToTable("StatystykiZawodnikow");
                });

            modelBuilder.Entity("FantasyApp.Models.Transfer", b =>
                {
                    b.Property<int>("TransferId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TransferId"), 1L, 1);

                    b.Property<int>("DruzynaId")
                        .HasColumnType("int");

                    b.Property<string>("TypTransferu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ZawodnikId")
                        .HasColumnType("int");

                    b.HasKey("TransferId");

                    b.HasIndex("DruzynaId");

                    b.HasIndex("ZawodnikId");

                    b.ToTable("Transfery");
                });

            modelBuilder.Entity("FantasyApp.Models.Uzytkownik", b =>
                {
                    b.Property<int>("UzytkownikId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UzytkownikId"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Haslo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Punkty")
                        .HasColumnType("int");

                    b.HasKey("UzytkownikId");

                    b.ToTable("Uzytkownicy");
                });

            modelBuilder.Entity("FantasyApp.Models.Zawodnik", b =>
                {
                    b.Property<int>("ZawodnikId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ZawodnikId"), 1L, 1);

                    b.Property<decimal>("Cena")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Imie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("KlubId")
                        .HasColumnType("int");

                    b.Property<string>("Nazwisko")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pozycja")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Punkty")
                        .HasColumnType("int");

                    b.HasKey("ZawodnikId");

                    b.HasIndex("KlubId");

                    b.ToTable("Zawodnicy");
                });

            modelBuilder.Entity("FantasyApp.Models.Druzyna", b =>
                {
                    b.HasOne("FantasyApp.Models.Uzytkownik", "Uzytkownik")
                        .WithMany("Druzyny")
                        .HasForeignKey("UzytkownikId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Uzytkownik");
                });

            modelBuilder.Entity("FantasyApp.Models.SkladDruzyny", b =>
                {
                    b.HasOne("FantasyApp.Models.Druzyna", "Druzyna")
                        .WithMany("SkladDruzyny")
                        .HasForeignKey("DruzynaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FantasyApp.Models.Zawodnik", "Zawodnik")
                        .WithMany("SkladDruzyny")
                        .HasForeignKey("ZawodnikId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Druzyna");

                    b.Navigation("Zawodnik");
                });

            modelBuilder.Entity("FantasyApp.Models.StatystykiZawodnikow", b =>
                {
                    b.HasOne("FantasyApp.Models.Druzyna", "Druzyna")
                        .WithMany("Statystyki")
                        .HasForeignKey("DruzynaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FantasyApp.Models.Zawodnik", "Zawodnik")
                        .WithMany("Statystyki")
                        .HasForeignKey("ZawodnikId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Druzyna");

                    b.Navigation("Zawodnik");
                });

            modelBuilder.Entity("FantasyApp.Models.Transfer", b =>
                {
                    b.HasOne("FantasyApp.Models.Druzyna", "Druzyna")
                        .WithMany("Transfery")
                        .HasForeignKey("DruzynaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FantasyApp.Models.Zawodnik", "Zawodnik")
                        .WithMany("Transfery")
                        .HasForeignKey("ZawodnikId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Druzyna");

                    b.Navigation("Zawodnik");
                });

            modelBuilder.Entity("FantasyApp.Models.Zawodnik", b =>
                {
                    b.HasOne("FantasyApp.Models.Klub", "Klub")
                        .WithMany("Zawodnicy")
                        .HasForeignKey("KlubId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Klub");
                });

            modelBuilder.Entity("FantasyApp.Models.Druzyna", b =>
                {
                    b.Navigation("SkladDruzyny");

                    b.Navigation("Statystyki");

                    b.Navigation("Transfery");
                });

            modelBuilder.Entity("FantasyApp.Models.Klub", b =>
                {
                    b.Navigation("Zawodnicy");
                });

            modelBuilder.Entity("FantasyApp.Models.Uzytkownik", b =>
                {
                    b.Navigation("Druzyny");
                });

            modelBuilder.Entity("FantasyApp.Models.Zawodnik", b =>
                {
                    b.Navigation("SkladDruzyny");

                    b.Navigation("Statystyki");

                    b.Navigation("Transfery");
                });
#pragma warning restore 612, 618
        }
    }
}