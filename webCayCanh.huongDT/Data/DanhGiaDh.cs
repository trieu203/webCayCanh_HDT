using System;
using System.Collections.Generic;

namespace webCayCanh.huongDT.Data;

public partial class DanhGiaDh
{
    public int MaDg { get; set; }

    public int MaDh { get; set; }

    public string? NoiDungDg { get; set; }

    public int? ThangDiem { get; set; }

    public DateTime? NgayDg { get; set; }

    public virtual ICollection<DonHang> DonHangs { get; set; } = new List<DonHang>();

    public virtual DonHang MaDhNavigation { get; set; } = null!;
}
