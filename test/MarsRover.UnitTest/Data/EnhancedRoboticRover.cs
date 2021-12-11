using MarsRover.Common.Enums;
using MarsRover.Common.Models;

namespace MarsRover.UnitTest.Data
{
    public sealed class EnhancedRoboticRover : Rover
    {
        public string CommandStr { get; set; }
        public string Output { get; set; }

        public EnhancedRoboticRover(Position position, Plateau plateau, DirectionType direction,
                                    string commandStr, string output)
            : base(position, plateau, direction)
        {
            CommandStr = commandStr;
            Output = output;
        }
    }
}
