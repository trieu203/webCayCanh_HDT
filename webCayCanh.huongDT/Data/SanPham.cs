using System;
using System.Collections.Generic;

namespace webCayCanh.huongDT.Data;

public partial class SanPham
{
    public int MaSp { get; set; }

    public int MaPhanLoai { get; set; }

    public string? TenSp { get; set; }

    public double? GiaSp { get; set; }

    public int? SoLuongTonKho { get; set; }

    public string? MoTaSp { get; set; }

    public virtual PhanLoaiSp MaPhanLoaiNavigation { get; set; } = null!;

    public virtual ICollection<Them> Thems { get; set; } = new List<Them>();

    public virtual ICollection<DonHang> MaDhs { get; set; } = new List<DonHang>();
}
