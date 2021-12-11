using MarsRover.Common.Enums;

namespace MarsRover.Common.Models
{
    public class Rover
    {
        public Position Position { get; set; }
        public Plateau Plateau { get; set; }
        public DirectionType DirectionType { get; set; }

        public Rover()
        {

        }

        public Rover(Position position, Plateau plateau, DirectionType roverDirection)
        {
            Position = position;
            Plateau = plateau;
            DirectionType = roverDirection;
        }
    }
}
