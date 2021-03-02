using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace LibraryApiIntegrationTests
{
    public class ResourceSmokeTests : IClassFixture<CustomWebApplicationFactory>
    {
        private readonly HttpClient _client;
        public ResourceSmokeTests(CustomWebApplicationFactory factory)
        {
            _client = factory.CreateDefaultClient();
        }

        [Theory]
        [InlineData("status")]
        [InlineData("customers/42")]
        [InlineData("blogs/2021/3/01")]
        public async Task ResourcesAreAliveAndKicking(string resource)
        {
            var response = await _client.GetAsync(resource);
            Assert.True(response.IsSuccessStatusCode);
        } 
    }
}
