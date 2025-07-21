using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BailamMVC.Migrations
{
    /// <inheritdoc />
    public partial class AddMaHTPPToDaiLy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DaiLy_HeThongPhanPhoi_HeThongPhanPhoiMaHTTP",
                table: "DaiLy");

            migrationBuilder.DropIndex(
                name: "IX_DaiLy_HeThongPhanPhoiMaHTTP",
                table: "DaiLy");

            migrationBuilder.DropColumn(
                name: "HeThongPhanPhoiMaHTTP",
                table: "DaiLy");

            migrationBuilder.RenameColumn(
                name: "MaHTTP",
                table: "HeThongPhanPhoi",
                newName: "MaHTPP");

            migrationBuilder.RenameColumn(
                name: "MaHTTP",
                table: "DaiLy",
                newName: "MaHTPP");

            migrationBuilder.AlterColumn<string>(
                name: "TenHTPP",
                table: "HeThongPhanPhoi",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TenDaiLy",
                table: "DaiLy",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NguoiDaiDien",
                table: "DaiLy",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DienThoai",
                table: "DaiLy",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DiaChi",
                table: "DaiLy",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DaiLy_MaHTPP",
                table: "DaiLy",
                column: "MaHTPP");

            migrationBuilder.AddForeignKey(
                name: "FK_DaiLy_HeThongPhanPhoi_MaHTPP",
                table: "DaiLy",
                column: "MaHTPP",
                principalTable: "HeThongPhanPhoi",
                principalColumn: "MaHTPP");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DaiLy_HeThongPhanPhoi_MaHTPP",
                table: "DaiLy");

            migrationBuilder.DropIndex(
                name: "IX_DaiLy_MaHTPP",
                table: "DaiLy");

            migrationBuilder.RenameColumn(
                name: "MaHTPP",
                table: "HeThongPhanPhoi",
                newName: "MaHTTP");

            migrationBuilder.RenameColumn(
                name: "MaHTPP",
                table: "DaiLy",
                newName: "MaHTTP");

            migrationBuilder.AlterColumn<string>(
                name: "TenHTPP",
                table: "HeThongPhanPhoi",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "TenDaiLy",
                table: "DaiLy",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "NguoiDaiDien",
                table: "DaiLy",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "DienThoai",
                table: "DaiLy",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "DiaChi",
                table: "DaiLy",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<string>(
                name: "HeThongPhanPhoiMaHTTP",
                table: "DaiLy",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DaiLy_HeThongPhanPhoiMaHTTP",
                table: "DaiLy",
                column: "HeThongPhanPhoiMaHTTP");

            migrationBuilder.AddForeignKey(
                name: "FK_DaiLy_HeThongPhanPhoi_HeThongPhanPhoiMaHTTP",
                table: "DaiLy",
                column: "HeThongPhanPhoiMaHTTP",
                principalTable: "HeThongPhanPhoi",
                principalColumn: "MaHTTP");
        }
    }
}
