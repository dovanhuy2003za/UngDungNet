using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class User
    {
        public int Id { get; set; } 

        [Required(ErrorMessage = "Tên người dùng là bắt buộc.")]
        [StringLength(50, ErrorMessage = "Tên người dùng không được dài quá 50 ký tự.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Mật khẩu là bắt buộc.")]
        public string Password { get; set; } 

        [Required(ErrorMessage = "Họ và tên là bắt buộc.")]
        [StringLength(100, ErrorMessage = "Tên đầy đủ không được dài quá 100 ký tự.")]
        public string Fullname { get; set; }

        [Required(ErrorMessage = "Giới tính là bắt buộc.")]
        public string Gender { get; set; } 

        [Required(ErrorMessage = "Bắt buộc phải có ngày sinh.")]
        public DateTime Birthday { get; set; }

        public bool Status { get; set; } 

        [StringLength(200, ErrorMessage = "Địa chỉ không được dài quá 200 ký tự.")]
        public string Address { get; set; }

        [StringLength(10, ErrorMessage = "Số điện thoại không được dài quá 10 ký tự.")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Email là bắt buộc.")]
        [StringLength(100, ErrorMessage = "Email không được dài quá 100 ký tự.")]
        [EmailAddress(ErrorMessage = "Địa chỉ Email không hợp lệ.")]
        public string Email { get; set; }
    }
}
