using System.Collections.Generic;
using System.Linq;

namespace ProductStore.Api.ViewModels
{
    public class ProductListViewModel
    {
        public IEnumerable<ProductViewModel> Products { get; }
        public decimal TotalPrice
        {
            get
            {
                return Products.Sum(p => p.OrderPrice);
            }
        }

        /// <summary>
        /// ctor
        /// </summary>
        public ProductListViewModel(IEnumerable<ProductViewModel> products)
        {
            this.Products = products;
        }
    }
}
