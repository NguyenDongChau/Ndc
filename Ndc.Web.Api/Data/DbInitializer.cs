using System;
using System.Linq;
using Ndc.Models.Account;
using Ndc.Web.Api.Models;
using Ndc.Library.EncryptDecrypt;

namespace Ndc.Web.Api.Data
{
    public static class DbInitializer
    {
        public static void Initialize(NdcContext context)
        {
            context.Database.EnsureCreated();

            if (context.Users.Any())
            {
                return;   // DB has been seeded
            }

            var users = new User[]
            {
                new User {UserId = Guid.NewGuid(), UserName = "chaund", Password = Md5Encryption.EncryptMd5("123456"), Email = "chau.nguyendong@ndc.net.vn", FirstName = "Châu", LastName = "Nguyễn"}, 
            };

            foreach (var user in users)
            {
                context.Users.Add(user);
            }
            context.SaveChanges();
        }
    }
}
