using Microsoft.EntityFrameworkCore;
using Ndc.Library.Models;

namespace Ndc.Web.Api.Models
{
    public class NdcContext:DbContext
    {
        public NdcContext(DbContextOptions<NdcContext> options) : base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
    }
}
