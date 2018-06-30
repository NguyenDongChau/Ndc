using System;

namespace Ndc.Library.Models
{
    public class User
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string UserAvatar { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool Deleted { get; set; }
        public bool Activated { get; set; }
    }
}
