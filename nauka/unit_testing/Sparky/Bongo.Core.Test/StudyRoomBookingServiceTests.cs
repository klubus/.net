﻿using Bongo.Core.Services;
using Bongo.DataAccess.Repository.IRepository;
using Moq;
using NUnit.Framework;

namespace Bongo.Core
{
    [TestFixture]
    public class StudyRoomBookingServiceTests
    {
        private Mock<IStudyRoomBookingRepository> _studyRoomBookingRepoMock;
        private Mock<IStudyRoomRepository> _studyRoomRepoMock;
        private StudyRoomBookingService _bookingService;

        [SetUp]
        public void Setup()
        {
            _studyRoomBookingRepoMock = new Mock<IStudyRoomBookingRepository>();
            _studyRoomRepoMock = new Mock<IStudyRoomRepository>();
            _bookingService = new StudyRoomBookingService(
                _studyRoomBookingRepoMock.Object,
                _studyRoomRepoMock.Object);
        }

        [TestCase]
        public void GetAllBooking_InvokeMethod_CheckIfRepoIsCalled()
        {
            _bookingService.GetAllBooking();
            _studyRoomBookingRepoMock.Verify(x => x.GetAll(null), Times.Once());
        }

        [TestCase]
        public void BookingException_NullRequest_ThrowException()
        {
            var exception = Assert.Throws<ArgumentNullException>(() => _bookingService.BookStudyRoom(null));
            Assert.AreEqual("Value cannot be null. (Parameter 'request')", exception.Message);
            Assert.AreEqual("request", exception.ParamName);
        }
    }
}
