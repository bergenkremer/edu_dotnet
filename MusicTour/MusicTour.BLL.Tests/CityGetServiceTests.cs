using System;
using System.Threading.Tasks;
using AutoFixture;
using MusicTour.BLL.Implementation;
using MusicTour.DataAccess.Contracts;
using MusicTour.Domain;
using MusicTour.Domain.Contracts;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using AutoFixture;

namespace MusicTour.BLL.Tests
{
    public class CityGetServiceTests
    {
        [Test]
        public async Task ValidateAsync_CityExists_DoesNothing()
        {
            // Arrange
            var cityContainer = new Mock<ICityContainer>();

            var city = new City();
            var cityDataAccess = new Mock<ICityDataAccess>();
            cityDataAccess.Setup(x => x.GetByAsync(cityContainer.Object)).ReturnsAsync(city);

            var cityGetService = new CityGetService(cityDataAccess.Object);
            
            // Act
            var action = new Func<Task>(() => cityGetService.ValidateAsync(cityContainer.Object));
            
            // Assert
            await action.Should().NotThrowAsync<Exception>();
        }
        
        [Test]
        public async Task ValidateAsync_CityNotExists_ThrowsError()
        {
            // Arrange
            var fixture = new Fixture();
            var id = fixture.Create<int>();
            
            var cityContainer = new Mock<ICityContainer>();
            cityContainer.Setup(x => x.CityId).Returns(id);

            var city = new City();
            var cityDataAccess = new Mock<ICityDataAccess>();
            cityDataAccess.Setup(x => x.GetByAsync(cityContainer.Object)).ReturnsAsync((City)null);

            var cityGetService = new CityGetService(cityDataAccess.Object);
            
            // Act
            var action = new Func<Task>(() => cityGetService.ValidateAsync(cityContainer.Object));
            
            // Assert
            await action.Should().ThrowAsync<InvalidOperationException>($"City was not found by id {id}");
        }
    }
}