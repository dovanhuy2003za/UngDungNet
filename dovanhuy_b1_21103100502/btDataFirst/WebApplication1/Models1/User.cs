using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models1;

public partial class User
{
    public int UserId { get; set; }


    [StringLength(5, ErrorMessage = "Tên người dùng không được dài quá 5 ký tự.")]
    public string UserName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;
}
