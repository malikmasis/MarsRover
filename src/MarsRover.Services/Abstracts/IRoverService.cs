using MarsRover.Common.Enums;
using MarsRover.Common.Models;

namespace MarsRover.Services.Abstracts
{
    public interface IRoverService
    {
        Rover Command(Rover rover, string commands);
        string GetPosition(Position position, DirectionType direction);
    }
}
