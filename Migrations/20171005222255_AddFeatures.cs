using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace vega.Migrations
{
    public partial class AddFeatures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Features (Name, Description) Values ('Feature 1', 'Description Feature 1')");
            migrationBuilder.Sql("INSERT INTO Features (Name, Description) Values ('Feature 2', 'Description Feature 2')");
            migrationBuilder.Sql("INSERT INTO Features (Name, Description) Values ('Feature 3', 'Description Feature 3')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Features");
        }
    }
}
