using Microsoft.EntityFrameworkCore.Migrations;

namespace Minly.Data.Migrations
{
    public partial class UpdateEvents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2db7ad0c-cec1-478c-be10-84eb6da2b9ff");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "75a65fd8-bcc5-4802-9796-85d2479ec6b5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d4872b3f-f0f4-4c8b-916d-95664ca3f937");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Events",
                type: "nvarchar(max)",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Events");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d4872b3f-f0f4-4c8b-916d-95664ca3f937", "13e5cb9c-4943-415a-8aa1-89d2df58847b", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2db7ad0c-cec1-478c-be10-84eb6da2b9ff", "1e01fb85-f443-47df-8f30-698ab211f7e1", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "75a65fd8-bcc5-4802-9796-85d2479ec6b5", "199c0b81-ac1a-44dc-9250-60eb991dbb99", "Star", "STAR" });
        }
    }
}
