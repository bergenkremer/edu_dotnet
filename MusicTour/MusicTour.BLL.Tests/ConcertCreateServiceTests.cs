using System;
using System.Threading.Tasks;
using MusicTour.BLL.Contracts;
using MusicTour.BLL.Implementation;
using MusicTour.DataAccess.Contracts;
using MusicTour.Domain;
using MusicTour.Domain.Models;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using AutoFixture;

namespace MusicTour.BLL.Tests
{
    public class ConcertCreateServiceTests
    {
        [Test]
        public async Task CreateAsync_ConcertValidationSucceed_CreatesConcert()
        {
            // Arrange
            var concert = new ConcertUpdateModel();
            var expected = new Concert();
            
            var cityGetService = new Mock<ICityGetService>();
            cityGetService.Setup(x => x.ValidateAsync(concert));

            var bandGetService = new Mock<IBandGetService>();
            bandGetService.Setup(x => x.ValidateAsync(concert));

            var concertDataAccess = new Mock<IConcertDataAccess>();
            concertDataAccess.Setup(x => x.InsertAsync(concert)).ReturnsAsync(expected);
            
            var concertGetService = new ConcertCreateService(concertDataAccess.Object, cityGetService.Object, bandGetService.Object);
            
            // Act
            var result = await concertGetService.CreateAsync(concert);
            
            // Assert
            result.Should().Be(expected);
        }
        
        [Test]
        public async Task CreateAsync_CityValidationFailed_ThrowsError()
        {
            // Arrange
            var fixture = new Fixture();
            var concert = new ConcertUpdateModel();
            var expected = fixture.Create<string>();
            
            var cityGetService = new Mock<ICityGetService>();
            cityGetService
                .Setup(x => x.ValidateAsync(concert))
                .Throws(new InvalidOperationException(expected));

            var bandGetService = new Mock<IBandGetService>();
            bandGetService.Setup(x => x.ValidateAsync(concert)).Throws(new InvalidOperationException(expected));

            
            var concertDataAccess = new Mock<IConcertDataAccess>();

            var concertGetService = new ConcertCreateService(concertDataAccess.Object, cityGetService.Object, bandGetService.Object);
            
            // Act
            var action = new Func<Task>(() => concertGetService.CreateAsync(concert));
            
            // Assert
            await action.Should().ThrowAsync<InvalidOperationException>().WithMessage(expected);
            concertDataAccess.Verify(x => x.InsertAsync(concert), Times.Never);
        }
    }
}