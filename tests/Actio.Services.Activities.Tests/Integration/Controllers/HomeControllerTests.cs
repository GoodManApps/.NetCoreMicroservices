using FluentAssertions;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Actio.Services.Activities.Tests.Integration.Controllers
{
    public class HomeControllerTests
    {
        private readonly TestServer _server;
        private readonly HttpClient _httpClient;

        public HomeControllerTests()
        {
            _server = new TestServer(WebHost
                .CreateDefaultBuilder()
                .UseStartup<Startup>());

            _httpClient = _server.CreateClient();
        }

        [Fact]
        public async Task Home_get_should_string_content()
        {
            var response = await _httpClient.GetAsync("/");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            content.Should().BeEquivalentTo("Hello from Actio.Services.Activities!");
        }
    }
}
