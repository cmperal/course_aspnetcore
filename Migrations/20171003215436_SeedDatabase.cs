using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace vega.Migrations
{
    public partial class SeedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Makes (Name) Values ('Make1')");
            migrationBuilder.Sql("INSERT INTO Makes (Name) Values ('Make2')");
            migrationBuilder.Sql("INSERT INTO Makes (Name) Values ('Make3')");

            migrationBuilder.Sql("INSERT INTO Models (Name, MakeID) Values ('Make1-ModelA', (SELECT Id FROM Makes WHERE Name LIKE 'Make1'))");
            migrationBuilder.Sql("INSERT INTO Models (Name, MakeID) Values ('Make1-ModelB', (SELECT Id FROM Makes WHERE Name LIKE 'Make1'))");
            migrationBuilder.Sql("INSERT INTO Models (Name, MakeID) Values ('Make1-ModelC', (SELECT Id FROM Makes WHERE Name LIKE 'Make1'))");

            migrationBuilder.Sql("INSERT INTO Models (Name, MakeID) Values ('Make2-ModelA', (SELECT Id FROM Makes WHERE Name LIKE 'Make2'))");
            migrationBuilder.Sql("INSERT INTO Models (Name, MakeID) Values ('Make2-ModelB', (SELECT Id FROM Makes WHERE Name LIKE 'Make2'))");
            migrationBuilder.Sql("INSERT INTO Models (Name, MakeID) Values ('Make2-ModelC', (SELECT Id FROM Makes WHERE Name LIKE 'Make2'))");

            migrationBuilder.Sql("INSERT INTO Models (Name, MakeID) Values ('Make3-ModelA', (SELECT Id FROM Makes WHERE Name LIKE 'Make3'))");
            migrationBuilder.Sql("INSERT INTO Models (Name, MakeID) Values ('Make3-ModelB', (SELECT Id FROM Makes WHERE Name LIKE 'Make3'))");
            migrationBuilder.Sql("INSERT INTO Models (Name, MakeID) Values ('Make3-ModelC', (SELECT Id FROM Makes WHERE Name LIKE 'Make3'))");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Makes WHERE Name IN ('Make1', 'Make2', Make3'");
        }
    }
}
