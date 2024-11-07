using System;
using System.Collections.Generic;

namespace webCayCanh.huongDT.Data;

public partial class DonHang
{
    public int MaDh { get; set; }

    public int MaKh { get; set; }

    public int? MaDg { get; set; }

    public DateTime? NgayDat { get; set; }

    public DateTime? NgayNhan { get; set; }

    public double? TongTien { get; set; }

    public virtual ICollection<DanhGiaDh> DanhGiaDhs { get; set; } = new List<DanhGiaDh>();

    public virtual DanhGiaDh? MaDgNavigation { get; set; }

    public virtual ICollection<SanPham> MaSps { get; set; } = new List<SanPham>();
}
