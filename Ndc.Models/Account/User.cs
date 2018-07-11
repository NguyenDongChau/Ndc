using System;
using System.ComponentModel.DataAnnotations;

namespace Ndc.Models.Account
{
    public class User
    {
        [Key]
        public Guid UserId { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        public string FirstName { get; set; }
        
        public string MiddleName { get; set; }

        [Required]
        public string LastName { get; set; }
        public string UserAvatar { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public bool Deleted { get; set; }
        public bool Activated { get; set; }
        public string UserToken { get; set; }
    }
}
