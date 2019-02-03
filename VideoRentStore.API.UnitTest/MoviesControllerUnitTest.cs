using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using VideoRentStore.API.Models;
using Xunit;
using Microsoft.EntityFrameworkCore;
using VideoRentStore.API.Controllers;

namespace VideoRentStore.API.UnitTest
{
    public class MoviesControllerUnitTest
    {
        [Fact]
        public void GetMovies_Test()
        {
            var data = new List<Movie> {
                new Movie{ Title = "My Test Movie 11", Year = 2019, DirectorId = 1, GenreId = 1 },
                new Movie{ Title = "My Test Movie 22", Year = 2019, DirectorId = 1, GenreId = 1 },
                new Movie{ Title = "My Test Movie 33", Year = 2019, DirectorId = 1, GenreId = 1 }
            }.AsQueryable();

            //Define the mock type as DbSet<Movie>
            var mockSet = new Mock<DbSet<Movie>>();
            //Define the mock Repository as databaseEf
            var mockContext = new Mock<VideoRentStoreDBContext>();

            //Bind all data  attributes to your mockSet
            mockSet.As<IQueryable<Movie>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Movie>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Movie>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Movie>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            //Setting up the mockSet to mockContext
            mockContext.Setup(c => c.Movies).Returns(mockSet.Object);

            //Init the WebAPI service
            var service = new MoviesController(mockContext.Object);
            //Check the equality between the returned data and the expected data
            Assert.Equal("My Test Movie 11", service.GetMovies().First().Title);
        }
    }
}
