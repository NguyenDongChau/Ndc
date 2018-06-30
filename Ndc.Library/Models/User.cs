using System;
using System.ComponentModel.DataAnnotations;

namespace Ndc.Library.Models
{
    public class User
    {
        [Key]
        public Guid UserId { get; set; }

        [Required(ErrorMessage = "Tên đăng nhập là bắt buộc nhập")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Mật khẩu là bắt buộc nhập")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Địa chỉ email là bắt buộc nhập")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Địa chỉ email không đúng định dạng")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Họ tên là bắt buộc nhập")]
        public string FullName { get; set; }
        public string UserAvatar { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }


        public DateTime? DateOfBirth { get; set; }
        public bool Deleted { get; set; }
        public bool Activated { get; set; }
    }
}
