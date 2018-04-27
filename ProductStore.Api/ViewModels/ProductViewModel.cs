using System;

namespace ProductStore.Api.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal OrderPrice
        {
            get
            {
                return Price * Quantity;
            }
        }
    }
}
