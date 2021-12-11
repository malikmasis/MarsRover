using MarsRover.Common.Models;
using MarsRover.Services.Concretes;
using MarsRover.UnitTest.Data;
using Moq;
using Serilog;
using Xunit;

namespace MarsRover.UnitTest.Tests
{
    public class MarsRoverTest
    {
        [Theory()]
        [ClassData(typeof(MarsRoverData))]
        public void RoboticRoverTestWithCorrectValues(EnhancedRoboticRover request)
        {
            var mockedLog = new Mock<ILogger>();
            var reachedRover = new RoverService(mockedLog.Object);

            Rover rover = request;
            rover = reachedRover.Command(rover, request.CommandStr);
            string lastPosition = reachedRover.GetLastPosition(rover.Position, rover.DirectionType);

            Assert.Equal(request.Output, lastPosition);
        }
        
    }
}
