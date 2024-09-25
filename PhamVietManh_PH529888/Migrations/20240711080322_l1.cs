using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhamVietManh_PH529888.Migrations
{
    public partial class l1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SanPham",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    ImgURL = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanPham", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "SanPham",
                columns: new[] { "id", "ImgURL", "Name", "SoLuong" },
                values: new object[,]
                {
                    { new Guid("11c1ad61-8d91-45fa-8468-facea4a98553"), "...", "Hung", 1 },
                    { new Guid("5ba990c1-6b03-4f24-92c0-bd497eafc665"), "...", "Keo", 5 },
                    { new Guid("9cf0399c-8fab-4058-9c35-d412786da05c"), "...", "Khoai", 8 },
                    { new Guid("b55131d0-625b-44b9-a108-426ba921a14a"), "...", "Banh", 9 },
                    { new Guid("d2f25cb8-0a15-4a3a-948b-2d55ef6d6b04"), "...", "Dua hau", 5 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SanPham");
        }
    }
}
