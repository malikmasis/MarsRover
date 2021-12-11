using MarsRover.Common.Enums;
using MarsRover.Common.Models;
using MarsRover.Services.Abstracts;
using Serilog;

namespace MarsRover.Services.Concretes
{
    public sealed class RoverService : IRoverService
    {
        private readonly ILogger _logger;
        public RoverService(ILogger logger)
        {
            _logger = logger;
        }

        private Rover Move(Rover rover)
        {
            if (rover.DirectionType == DirectionType.N && rover.Plateau.Y > rover.Position.Y)
            {
                rover.Position.Y++;
            }
            else if (rover.DirectionType == DirectionType.E && rover.Plateau.X > rover.Position.X)
            {
                rover.Position.X++;
            }
            else if (rover.DirectionType == DirectionType.S && rover.Position.Y > 0)
            {
                rover.Position.Y--;
            }
            else if (rover.DirectionType == DirectionType.W && rover.Position.X > 0)
            {
                rover.Position.X--;
            }
            else
            {
                if (rover.Plateau.Y <= rover.Position.Y)
                {
                    _logger.Information("The rover arrived at the max position for Y");
                }
                else if (rover.Plateau.X <= rover.Position.X)
                {
                    _logger.Information("The rover arrived at the max position for X");
                }
                else if(rover.Position.Y <= 0)
                {
                    _logger.Information("The rover arrived at the min position for Y");
                }
                else
                {
                    _logger.Information("The rover arrived at the min position for X");
                }
            }
            return rover;
        }

        private DirectionType Rotate(DirectionType direction, char directionCode)
        {
            if (directionCode == 'L')
            {
                direction = (direction - 90) < DirectionType.N ? DirectionType.W : direction - 90;
            }
            else if (directionCode == 'R')
            {
                direction = (direction + 90) > DirectionType.W ? DirectionType.N : direction + 90;
            }
            else
            {
                _logger.Warning("The undefined rotation choice");
            }
            return direction;
        }


        public Rover Command(Rover rover, string commands)
        {
            foreach (var command in commands)
            {
                if (command == 'L' || command == 'R')
                {
                    rover.DirectionType = Rotate(rover.DirectionType, command);
                }
                else if (command == 'M')
                {
                    rover = Move(rover);
                }
                else
                {
                    _logger.Warning("The undefined command char");
                }
            }
            return rover;
        }


        public string GetLastPosition(Position position, DirectionType direction)
        {
            string printedLastPosition = $"{position.X} {position.Y} {direction}";
            Console.WriteLine(printedLastPosition);
            return printedLastPosition;
        }
    }
}
