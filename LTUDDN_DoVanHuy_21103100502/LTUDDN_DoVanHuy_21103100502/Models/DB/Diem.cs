using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LTUDDN_DoVanHuy_21103100502.Models.DB;

public partial class Diem
{

    [ForeignKey("SinhVien")]
    public string Masv { get; set; } 

    public string Tenmh { get; set; } = null!;

    [Required]
    [Range(0, 10)]
    public double? Diem1 { get; set; }

    public virtual SinhVien MasvNavigation { get; set; } = null!;
}
