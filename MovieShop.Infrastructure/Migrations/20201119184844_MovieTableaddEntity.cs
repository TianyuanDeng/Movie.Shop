using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieShop.Infrastructure.Migrations
{
    public partial class MovieTableaddEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BackdropUrl",
                table: "Movie",
                type: "nvarchar(2084)",
                maxLength: 2084,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Budget",
                table: "Movie",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Movie",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Movie",
                type: "datetime2",
                nullable: true,
                defaultValueSql: "getdate()");

            migrationBuilder.AddColumn<string>(
                name: "ImdbUrl",
                table: "Movie",
                type: "nvarchar(2084)",
                maxLength: 2084,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OriginalLanguage",
                table: "Movie",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PosterUrl",
                table: "Movie",
                type: "nvarchar(2084)",
                maxLength: 2084,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Movie",
                type: "decimal(5,2)",
                nullable: true,
                defaultValue: 9.9m);

            migrationBuilder.AddColumn<DateTime>(
                name: "ReleaseDate",
                table: "Movie",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Revenue",
                table: "Movie",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RunTime",
                table: "Movie",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Tagline",
                table: "Movie",
                type: "nvarchar(512)",
                maxLength: 512,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TmdbUrl",
                table: "Movie",
                type: "nvarchar(2084)",
                maxLength: 2084,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Movie",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Movie",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BackdropUrl",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "Budget",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "ImdbUrl",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "OriginalLanguage",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "PosterUrl",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "ReleaseDate",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "Revenue",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "RunTime",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "Tagline",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "TmdbUrl",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Movie");
        }
    }
}
