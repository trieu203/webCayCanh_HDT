using System;
using System.Collections.Generic;

namespace webCayCanh.huongDT.Data;

public partial class Dathang
{
    public int MaKh { get; set; }

    public int MaGh { get; set; }

    public virtual GioHang MaGhNavigation { get; set; } = null!;
}
