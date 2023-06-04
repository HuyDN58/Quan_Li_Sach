using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppData.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    IDNguoiDung = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    TaiKhoan = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    MatKhau = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Account__FCD7DB097A961C94", x => x.IDNguoiDung);
                });

            migrationBuilder.CreateTable(
                name: "KhuyenMai",
                columns: table => new
                {
                    IDKM = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    MaKM = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    NgayBD = table.Column<DateTime>(type: "date", nullable: true),
                    NgayKT = table.Column<DateTime>(type: "date", nullable: true),
                    PhanTramGiam = table.Column<int>(type: "int", nullable: true),
                    TrangThai = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__KhuyenMa__B87DC1AAD1E6023E", x => x.IDKM);
                });

            migrationBuilder.CreateTable(
                name: "NXB",
                columns: table => new
                {
                    IDNXB = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    MANSX = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    TenNXB = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__NXB__945B98FB6E74D8C6", x => x.IDNXB);
                });

            migrationBuilder.CreateTable(
                name: "SanPham",
                columns: table => new
                {
                    IDSP = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    MaSP = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    TenSP = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__SanPham__B87C02A5E1DD8D57", x => x.IDSP);
                });

            migrationBuilder.CreateTable(
                name: "TacGia",
                columns: table => new
                {
                    IDTG = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    MATG = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    TenTG = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TacGia__B87C3A8F63E83118", x => x.IDTG);
                });

            migrationBuilder.CreateTable(
                name: "KhachHang",
                columns: table => new
                {
                    IDKH = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Ma = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    TenKH = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    IDNguoiDung = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SDT = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TrangThai = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__KhachHan__B87DC1A74AD4F6F2", x => x.IDKH);
                    table.ForeignKey(
                        name: "FK__KhachHang__IDNgu__7C4F7684",
                        column: x => x.IDNguoiDung,
                        principalTable: "Account",
                        principalColumn: "IDNguoiDung");
                });

            migrationBuilder.CreateTable(
                name: "NhanVien",
                columns: table => new
                {
                    IDNV = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    MaNV = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    TenNV = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    SDT = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IDNguoiDung = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TrangThai = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__NhanVien__B87DC9B209D9DF83", x => x.IDNV);
                    table.ForeignKey(
                        name: "FK__NhanVien__IDNguo__787EE5A0",
                        column: x => x.IDNguoiDung,
                        principalTable: "Account",
                        principalColumn: "IDNguoiDung");
                });

            migrationBuilder.CreateTable(
                name: "SanPhamCT",
                columns: table => new
                {
                    IDSPCT = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    IDSP = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GiaNhap = table.Column<decimal>(type: "decimal(20,0)", nullable: true, defaultValueSql: "((0))"),
                    GiaBan = table.Column<decimal>(type: "decimal(20,0)", nullable: true, defaultValueSql: "((0))"),
                    SoLuongTon = table.Column<int>(type: "int", nullable: true),
                    IDTG = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IDNXB = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MoTa = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TrangThai = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__SanPhamC__83F7208FA954EE61", x => x.IDSPCT);
                    table.ForeignKey(
                        name: "FK__SanPhamCT__IDNXB__75A278F5",
                        column: x => x.IDNXB,
                        principalTable: "NXB",
                        principalColumn: "IDNXB");
                    table.ForeignKey(
                        name: "FK__SanPhamCT__IDSP__73BA3083",
                        column: x => x.IDSP,
                        principalTable: "SanPham",
                        principalColumn: "IDSP");
                    table.ForeignKey(
                        name: "FK__SanPhamCT__IDTG__74AE54BC",
                        column: x => x.IDTG,
                        principalTable: "TacGia",
                        principalColumn: "IDTG");
                });

            migrationBuilder.CreateTable(
                name: "GioHang",
                columns: table => new
                {
                    IDGH = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    IDKH = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__GioHang__B87DE222D100450C", x => x.IDGH);
                    table.ForeignKey(
                        name: "FK__GioHang__IDKH__7F2BE32F",
                        column: x => x.IDKH,
                        principalTable: "KhachHang",
                        principalColumn: "IDKH");
                });

            migrationBuilder.CreateTable(
                name: "HoaDon",
                columns: table => new
                {
                    IDHD = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    MaHD = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    IDKH = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IDNV = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IDKM = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "date", nullable: true),
                    TrangThai = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__HoaDon__B87C1A07599CB17A", x => x.IDHD);
                    table.ForeignKey(
                        name: "FK__HoaDon__IDKH__797309D9",
                        column: x => x.IDKH,
                        principalTable: "KhachHang",
                        principalColumn: "IDKH");
                    table.ForeignKey(
                        name: "FK__HoaDon__IDKM__7B5B524B",
                        column: x => x.IDKM,
                        principalTable: "KhuyenMai",
                        principalColumn: "IDKM");
                    table.ForeignKey(
                        name: "FK__HoaDon__IDNV__7A672E12",
                        column: x => x.IDNV,
                        principalTable: "NhanVien",
                        principalColumn: "IDNV");
                });

            migrationBuilder.CreateTable(
                name: "GioHangCT",
                columns: table => new
                {
                    IDGHCT = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    IDSPCT = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IDGH = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SoLuong = table.Column<int>(type: "int", nullable: true),
                    TrangThai = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__GioHangC__D592581F54369A12", x => x.IDGHCT);
                    table.ForeignKey(
                        name: "FK__GioHangCT__IDGH__7E37BEF6",
                        column: x => x.IDGH,
                        principalTable: "GioHang",
                        principalColumn: "IDGH");
                    table.ForeignKey(
                        name: "FK__GioHangCT__IDSPC__7D439ABD",
                        column: x => x.IDSPCT,
                        principalTable: "SanPhamCT",
                        principalColumn: "IDSPCT");
                });

            migrationBuilder.CreateTable(
                name: "HoaDonCT",
                columns: table => new
                {
                    IDHDCT = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    IDHD = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IDSPCT = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SoLuong = table.Column<int>(type: "int", nullable: true),
                    TrangThai = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__HoaDonCT__F8B33677718DB99B", x => x.IDHDCT);
                    table.ForeignKey(
                        name: "FK__HoaDonCT__IDHD__76969D2E",
                        column: x => x.IDHD,
                        principalTable: "HoaDon",
                        principalColumn: "IDHD");
                    table.ForeignKey(
                        name: "FK__HoaDonCT__IDSPCT__778AC167",
                        column: x => x.IDSPCT,
                        principalTable: "SanPhamCT",
                        principalColumn: "IDSPCT");
                });

            migrationBuilder.CreateIndex(
                name: "UQ__Account__D5B8C7F0938C33AA",
                table: "Account",
                column: "TaiKhoan",
                unique: true,
                filter: "[TaiKhoan] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_GioHang_IDKH",
                table: "GioHang",
                column: "IDKH");

            migrationBuilder.CreateIndex(
                name: "IX_GioHangCT_IDGH",
                table: "GioHangCT",
                column: "IDGH");

            migrationBuilder.CreateIndex(
                name: "IX_GioHangCT_IDSPCT",
                table: "GioHangCT",
                column: "IDSPCT");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDon_IDKH",
                table: "HoaDon",
                column: "IDKH");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDon_IDKM",
                table: "HoaDon",
                column: "IDKM");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDon_IDNV",
                table: "HoaDon",
                column: "IDNV");

            migrationBuilder.CreateIndex(
                name: "UQ__HoaDon__2725A6E11AE619B6",
                table: "HoaDon",
                column: "MaHD",
                unique: true,
                filter: "[MaHD] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDonCT_IDHD",
                table: "HoaDonCT",
                column: "IDHD");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDonCT_IDSPCT",
                table: "HoaDonCT",
                column: "IDSPCT");

            migrationBuilder.CreateIndex(
                name: "UQ__HoaDonCT__556FA067A5B4F8EF",
                table: "HoaDonCT",
                column: "SoLuong",
                unique: true,
                filter: "[SoLuong] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_KhachHang_IDNguoiDung",
                table: "KhachHang",
                column: "IDNguoiDung");

            migrationBuilder.CreateIndex(
                name: "UQ__KhachHan__3214CC9E87525964",
                table: "KhachHang",
                column: "Ma",
                unique: true,
                filter: "[Ma] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UQ__KhuyenMa__2725CF1420F347DB",
                table: "KhuyenMai",
                column: "MaKM",
                unique: true,
                filter: "[MaKM] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_NhanVien_IDNguoiDung",
                table: "NhanVien",
                column: "IDNguoiDung");

            migrationBuilder.CreateIndex(
                name: "UQ__NhanVien__2725D70B6E95CB40",
                table: "NhanVien",
                column: "MaNV",
                unique: true,
                filter: "[MaNV] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UQ__NXB__7ABD278C2C5293DF",
                table: "NXB",
                column: "MANSX",
                unique: true,
                filter: "[MANSX] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UQ__SanPham__2725081DD7C2DF5F",
                table: "SanPham",
                column: "MaSP",
                unique: true,
                filter: "[MaSP] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_SanPhamCT_IDNXB",
                table: "SanPhamCT",
                column: "IDNXB");

            migrationBuilder.CreateIndex(
                name: "IX_SanPhamCT_IDSP",
                table: "SanPhamCT",
                column: "IDSP");

            migrationBuilder.CreateIndex(
                name: "IX_SanPhamCT_IDTG",
                table: "SanPhamCT",
                column: "IDTG");

            migrationBuilder.CreateIndex(
                name: "UQ__TacGia__6023721B761EEB4A",
                table: "TacGia",
                column: "MATG",
                unique: true,
                filter: "[MATG] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GioHangCT");

            migrationBuilder.DropTable(
                name: "HoaDonCT");

            migrationBuilder.DropTable(
                name: "GioHang");

            migrationBuilder.DropTable(
                name: "HoaDon");

            migrationBuilder.DropTable(
                name: "SanPhamCT");

            migrationBuilder.DropTable(
                name: "KhachHang");

            migrationBuilder.DropTable(
                name: "KhuyenMai");

            migrationBuilder.DropTable(
                name: "NhanVien");

            migrationBuilder.DropTable(
                name: "NXB");

            migrationBuilder.DropTable(
                name: "SanPham");

            migrationBuilder.DropTable(
                name: "TacGia");

            migrationBuilder.DropTable(
                name: "Account");
        }
    }
}
