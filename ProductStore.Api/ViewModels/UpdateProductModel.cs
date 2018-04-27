using System.ComponentModel.DataAnnotations;

namespace ProductStore.Api.ViewModels
{
    public class UpdateProductModel
    {
        [Required]
        public string Name { get; set; }

        public decimal Price { get; set; }

        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }
    }
}
