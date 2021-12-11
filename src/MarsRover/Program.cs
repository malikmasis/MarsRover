using MarsRover.Common.Enums;
using MarsRover.Common.Models;
using MarsRover.Services.Abstracts;
using MarsRover.Services.Concretes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

var collection = new ServiceCollection();
collection.AddSingleton<IRoverService, RoverService>();

IServiceProvider _serviceProvider = collection.BuildServiceProvider();
var log = _serviceProvider.GetService<ILogger>();

try
{
    Console.WriteLine("Please enter seperately the plateau weight(X) and height(Y) size:");

    var plateauWidth = Console.ReadLine();
    var plateauHeight = Console.ReadLine();


    int.TryParse(plateauWidth, out int plateauX);
    int.TryParse(plateauHeight, out int plateauY);

    var plateau = new Plateau(plateauX, plateauY);

    while (true)
    {
        Console.WriteLine("Please enter seperately the positions of the rover");

        var positionXInput = Console.ReadLine();
        var positionYInput = Console.ReadLine();

        int.TryParse(positionXInput, out int positionX);
        int.TryParse(positionYInput, out int positionY);

        Console.WriteLine("Please enter poisition of the rover");

        var plateauDirectionInput = Console.ReadLine();
        char.TryParse(plateauDirectionInput, out char plateauDirection);

        var directionType = (DirectionType)Enum.ToObject(typeof(DirectionType), plateauDirection);

        var rover = new Rover()
        {
            Plateau = plateau,
            Position = new Position(positionX, positionY),
            DirectionType = directionType
        };

        Console.WriteLine("Please enter the command list of char");
        var command = Console.ReadLine();

        RoverService firstRover = new RoverService(log);
        rover = firstRover.Command(rover, command);

        Console.WriteLine(Environment.NewLine);
        Console.WriteLine("Output");
        firstRover.GetPosition(rover.Position, rover.DirectionType);

        Console.WriteLine("To continue, please enter Y/y");
        var isContinue = Console.ReadLine();
        if (!isContinue.Equals("Y", StringComparison.InvariantCultureIgnoreCase))
        {
            break;
        }
    }
}
catch (Exception ex)
{
    log.LogError($"Met with the unhandled situation, {ex.Message}");
}
finally
{
    if (_serviceProvider is IDisposable disposable)
    {
        disposable.Dispose();
    }
}
