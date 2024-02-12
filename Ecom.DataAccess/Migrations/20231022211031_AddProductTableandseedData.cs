using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ECommerceProject.Migrations
{
    /// <inheritdoc />
    public partial class AddProductTableandseedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ListPrice = table.Column<double>(type: "float", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Price50 = table.Column<double>(type: "float", nullable: false),
                    Price100 = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Author", "Description", "ISBN", "ListPrice", "Price", "Price100", "Price50", "Title" },
                values: new object[,]
                {
                    { 1, "Hisham", "this is a C# book", "ASDCV456", 88.0, 100.0, 55.0, 90.0, "C# for beginners" },
                    { 2, "Obai", "this is a Cdotnet book in pdf", "ASDCV4564566", 88.0, 100.0, 55.0, 90.0, "dornet for beginners" },
                    { 3, "Ahmed", "this is a C++ book for beginners", "ASDCV456", 88.0, 100.0, 55.0, 90.0, "C++ for beginners" },
                    { 4, "Ali", "this is a F# book for beginners", "ASDCV4asdf56", 88.0, 100.0, 55.0, 90.0, "F# for beginners" },
                    { 5, "Musa", "this is a PHP book for beginners", "ASDCV456884513", 88.0, 55.0, 150.0, 66.0, "PHP for beginners" },
                    { 6, "Ahmed Taha", "this is a Media book for beginners", "ASDCV4sd2356", 50.0, 45.0, 22.0, 10.0, "Media for beginners" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
