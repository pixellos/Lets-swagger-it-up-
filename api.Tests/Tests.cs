using System.Net;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json.Linq;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Model;
using HttpStatusCode = Org.OpenAPITools.Model.HttpStatusCode;

namespace openapi_clients.Tests
{
    public class Tests
    {
        private WebApplicationFactory<Program> app;

        public Tests() => app = new WebApplicationFactory<Program>();

        [Test]
        public async Task Test1()
        {
            using var client = app.CreateDefaultClient();
            var response = await client.GetAsync("/weatherForecast");
            var info = await response.Content.ReadAsStringAsync();
            var result = await response.Content.ReadFromJsonAsync<object>();
        }

        [Test]
        public async Task TheUsualTest()
        {
            using var client = app.CreateDefaultClient();
            var response = await client.PostAsJsonAsync(
                "/weatherForecast/inheritance",
                new
                {
                    discriminator = "Dog",
                    bark = "Some bark!"
                });

            var result = await response.Content.ReadAsStringAsync();
        }


        [Test]
        public async Task Test1Client()
        {
            using var client = app.CreateDefaultClient();
            var response = await client.GetAsync("/weatherForecast");
            var info = await response.Content.ReadAsStringAsync();
            var result = await response.Content.ReadFromJsonAsync<object>();
        }

        [Test]
        public async Task TestInheritanceClient()
        {
            using var client = app.CreateDefaultClient();

            var result = await new InheritanceApi(client).MyCustomOpIdAsync(
                new MyCustomOpIdRequest(new Org.OpenAPITools.Model.Dog("Bark, bark!")));

            Assert.AreEqual(result.StatusCode, HttpStatusCode.NUMBER_200);
            Assert.IsInstanceOf<Dog>(result.Value.ActualInstance);
        }
    }
}