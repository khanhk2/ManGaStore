using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManGaStore.Models.ViewModels
{
    public class ManGaListViewModel
    {
        public IEnumerable<ManGa> ManGas { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentGenre { get; set; }
    }
}
