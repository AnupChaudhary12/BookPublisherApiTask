using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookPublisher.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EditionAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Edition",
                table: "Books",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Edition",
                table: "Books");
        }
    }
}
