using MarsRover.Common.Enums;
using MarsRover.Common.Models;
using MarsRover.Services.Abstracts;
using ILogger = Serilog.ILogger;

namespace MarsRover.Services.Concretes
{
    public class RoverService : IRoverService
    {
        private readonly ILogger _logger;
        public RoverService(ILogger logger)
        {
            _logger = logger;
        }
        public Rover Command(Rover rover, string commands)
        {
            throw new NotImplementedException();
        }

        public string GetPosition(Position position, DirectionType direction)
        {
            throw new NotImplementedException();
        }
    }
}
