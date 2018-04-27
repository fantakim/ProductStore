using Newtonsoft.Json;
using ProductStore.Api.Models;
using ProductStore.Api.ViewModels;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ProductStore.Api.Tests.Controllers
{
    public class ProductControllerTests : BaseTestController
    {
        [Fact]
        public async Task Create_product_and_response_ok_status_code()
        {
            using (var server = CreateServer())
            {
                var content = new StringContent(BuildProduct(), Encoding.UTF8, "application/json");
                var response = await server.CreateClient()
                   .PostAsync(Post.NewProduct, content);

                var responseBody = await response.Content.ReadAsStringAsync();
                var product = JsonConvert.DeserializeObject<Product>(responseBody);

                Assert.NotNull(product);
                Assert.Equal("test-product", product.Name);
            }
        }

        [Fact]
        public async Task Get_product_by_id_and_response_ok_status_code()
        {
            using (var server = CreateServer())
            {
                var response = await server.CreateClient()
                    .GetAsync(Get.AllProducts);

                var responseBody = await response.Content.ReadAsStringAsync();
                var productList = JsonConvert.DeserializeObject<ProductListViewModel>(responseBody);

                Assert.NotNull(productList);
            }
        }

        string BuildProduct()
        {
            var model = new CreateProductModel
            {
                Name = "test-product",
                Price = 5000,
                Quantity = 5
            };

            return JsonConvert.SerializeObject(model);
        }
    }
}
