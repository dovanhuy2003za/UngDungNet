using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LTUDDN_DoVanHuy_21103100502.Models.DB;

public partial class SinhVien
{
    [Key]
    public string Masv { get; set; }

    [Required]
    [StringLength(50, MinimumLength = 4)]
    public string Hoten { get; set; }

    [Required]
    [Range(2000, 2006)]
    public int? Namsinh { get; set; }


    public string? Gioitinh { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    public virtual ICollection<Diem> Diems { get; set; } = new List<Diem>();
}
