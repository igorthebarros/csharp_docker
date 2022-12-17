using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    /// <inheritdoc />
    public partial class userentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "App");

            migrationBuilder.CreateTable(
                name: "User",
                schema: "App",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    NAME = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false),
                    SURNAME = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false),
                    CREATEDAT = table.Column<DateTime>(name: "CREATED_AT", type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    ISACTIVE = table.Column<bool>(name: "IS_ACTIVE", type: "boolean", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User",
                schema: "App");
        }
    }
}
