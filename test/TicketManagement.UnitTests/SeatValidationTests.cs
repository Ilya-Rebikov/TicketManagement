﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using TicketManagement.BusinessLogic.Interfaces;
using TicketManagement.BusinessLogic.ModelsDTO;
using TicketManagement.BusinessLogic.Services;
using TicketManagement.DataAccess.Interfaces;
using TicketManagement.DataAccess.Models;

namespace TicketManagement.UnitTests
{
    [TestFixture]
    internal class SeatValidationTests
    {
        private IService<SeatDto> _service;

        [SetUp]
        public async Task SetupAsync()
        {
            var seatRepositoryMock = new Mock<IRepository<Seat>>();
            var seatConverterMock = new Mock<IConverter<Seat, SeatDto>>();
            seatRepositoryMock.Setup(rep => rep.GetAllAsync()).ReturnsAsync(GetTestSeats());
            var seats = await seatRepositoryMock.Object.GetAllAsync();
            seatConverterMock.Setup(rep => rep.ConvertModelsRangeToDtos(seats)).ReturnsAsync(GetTestSeatDtos());
            _service = new SeatService(seatRepositoryMock.Object, seatConverterMock.Object);
        }

        private static IEnumerable<SeatDto> GetTestSeatDtos()
        {
            IEnumerable<SeatDto> seats = new List<SeatDto>
            {
                new SeatDto { Id = 1, AreaId = 1, Row = 1, Number = 1 },
                new SeatDto { Id = 2, AreaId = 1, Row = 1, Number = 2 },
                new SeatDto { Id = 3, AreaId = 1, Row = 1, Number = 3 },
                new SeatDto { Id = 4, AreaId = 1, Row = 2, Number = 1 },
                new SeatDto { Id = 5, AreaId = 1, Row = 2, Number = 2 },
                new SeatDto { Id = 6, AreaId = 1, Row = 2, Number = 3 },
                new SeatDto { Id = 7, AreaId = 2, Row = 1, Number = 1 },
                new SeatDto { Id = 8, AreaId = 2, Row = 1, Number = 2 },
                new SeatDto { Id = 9, AreaId = 2, Row = 1, Number = 3 },
                new SeatDto { Id = 10, AreaId = 2, Row = 2, Number = 1 },
                new SeatDto { Id = 11, AreaId = 2, Row = 2, Number = 2 },
                new SeatDto { Id = 12, AreaId = 2, Row = 2, Number = 3 },
                new SeatDto { Id = 13, AreaId = 3, Row = 1, Number = 1 },
                new SeatDto { Id = 14, AreaId = 3, Row = 1, Number = 2 },
                new SeatDto { Id = 15, AreaId = 3, Row = 1, Number = 3 },
                new SeatDto { Id = 16, AreaId = 3, Row = 2, Number = 1 },
                new SeatDto { Id = 17, AreaId = 3, Row = 2, Number = 2 },
                new SeatDto { Id = 18, AreaId = 3, Row = 2, Number = 3 },
            };
            return seats;
        }

        private static IQueryable<Seat> GetTestSeats()
        {
            IEnumerable<Seat> seats = new List<Seat>
            {
                new Seat { Id = 1, AreaId = 1, Row = 1, Number = 1 },
                new Seat { Id = 2, AreaId = 1, Row = 1, Number = 2 },
                new Seat { Id = 3, AreaId = 1, Row = 1, Number = 3 },
                new Seat { Id = 4, AreaId = 1, Row = 2, Number = 1 },
                new Seat { Id = 5, AreaId = 1, Row = 2, Number = 2 },
                new Seat { Id = 6, AreaId = 1, Row = 2, Number = 3 },
                new Seat { Id = 7, AreaId = 2, Row = 1, Number = 1 },
                new Seat { Id = 8, AreaId = 2, Row = 1, Number = 2 },
                new Seat { Id = 9, AreaId = 2, Row = 1, Number = 3 },
                new Seat { Id = 10, AreaId = 2, Row = 2, Number = 1 },
                new Seat { Id = 11, AreaId = 2, Row = 2, Number = 2 },
                new Seat { Id = 12, AreaId = 2, Row = 2, Number = 3 },
                new Seat { Id = 13, AreaId = 3, Row = 1, Number = 1 },
                new Seat { Id = 14, AreaId = 3, Row = 1, Number = 2 },
                new Seat { Id = 15, AreaId = 3, Row = 1, Number = 3 },
                new Seat { Id = 16, AreaId = 3, Row = 2, Number = 1 },
                new Seat { Id = 17, AreaId = 3, Row = 2, Number = 2 },
                new Seat { Id = 18, AreaId = 3, Row = 2, Number = 3 },
            };
            return seats.AsQueryable();
        }

        [Test]
        public void CreateSeat_WhenRowAndNumberArentUnique_ShouldReturnArgumentException()
        {
            // Arrange
            SeatDto seat = new ()
            {
                AreaId = 1,
                Row = 1,
                Number = 1,
            };

            // Act
            AsyncTestDelegate testAction = async () => await _service.CreateAsync(seat);

            // Assert
            Assert.ThrowsAsync<ArgumentException>(testAction);
        }

        [Test]
        public void UpdateSeat_WhenRowAndNumberArentUnique_ShouldReturnArgumentException()
        {
            // Arrange
            SeatDto seat = new ()
            {
                Id = 1,
                AreaId = 1,
                Row = 1,
                Number = 2,
            };

            // Act
            AsyncTestDelegate testAction = async () => await _service.UpdateAsync(seat);

            // Assert
            Assert.ThrowsAsync<ArgumentException>(testAction);
        }

        [Test]
        public void CreateSeat_WhenRowAndNumberArentPositive_ShouldReturnArgumentException()
        {
            // Arrange
            SeatDto seat = new ()
            {
                AreaId = 1,
                Row = 0,
                Number = -1,
            };

            // Act
            AsyncTestDelegate testAction = async () => await _service.CreateAsync(seat);

            // Assert
            Assert.ThrowsAsync<ArgumentException>(testAction);
        }

        [Test]
        public void UpdateSeat_WhenRowAndNumberArentPositive_ShouldReturnArgumentException()
        {
            // Arrange
            SeatDto seat = new ()
            {
                Id = 1,
                AreaId = 1,
                Row = 0,
                Number = -1,
            };

            // Act
            AsyncTestDelegate testAction = async () => await _service.UpdateAsync(seat);

            // Assert
            Assert.ThrowsAsync<ArgumentException>(testAction);
        }
    }
}
