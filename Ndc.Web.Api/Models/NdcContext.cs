using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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
