using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CarpoolingApp.DB.Migrations
{
    /// <inheritdoc />
    public partial class Add_Seeds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Location",
                columns: new[] { "Id", "City", "PostalCode" },
                values: new object[,]
                {
                    { 1, "Ciney", "5590" },
                    { 2, "Charleroi", "6041" }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Administrator" },
                    { 2, "Manager" },
                    { 3, "Member" }
                });

            migrationBuilder.InsertData(
                table: "Institution",
                columns: new[] { "Id", "IsActive", "LocationId", "Name" },
                values: new object[,]
                {
                    { 1, true, 1, "Technobel" },
                    { 2, true, 2, "Technofutur" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Email", "FirstName", "InstitutionId", "IsActive", "LastName", "PasswordHash" },
                values: new object[,]
                {
                    { 1, "eva.admin@technobel.com", "Eva", 1, true, "Admin", "password" },
                    { 2, "herve.manager@technobel.com", "Hervé", 1, true, "Manager", "password" },
                    { 3, "gou.manager@technofutur.com", "Gou", 2, true, "Manager", "password" },
                    { 4, "loulou.member@technobel.com", "Loulou", 1, true, "Member", "password" },
                    { 5, "gg.member@technobel.com", "GG", 1, true, "Member", "password" },
                    { 6, "dydy.member@technobel.com", "Dydy", 1, true, "Member", "password" },
                    { 7, "yuki.member@technobel.com", "Yuki", 1, true, "Member", "password" },
                    { 8, "franchibou.member@technobel.com", "Franchibou", 1, true, "Member", "password" },
                    { 9, "tic.member@technofutur.com", "Tic", 2, true, "Member", "password" },
                    { 10, "tac.member@technofutur.com", "Tac", 2, true, "Member", "password" }
                });

            migrationBuilder.InsertData(
                table: "User_Role",
                columns: new[] { "Id", "RoleId", "UserId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 },
                    { 3, 2, 3 },
                    { 4, 3, 4 },
                    { 5, 3, 5 },
                    { 6, 3, 6 },
                    { 7, 3, 7 },
                    { 8, 3, 8 },
                    { 9, 3, 9 },
                    { 10, 3, 10 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User_Role",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "User_Role",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "User_Role",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "User_Role",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "User_Role",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "User_Role",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "User_Role",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "User_Role",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "User_Role",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "User_Role",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Institution",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Institution",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Location",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Location",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
