using System;
using System.Collections.Generic;

namespace webCayCanh.huongDT.Data;

public partial class PhanLoaiSp
{
    public int MaPhanLoai { get; set; }

    public string? TenPhanLoai { get; set; }

    public string? MoTaPl { get; set; }

    public virtual ICollection<SanPham> SanPhams { get; set; } = new List<SanPham>();
}
