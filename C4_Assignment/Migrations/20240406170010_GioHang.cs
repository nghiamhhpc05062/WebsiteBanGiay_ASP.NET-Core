using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace C4_Assignment.Migrations
{
    public partial class GioHang : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CungCaps",
                columns: table => new
                {
                    CungCapID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenCungCap = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThanhPho = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuocGia = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CungCaps", x => x.CungCapID);
                });

            migrationBuilder.CreateTable(
                name: "DanhMucss",
                columns: table => new
                {
                    DanhMucID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenDanhMuc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HinhAnh = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhMucss", x => x.DanhMucID);
                });

            migrationBuilder.CreateTable(
                name: "KhachHangs",
                columns: table => new
                {
                    KhachHangID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoTen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoDienThoai = table.Column<double>(type: "float", nullable: false),
                    MaBuuDien = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhachHangs", x => x.KhachHangID);
                });

            migrationBuilder.CreateTable(
                name: "NhanViens",
                columns: table => new
                {
                    NhanVienID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Anh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HoTen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayVaoLam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChucVu = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhanViens", x => x.NhanVienID);
                });

            migrationBuilder.CreateTable(
                name: "TaiKhoans",
                columns: table => new
                {
                    TaiKhoanID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenDangNhap = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MatKhau = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HoTen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GioiTinh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhanQuyen = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaiKhoans", x => x.TaiKhoanID);
                });

            migrationBuilder.CreateTable(
                name: "SanPhams",
                columns: table => new
                {
                    SanPhamID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenSanPham = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HinhAnh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gia = table.Column<double>(type: "float", nullable: false),
                    MauSac = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KichThuoc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DanhMucID = table.Column<int>(type: "int", nullable: false),
                    CungCapID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanPhams", x => x.SanPhamID);
                    table.ForeignKey(
                        name: "FK_SanPhams_CungCaps_CungCapID",
                        column: x => x.CungCapID,
                        principalTable: "CungCaps",
                        principalColumn: "CungCapID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SanPhams_DanhMucss_DanhMucID",
                        column: x => x.DanhMucID,
                        principalTable: "DanhMucss",
                        principalColumn: "DanhMucID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DonHangs",
                columns: table => new
                {
                    DonHangID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NgayDatHang = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrangThai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KhachHangID = table.Column<int>(type: "int", nullable: false),
                    NhanVienID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonHangs", x => x.DonHangID);
                    table.ForeignKey(
                        name: "FK_DonHangs_KhachHangs_KhachHangID",
                        column: x => x.KhachHangID,
                        principalTable: "KhachHangs",
                        principalColumn: "KhachHangID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DonHangs_NhanViens_NhanVienID",
                        column: x => x.NhanVienID,
                        principalTable: "NhanViens",
                        principalColumn: "NhanVienID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GioHangs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    soluong = table.Column<int>(type: "int", nullable: false),
                    TaiKhoanID = table.Column<int>(type: "int", nullable: false),
                    SanPhamID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GioHangs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GioHangs_SanPhams_SanPhamID",
                        column: x => x.SanPhamID,
                        principalTable: "SanPhams",
                        principalColumn: "SanPhamID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GioHangs_TaiKhoans_TaiKhoanID",
                        column: x => x.TaiKhoanID,
                        principalTable: "TaiKhoans",
                        principalColumn: "TaiKhoanID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DonHangChiTiets",
                columns: table => new
                {
                    DonHangChiTietID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SanPhamID = table.Column<int>(type: "int", nullable: false),
                    DonHangID = table.Column<int>(type: "int", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonHangChiTiets", x => x.DonHangChiTietID);
                    table.ForeignKey(
                        name: "FK_DonHangChiTiets_DonHangs_DonHangID",
                        column: x => x.DonHangID,
                        principalTable: "DonHangs",
                        principalColumn: "DonHangID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DonHangChiTiets_SanPhams_SanPhamID",
                        column: x => x.SanPhamID,
                        principalTable: "SanPhams",
                        principalColumn: "SanPhamID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DonHangChiTiets_DonHangID",
                table: "DonHangChiTiets",
                column: "DonHangID");

            migrationBuilder.CreateIndex(
                name: "IX_DonHangChiTiets_SanPhamID",
                table: "DonHangChiTiets",
                column: "SanPhamID");

            migrationBuilder.CreateIndex(
                name: "IX_DonHangs_KhachHangID",
                table: "DonHangs",
                column: "KhachHangID");

            migrationBuilder.CreateIndex(
                name: "IX_DonHangs_NhanVienID",
                table: "DonHangs",
                column: "NhanVienID");

            migrationBuilder.CreateIndex(
                name: "IX_GioHangs_SanPhamID",
                table: "GioHangs",
                column: "SanPhamID");

            migrationBuilder.CreateIndex(
                name: "IX_GioHangs_TaiKhoanID",
                table: "GioHangs",
                column: "TaiKhoanID");

            migrationBuilder.CreateIndex(
                name: "IX_SanPhams_CungCapID",
                table: "SanPhams",
                column: "CungCapID");

            migrationBuilder.CreateIndex(
                name: "IX_SanPhams_DanhMucID",
                table: "SanPhams",
                column: "DanhMucID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DonHangChiTiets");

            migrationBuilder.DropTable(
                name: "GioHangs");

            migrationBuilder.DropTable(
                name: "DonHangs");

            migrationBuilder.DropTable(
                name: "SanPhams");

            migrationBuilder.DropTable(
                name: "TaiKhoans");

            migrationBuilder.DropTable(
                name: "KhachHangs");

            migrationBuilder.DropTable(
                name: "NhanViens");

            migrationBuilder.DropTable(
                name: "CungCaps");

            migrationBuilder.DropTable(
                name: "DanhMucss");
        }
    }
}
