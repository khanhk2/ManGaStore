using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManGaStore.Models
{
    public class EFManGaStoreRepository : IManGaStoreRepository
    {
        private ManGaStoreDbContext context;
        public EFManGaStoreRepository(ManGaStoreDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<ManGa> ManGas => context.ManGas;
        public void CreateBook(ManGa b)
        {
            context.Add(b);
            context.SaveChanges();
        }
        public void DeleteBook(ManGa b)
        {
            context.Remove(b);
            context.SaveChanges();
        }
        public void SaveBook(ManGa b)
        {
            context.SaveChanges();
        }
    }
}
