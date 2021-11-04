using Microsoft.EntityFrameworkCore.Migrations;

namespace Minly.Data.Migrations
{
    public partial class AddRates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9b662903-7d3c-4b0d-bd46-18f969300d54");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a913eefe-8d5c-427c-a872-3974fbb15929");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bf1946bf-4378-44d8-9a4f-d238063d2eb0");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a33e3ba6-bdab-49b1-ae3c-f8f8e767f54c", "9c561f8a-e628-4460-a210-5da205a9c21e", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "45627b9c-9e50-4dae-9943-1c11385ce130", "ed68ee9a-e9d9-4a3a-ab34-babf8670978c", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0b3f474e-6f90-4a3b-9720-2c89b6aa0ad2", "1d70f9c0-be6c-473c-a3e8-33f150cdc676", "Star", "STAR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0b3f474e-6f90-4a3b-9720-2c89b6aa0ad2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "45627b9c-9e50-4dae-9943-1c11385ce130");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a33e3ba6-bdab-49b1-ae3c-f8f8e767f54c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9b662903-7d3c-4b0d-bd46-18f969300d54", "bd18f40b-04d3-465e-ab6e-e2f7b3f46e2c", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bf1946bf-4378-44d8-9a4f-d238063d2eb0", "bdddc97c-97d0-4b71-a31c-0f97629dc3f0", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a913eefe-8d5c-427c-a872-3974fbb15929", "ccaea54a-a6c9-4656-9cce-8b9d9597e997", "Star", "STAR" });
        }
    }
}
