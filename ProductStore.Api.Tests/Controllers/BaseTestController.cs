using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System.IO;

namespace ProductStore.Api.Tests.Controllers
{
    public class BaseTestController
    {
        private const string ApiUrlBase = "api/products";

        public TestServer CreateServer()
        {
            var webHostBuilder = WebHost.CreateDefaultBuilder();
            webHostBuilder.UseContentRoot(Directory.GetCurrentDirectory());
            webHostBuilder.UseStartup<Startup>();

            return new TestServer(webHostBuilder);
        }

        public static class Get
        {
            public static string AllProducts => $"{ApiUrlBase}";
            public static string ProductBy(int id) => $"{ApiUrlBase}/{id}";
        }

        public static class Post
        {
            public static string NewProduct => $"{ApiUrlBase}";
        }

        public static class Put
        {
            public static string ProductBy(int id) => $"{ApiUrlBase}/{id}";
        }

        public static class Delete
        {
            public static string ProductBy(int id) => $"{ApiUrlBase}/{id}";
        }
    }
}
