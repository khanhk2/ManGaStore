using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
namespace ManGaStore.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ManGaStoreDbContext context =
           app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService <ManGaStoreDbContext> ();
            if (context.Database.GetPendingMigrations().Any())
            {
                
                context.Database.Migrate();
            }
            if (!context.ManGas.Any())
            {
                context.ManGas.AddRange(
                new ManGa
                {
                    Title = "One Piece",                    
                    Genre = "Phiêu Lưu",
                    Price = 20m
                },
                new ManGa
                {
                    Title = "One Punch Man",                    
                    Genre = "Hành Động",
                    Price = 12m
                },
                new ManGa
                {
                    Title = "7 Dragon Ball",                    
                    Genre = "Hành động, Phiêu lưu",
                    Price = 5m
                },
                new ManGa
                {
                    Title = "Naruto",                    
                    Genre = "Hành động",
                    Price = 3m
                },
                new ManGa
                {
                    Title = "Sợi xích thần",                    
                    Genre = "Ecchi",
                    Price = 10m
                }
                );
                context.SaveChanges();
            }
        }
    }
}