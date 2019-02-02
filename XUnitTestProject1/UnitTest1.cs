using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using VideoRentStore.API;
using Xunit;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        //private readonly HttpClient _client;

        //public UnitTest1()
        //{
        //    var server = new TestServer(new WebHostBuilder()
        //        .UseEnvironment("Development")
        //        .UseStartup<Startup>());
        //    _client = server.CreateClient();
        //}

        //[Theory]
        //[InlineData("GET")]
        //public async Task GetMoviesTestAsync(string method)
        //{
        //    // Arrange
        //    var request = new HttpRequestMessage(new HttpMethod(method), "/api/movies");
        //    // Act
        //    var response = await _client.SendAsync(request);
        //    // Assert
        //    //response.EnsureSuccessStatusCode();
        //    Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        //}

        //[Theory]
        //[InlineData("GET", 1)]
        //public async Task GetMovieTestAsync(string method, int? id = null)
        //{
        //    // Arrange
        //    var request = new HttpRequestMessage(new HttpMethod(method), $"/api/Movies/{id}");
        //    // Act
        //    var response = await _client.SendAsync(request);
        //    // Assert
        //    //response.EnsureSuccessStatusCode();
        //    Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        //}
    }
}
