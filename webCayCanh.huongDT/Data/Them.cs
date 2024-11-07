using System;
using System.Collections.Generic;

namespace webCayCanh.huongDT.Data;

public partial class Them
{
    public int MaSp { get; set; }

    public int MaGh { get; set; }

    public int? Soluong { get; set; }

    public virtual GioHang MaGhNavigation { get; set; } = null!;

    public virtual SanPham MaSpNavigation { get; set; } = null!;
}
