using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManGaStore.Models
{
    public interface IManGaStoreRepository
    {
        IQueryable<ManGa> ManGas { get; }
        void SaveBook(ManGa b);
        void CreateBook(ManGa b);
        void DeleteBook(ManGa b);
    }
}
