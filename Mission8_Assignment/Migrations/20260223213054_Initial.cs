using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Mission8_Assignment.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategoryName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Quadrants",
                columns: table => new
                {
                    TaskId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    task = table.Column<string>(type: "TEXT", nullable: false),
                    dueDate = table.Column<string>(type: "TEXT", nullable: false),
                    quadrant = table.Column<int>(type: "INTEGER", nullable: false),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: true),
                    completed = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quadrants", x => x.TaskId);
                    table.ForeignKey(
                        name: "FK_Quadrants_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId");
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Work" },
                    { 2, "Personal" },
                    { 3, "Health" }
                });

            migrationBuilder.InsertData(
                table: "Quadrants",
                columns: new[] { "TaskId", "CategoryId", "completed", "dueDate", "quadrant", "task" },
                values: new object[,]
                {
                    { 1, 1, false, "2026-03-01", 1, "Finish report" },
                    { 2, 3, false, "2026-03-05", 2, "Call doctor" },
                    { 3, 2, true, "2026-02-25", 3, "Buy groceries" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Quadrants_CategoryId",
                table: "Quadrants",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Quadrants");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
