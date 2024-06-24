using Instruments.Domain.Entities;

namespace Instruments.Domain.Models
{
    public class CartItem
    {
        public Instrument Item { get; set; }
        public int Qty { get; set; }
    }
}
