using System.Collections;
using System.Collections.Generic;
using MarsRover.Common.Enums;
using MarsRover.Common.Models;

namespace MarsRover.UnitTest.Data
{
    internal sealed class MarsRoverData : IEnumerable<object[]>
    {
        private readonly Plateau plateau = new(5, 5);
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                    new EnhancedRoboticRover(new Position(1,2), plateau, DirectionType.N,
                        "LMLMLMLMM","1 3 N"
                        )
            };

            yield return new object[]
            {
                    new EnhancedRoboticRover(new Position(1,2), plateau, DirectionType.N,
                        string.Empty,"1 2 N"
                        )
            };

            yield return new object[]
            {
                    new EnhancedRoboticRover(new Position(3,3), plateau, DirectionType.E,
                        "MMRMMRMRRM","5 1 E"
                        )
            };

            yield return new object[]
            {
                    new EnhancedRoboticRover(new Position(3,3), plateau, DirectionType.E,
                        "MMRMMRMRRMMMMMMMM","5 1 E"
                        )
            };

        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
