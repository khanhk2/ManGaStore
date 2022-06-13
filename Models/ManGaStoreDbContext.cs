using ManGaStore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManGaStore.Models
{
    public class ManGaStoreDbContext : DbContext
    {
        public ManGaStoreDbContext(DbContextOptions<ManGaStoreDbContext>
       options)
        : base(options) { }
        public DbSet<ManGa> ManGas { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
