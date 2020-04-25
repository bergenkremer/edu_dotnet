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
    public class BandGetServiceTests
    {
        [Test]
        public async Task ValidateAsync_BandExists_DoesNothing()
        {
            // Arrange
            var bandContainer = new Mock<IBandContainer>();

            var band = new Band();
            var bandDataAccess = new Mock<IBandDataAccess>();
            bandDataAccess.Setup(x => x.GetByAsync(bandContainer.Object)).ReturnsAsync(band);

            var bandGetService = new BandGetService(bandDataAccess.Object);
            
            // Act
            var action = new Func<Task>(() => bandGetService.ValidateAsync(bandContainer.Object));
            
            // Assert
            await action.Should().NotThrowAsync<Exception>();
        }
        
        [Test]
        public async Task ValidateAsync_BandNotExists_ThrowsError()
        {
            // Arrange
            var fixture = new Fixture();
            var id = fixture.Create<int>();
            
            var bandContainer = new Mock<IBandContainer>();
            bandContainer.Setup(x => x.BandId).Returns(id);

            var band = new Band();
            var bandDataAccess = new Mock<IBandDataAccess>();
            bandDataAccess.Setup(x => x.GetByAsync(bandContainer.Object)).ReturnsAsync((Band)null);

            var bandGetService = new BandGetService(bandDataAccess.Object);
            
            // Act
            var action = new Func<Task>(() => bandGetService.ValidateAsync(bandContainer.Object));
            
            // Assert
            await action.Should().ThrowAsync<InvalidOperationException>($"Band was not found by id {id}");
        }
    }
}