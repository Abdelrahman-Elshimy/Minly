using Microsoft.EntityFrameworkCore.Migrations;

namespace Minly.Data.Migrations
{
    public partial class Events : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5eb6f85b-b77c-4199-a350-8ce57493a08f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9cc25b41-c4ae-4e99-b56c-2c0cd4695034");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f5845d4a-eb9b-44c3-b6db-ec7db01d7583");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f9b2e6eb-f46d-4bc8-bdd9-36cb45b3ddeb", "0fc3caa1-6c5a-481c-b47a-bd1d335ef9b1", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5cc64876-1c26-4698-8065-0a72db7cf659", "059edf50-a28f-45e7-a410-1c31cf3a9a22", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e067c1de-a9ca-4c59-badf-654b7061e179", "d7d919ef-c065-4345-9d32-32dd8705c890", "Star", "STAR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5cc64876-1c26-4698-8065-0a72db7cf659");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e067c1de-a9ca-4c59-badf-654b7061e179");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f9b2e6eb-f46d-4bc8-bdd9-36cb45b3ddeb");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9cc25b41-c4ae-4e99-b56c-2c0cd4695034", "6e9b72d6-a5fc-43fd-b8bb-9e5747415896", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5eb6f85b-b77c-4199-a350-8ce57493a08f", "8421f43e-78da-4202-90c8-ac899ce91ad6", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f5845d4a-eb9b-44c3-b6db-ec7db01d7583", "34a4c632-bd7e-4a3b-b2cf-cded7e781abb", "Star", "STAR" });
        }
    }
}
