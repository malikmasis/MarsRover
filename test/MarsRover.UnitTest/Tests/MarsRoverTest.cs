using System.Collections;
using System.Collections.Generic;
using MarsRover.Common.Enums;
using MarsRover.Common.Models;
using MarsRover.Services.Concretes;
using MarsRover.UnitTest.Data;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace MarsRover.UnitTest.Tests
{
    public class MarsRoverTest
    {
        [Theory()]
        [ClassData(typeof(MarsRoverData))]
        public void RoboticRoverTestWithCorrectValues(EnhancedRoboticRover request)
        {
            Rover rover = request;
            var mockedLog = new Mock<ILogger>();
            var firstRover = new RoverService(mockedLog.Object);
            rover = firstRover.Command(rover, request.CommandStr);
            string lastPosition = firstRover.GetPosition(rover.Position, rover.DirectionType);
            Assert.Equal(request.Output, lastPosition);

        }

        public class MarsRoverData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[]
                {
                    new EnhancedRoboticRover( new Position(1,2),new Plateau(5, 5), DirectionType.N,
                        "LMLMLMLMM","1 3 N"
                        )
                };

                yield return new object[]
                {
                    new EnhancedRoboticRover( new Position(3,3),new Plateau(5, 5), DirectionType.E,
                        "MMRMMRMRRM","5 1 E"
                        )
                };
            }
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
}
