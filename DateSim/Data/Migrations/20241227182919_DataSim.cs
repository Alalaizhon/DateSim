using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DateSim.Migrations
{
    /// <inheritdoc />
    public partial class DataSim : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Interests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SelectedInterestString = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ProfileId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Interests_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "Id", "Age", "Description", "Gender", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { 1, 34, "Люблю жесточайше заниматься химией.", 0, "Image/Heisenberg.jpg", "Walter White" },
                    { 2, 32, "Длинные программисты из Пегий дудочника.", 1, "Image/Monica.png", "Monica Hall" },
                    { 3, 19, "черни цвет и мили личико", 1, "Image/Sit-main.png", "Kuromy" }
                });

            migrationBuilder.InsertData(
                table: "Interests",
                columns: new[] { "Id", "ProfileId", "SelectedInterestString" },
                values: new object[,]
                {
                    { 1, 1, "Спорт" },
                    { 2, 3, "Музыка" },
                    { 3, 3, "Путешествия" },
                    { 4, 1, "Наука" },
                    { 5, 2, "Технологии" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Interests_ProfileId",
                table: "Interests",
                column: "ProfileId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Interests");

            migrationBuilder.DropTable(
                name: "Profiles");
        }
    }
}
