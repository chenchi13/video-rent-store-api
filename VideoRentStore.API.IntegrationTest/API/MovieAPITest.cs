using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using VideoRentStore.API;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net;
using VideoRentStore.API.Models;
using Newtonsoft.Json;
using FluentAssertions;

namespace VideoRentStore.API.IntegrationTest.API
{
    public class MovieAPITest
    {
        private readonly HttpClient _client;

        public MovieAPITest()
        {
            var server = new TestServer(new WebHostBuilder()
                .UseEnvironment("Development")
                .UseStartup<Startup>());
            _client = server.CreateClient();
        }

        [Theory]
        [InlineData("GET")]
        public async Task GetMoviesTestAsync(string method)
        {
            // Arrange
            var request = new HttpRequestMessage(new HttpMethod(method), "/api/movies");
            // Act
            var response = await _client.SendAsync(request);
            // Assert
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Theory]
        [InlineData("GET", 1)]
        public async Task GetMovieTestAsync(string method, int? id = null)
        {
            // Arrange
            var request = new HttpRequestMessage(new HttpMethod(method), $"/api/Movies/{id}");
            // Act
            var response = await _client.SendAsync(request);
            // Assert
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task PostMovieTestAsync()
        {
            // Arrange
            var stringContent = new StringContent(JsonConvert.SerializeObject(
                new Movie() { Title = "Test Movie 1", Year = 2019, GenreId = 1, DirectorId = 1 }),
                Encoding.UTF8, "application/json");
            // Act
            var response = await _client.PostAsync("/api/Movies", stringContent);
            // Assert
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.Created);
        }

        //[Fact]
        //public async Task PutMovieTestAsync()
        //{
        //    // Arrange
        //    var stringContent = new StringContent(JsonConvert.SerializeObject(
        //        new Movie() { Title = "Test Movie 1", Year = 2019, GenreId = 1, DirectorId = 1 }),
        //        Encoding.UTF8, "application/json");
        //    // Act
        //    var response = await _client.PutAsync("/api/Movies", stringContent);
        //    // Assert
        //    response.EnsureSuccessStatusCode();
        //    response.StatusCode.Should().Be(HttpStatusCode.Created);
        //}
    }
}
