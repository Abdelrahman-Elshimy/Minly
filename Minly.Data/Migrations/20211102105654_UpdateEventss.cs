using Microsoft.EntityFrameworkCore.Migrations;

namespace Minly.Data.Migrations
{
    public partial class UpdateEventss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0407b62b-582c-4451-91ab-dc43bc3ebb99");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2015b70b-8bfc-429c-a497-1329b1cf5549");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "737f5352-9103-4acc-8895-52f16559b001");

            migrationBuilder.AddColumn<double>(
                name: "Rate",
                table: "Events",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a567cbfd-aac0-458a-9001-5b9d79cc92e6", "88a8f814-ef1c-4add-944b-31f6e39c5eb7", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0593a4bd-daf3-4523-a21d-06f03c5bf4ba", "466d6e4f-1565-46c3-ae1b-08c260983c41", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6067050f-9853-47a7-a781-9539da3ad391", "525c6126-cd7a-4078-94b9-920b65a542fb", "Star", "STAR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0593a4bd-daf3-4523-a21d-06f03c5bf4ba");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6067050f-9853-47a7-a781-9539da3ad391");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a567cbfd-aac0-458a-9001-5b9d79cc92e6");

            migrationBuilder.DropColumn(
                name: "Rate",
                table: "Events");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0407b62b-582c-4451-91ab-dc43bc3ebb99", "01b13d69-bd8c-417c-ac17-74eafacd42a0", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2015b70b-8bfc-429c-a497-1329b1cf5549", "e2eb5bc3-41c4-48bf-8b6e-dbedd833e008", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "737f5352-9103-4acc-8895-52f16559b001", "7a4f03b3-8d74-480c-b293-34eae0f0c01d", "Star", "STAR" });
        }
    }
}
