using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AsianFlix.Models;

namespace AsianFlix.Data
{
    public class AsianFlixContext : DbContext
    {
        public AsianFlixContext (DbContextOptions<AsianFlixContext> options)
            : base(options)
        {
        }

        public DbSet<AsianFlix.Models.Cliente> Cliente { get; set; } = default!;
        public DbSet<AsianFlix.Models.Pagamento> Pagamento { get; set; } = default!;
    }
}
