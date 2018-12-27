using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EAP.Models
{
    public class EAPContext : DbContext
    {
        public EAPContext (DbContextOptions<EAPContext> options)
            : base(options)
        {
        }

        public DbSet<EAP.Models.EmployeeClass> EmployeeClass { get; set; }
    }
}
