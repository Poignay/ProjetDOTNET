﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjetDotNet.DataAccess;

namespace ProjetDotNet.Migrations
{
    [DbContext(typeof(DbContext))]
    partial class DbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854");

            modelBuilder.Entity("ProjetDotNet.Class.Episode", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Statut");

                    b.Property<int>("age_minimun");

                    b.Property<string>("commentaire");

                    b.Property<DateTime>("date_sortie");

                    b.Property<TimeSpan>("duree");

                    b.Property<int>("id_Media");

                    b.Property<string>("nom");

                    b.Property<int>("note");

                    b.Property<int>("numero");

                    b.Property<int>("saison");

                    b.Property<string>("synopsis");

                    b.HasKey("Id");

                    b.ToTable("Episodes");
                });

            modelBuilder.Entity("ProjetDotNet.Class.Genre", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("nom");

                    b.HasKey("id");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("ProjetDotNet.Class.Media", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Age_minimum");

                    b.Property<bool>("Audio_Description");

                    b.Property<string>("Commentaire");

                    b.Property<DateTime>("Date_Creation");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<byte[]>("Image");

                    b.Property<int>("Langue_Media");

                    b.Property<int>("Langue_vo");

                    b.Property<int>("Note");

                    b.Property<int>("Sous_titre");

                    b.Property<int>("Statut");

                    b.Property<bool>("Support_numerique");

                    b.Property<bool>("Support_physique");

                    b.Property<string>("Synopsis");

                    b.Property<string>("Titre");

                    b.HasKey("id");

                    b.ToTable("Medias");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Media");
                });

            modelBuilder.Entity("ProjetDotNet.Class.Media_Genre", b =>
                {
                    b.Property<int>("GenreId");

                    b.Property<int>("MediaId");

                    b.HasKey("GenreId", "MediaId");

                    b.HasIndex("MediaId");

                    b.ToTable("Media_Genres");
                });

            modelBuilder.Entity("ProjetDotNet.Class.Media_Personne", b =>
                {
                    b.Property<int>("MediaId");

                    b.Property<int>("PersonneID");

                    b.Property<int>("Fontion");

                    b.Property<string>("Role");

                    b.HasKey("MediaId", "PersonneID");

                    b.HasIndex("PersonneID");

                    b.ToTable("Media_Personnes");
                });

            modelBuilder.Entity("ProjetDotNet.Class.Personne", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Ami");

                    b.Property<int>("Civilite");

                    b.Property<int>("Nationalite");

                    b.Property<byte[]>("Photo");

                    b.Property<string>("Prenom");

                    b.Property<string>("nom");

                    b.HasKey("id");

                    b.ToTable("Personnes");
                });

            modelBuilder.Entity("ProjetDotNet.Class.Pret", b =>
                {
                    b.Property<int>("MediaId");

                    b.Property<int>("PersonneID");

                    b.Property<DateTime>("date_Pret");

                    b.Property<DateTime>("date_Retour");

                    b.HasKey("MediaId", "PersonneID");

                    b.HasIndex("PersonneID");

                    b.ToTable("Prets");
                });

            modelBuilder.Entity("ProjetDotNet.Class.Film", b =>
                {
                    b.HasBaseType("ProjetDotNet.Class.Media");

                    b.Property<TimeSpan>("Duree");

                    b.HasDiscriminator().HasValue("Film");
                });

            modelBuilder.Entity("ProjetDotNet.Class.Serie", b =>
                {
                    b.HasBaseType("ProjetDotNet.Class.Media");

                    b.Property<int>("Duree")
                        .HasColumnName("Serie_Duree");

                    b.Property<int>("Nb_Saison");

                    b.HasDiscriminator().HasValue("Serie");
                });

            modelBuilder.Entity("ProjetDotNet.Class.Media_Genre", b =>
                {
                    b.HasOne("ProjetDotNet.Class.Genre", "Genre")
                        .WithMany("Media")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ProjetDotNet.Class.Media", "Media")
                        .WithMany("Genres")
                        .HasForeignKey("MediaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProjetDotNet.Class.Media_Personne", b =>
                {
                    b.HasOne("ProjetDotNet.Class.Media", "Media")
                        .WithMany("PersonneMedia")
                        .HasForeignKey("MediaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ProjetDotNet.Class.Personne", "Personne")
                        .WithMany("MediaPersonne")
                        .HasForeignKey("PersonneID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProjetDotNet.Class.Pret", b =>
                {
                    b.HasOne("ProjetDotNet.Class.Media", "Media")
                        .WithMany("PersonnePret")
                        .HasForeignKey("MediaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ProjetDotNet.Class.Personne", "Personne")
                        .WithMany("MediaPret")
                        .HasForeignKey("PersonneID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
