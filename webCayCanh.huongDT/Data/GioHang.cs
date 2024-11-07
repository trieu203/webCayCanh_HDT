using System;
using System.Collections.Generic;

namespace webCayCanh.huongDT.Data;

public partial class GioHang
{
    public int MaGh { get; set; }

    public int? SoLuong { get; set; }

    public double? DonGia { get; set; }

    public double? TienTamTinh { get; set; }

    public virtual ICollection<Dathang> Dathangs { get; set; } = new List<Dathang>();

    public virtual ICollection<Them> Thems { get; set; } = new List<Them>();
}
