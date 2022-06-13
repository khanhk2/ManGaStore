using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManGaStore.Models
{
    public class MyCart
    {
        public List<CartLine> Lines { get; set; } = new List<CartLine>();
        public virtual void AddItem(ManGa manga, int quantity)
    {
        CartLine line = Lines
        .Where(b => b.ManGa.ManGaID == manga.ManGaID)
        .FirstOrDefault();
        if (line == null)
        {
            Lines.Add(new CartLine
            {
                ManGa = manga,
                Quantity = quantity
            });
        }
        else
        {
            line.Quantity += quantity;
        }
    }
        public virtual void RemoveLine(ManGa manga) =>
        Lines.RemoveAll(l => l.ManGa.ManGaID == manga.ManGaID);
         public decimal ComputeTotalValue() =>
        Lines.Sum(e => e.ManGa.Price * e.Quantity);
        public virtual void Clear() => Lines.Clear();
    }

    public class CartLine
    {
        public int CartLineID { get; set; }
        public ManGa ManGa { get; set; }
        public int Quantity { get; set; }
    }
}


