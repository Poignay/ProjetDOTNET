using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetDotNet.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Episodes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    id_Media = table.Column<int>(nullable: false),
                    nom = table.Column<string>(nullable: true),
                    duree = table.Column<TimeSpan>(nullable: false),
                    numero = table.Column<int>(nullable: false),
                    date_sortie = table.Column<DateTime>(nullable: false),
                    saison = table.Column<int>(nullable: false),
                    synopsis = table.Column<string>(nullable: true),
                    age_minimun = table.Column<int>(nullable: false),
                    Statut = table.Column<int>(nullable: false),
                    note = table.Column<int>(nullable: false),
                    commentaire = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Episodes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Films",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Titre = table.Column<string>(nullable: true),
                    Statut = table.Column<int>(nullable: false),
                    Date_Creation = table.Column<DateTime>(nullable: false),
                    Note = table.Column<int>(nullable: false),
                    Commentaire = table.Column<string>(nullable: true),
                    Synopsis = table.Column<string>(nullable: true),
                    Age_minimum = table.Column<int>(nullable: false),
                    Langue_vo = table.Column<int>(nullable: false),
                    Langue_Media = table.Column<int>(nullable: false),
                    Sous_titre = table.Column<int>(nullable: false),
                    Audio_Description = table.Column<bool>(nullable: false),
                    Support_physique = table.Column<bool>(nullable: false),
                    Support_numerique = table.Column<bool>(nullable: false),
                    Image = table.Column<byte[]>(nullable: true),
                    Duree = table.Column<TimeSpan>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Films", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nom = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Media_Genres",
                columns: table => new
                {
                    Id_media = table.Column<int>(nullable: false),
                    Id_genre = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Media_Genres", x => new { x.Id_genre, x.Id_media });
                });

            migrationBuilder.CreateTable(
                name: "Media_Personnes",
                columns: table => new
                {
                    id_Media = table.Column<int>(nullable: false),
                    id_Personne = table.Column<int>(nullable: false),
                    Fontion = table.Column<int>(nullable: false),
                    Role = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Media_Personnes", x => new { x.id_Media, x.id_Personne });
                });

            migrationBuilder.CreateTable(
                name: "Personnes",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nom = table.Column<string>(nullable: true),
                    Civilite = table.Column<int>(nullable: false),
                    Prenom = table.Column<string>(nullable: true),
                    Nationalite = table.Column<int>(nullable: false),
                    Photo = table.Column<byte[]>(nullable: true),
                    Ami = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personnes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Prets",
                columns: table => new
                {
                    Id_media = table.Column<int>(nullable: false),
                    Id_personne = table.Column<int>(nullable: false),
                    date_Pret = table.Column<DateTime>(nullable: false),
                    date_Retour = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prets", x => new { x.Id_media, x.Id_personne });
                });

            migrationBuilder.CreateTable(
                name: "Series",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Titre = table.Column<string>(nullable: true),
                    Statut = table.Column<int>(nullable: false),
                    Date_Creation = table.Column<DateTime>(nullable: false),
                    Note = table.Column<int>(nullable: false),
                    Commentaire = table.Column<string>(nullable: true),
                    Synopsis = table.Column<string>(nullable: true),
                    Age_minimum = table.Column<int>(nullable: false),
                    Langue_vo = table.Column<int>(nullable: false),
                    Langue_Media = table.Column<int>(nullable: false),
                    Sous_titre = table.Column<int>(nullable: false),
                    Audio_Description = table.Column<bool>(nullable: false),
                    Support_physique = table.Column<bool>(nullable: false),
                    Support_numerique = table.Column<bool>(nullable: false),
                    Image = table.Column<byte[]>(nullable: true),
                    Duree = table.Column<int>(nullable: false),
                    Nb_Saison = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Series", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Episodes");

            migrationBuilder.DropTable(
                name: "Films");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Media_Genres");

            migrationBuilder.DropTable(
                name: "Media_Personnes");

            migrationBuilder.DropTable(
                name: "Personnes");

            migrationBuilder.DropTable(
                name: "Prets");

            migrationBuilder.DropTable(
                name: "Series");
        }
    }
}
