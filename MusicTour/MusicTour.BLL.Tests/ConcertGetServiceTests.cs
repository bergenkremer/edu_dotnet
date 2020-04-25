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
    public class ConcertGetServiceTests
    {
        [Test]
        public async Task ValidateAsync_ConcertExists_DoesNothing()
        {
            // Arrange
            var concertContainer = new Mock<IConcertContainer>();

            var concert = new Concert();
            var concertDataAccess = new Mock<IConcertDataAccess>();
            concertDataAccess.Setup(x => x.GetByAsync(concertContainer.Object)).ReturnsAsync(concert);

            var concertGetService = new ConcertGetService(concertDataAccess.Object);
            
            // Act
            var action = new Func<Task>(() => concertGetService.ValidateAsync(concertContainer.Object));
            
            // Assert
            await action.Should().NotThrowAsync<Exception>();
        }
        
        [Test]
        public async Task ValidateAsync_ConcertNotExists_ThrowsError()
        {
            // Arrange
            var fixture = new Fixture();
            var id = fixture.Create<int>();
            
            var concertContainer = new Mock<IConcertContainer>();
            concertContainer.Setup(x => x.ConcertId).Returns(id);

            var concert = new Concert();
            var concertDataAccess = new Mock<IConcertDataAccess>();
            concertDataAccess.Setup(x => x.GetByAsync(concertContainer.Object)).ReturnsAsync((Concert)null);

            var concertGetService = new ConcertGetService(concertDataAccess.Object);
            
            // Act
            var action = new Func<Task>(() => concertGetService.ValidateAsync(concertContainer.Object));
            
            // Assert
            await action.Should().ThrowAsync<InvalidOperationException>($"Concert not found by id {id}");
        }
    }
}