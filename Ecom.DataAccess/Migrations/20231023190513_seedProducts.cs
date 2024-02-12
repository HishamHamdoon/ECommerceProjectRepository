using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ECommerceProject.Migrations
{
    /// <inheritdoc />
    public partial class seedProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Author", "CategoryId", "Description", "ISBN", "ImageUrl", "ListPrice", "Price", "Price100", "Price50", "Title" },
                values: new object[,]
                {
                    { 1, "Hisham", 5, "this is a C# book", "ASDCV456", "", 88.0, 100.0, 55.0, 90.0, "C# for beginners" },
                    { 2, "Obai", 5, "this is a Cdotnet book in pdf", "ASDCV4564566", "", 88.0, 100.0, 55.0, 90.0, "dornet for beginners" },
                    { 3, "Ahmed", 6, "this is a C++ book for beginners", "ASDCV456", "", 88.0, 100.0, 55.0, 90.0, "C++ for beginners" },
                    { 4, "Ali", 5, "this is a F# book for beginners", "ASDCV4asdf56", "", 88.0, 100.0, 55.0, 90.0, "F# for beginners" },
                    { 5, "Musa", 6, "this is a PHP book for beginners", "ASDCV456884513", "", 88.0, 55.0, 150.0, 66.0, "PHP for beginners" },
                    { 6, "Ahmed Taha", 5, "this is a Media book for beginners", "ASDCV4sd2356", "", 50.0, 45.0, 22.0, 10.0, "Media for beginners" },
                    { 7, "Hisham", 6, "this is a C# book", "ASDCV456", "", 88.0, 100.0, 55.0, 90.0, "C# for beginners" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);
        }
    }
}
