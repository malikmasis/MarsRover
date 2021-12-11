using MarsRover.Common.Enums;
using MarsRover.Common.Models;
using MarsRover.Services.Abstracts;
using MarsRover.Services.Concretes;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

var collection = new ServiceCollection();
collection.AddSingleton(Log.Logger);
collection.AddSingleton<IRoverService, RoverService>();

IServiceProvider _serviceProvider = collection.BuildServiceProvider();
var log = _serviceProvider.GetService<ILogger>();

var richedRover = _serviceProvider.GetRequiredService<IRoverService>();

try
{
    Console.WriteLine("Please enter seperately the plateau weight(X) and height(Y) size:");

    var plateauWidth = Console.ReadLine();
    var plateauHeight = Console.ReadLine();

    if (!int.TryParse(plateauWidth, out int plateauX))
    {
        log!.Information($"{nameof(plateauX)} is zero");
    }
    if(!int.TryParse(plateauHeight, out int plateauY))
    {
        log!.Information($"{nameof(plateauY)} is zero");
    }

    Plateau plateau = new(plateauX, plateauY);

    while (true)
    {
        Console.WriteLine("Please enter seperately the positions of the rover");

        var positionXInput = Console.ReadLine();
        var positionYInput = Console.ReadLine();

        if (!int.TryParse(positionXInput, out int positionX))
        {
            log!.Information($"{nameof(positionX)} is zero");
        }
        if (!int.TryParse(positionYInput, out int positionY))
        {
            log!.Information($"{nameof(positionY)} is zero");
        }


        Console.WriteLine("Please enter poisition of the rover");

        var plateauDirectionInput = Console.ReadLine();

        if(!char.TryParse(plateauDirectionInput, out char plateauDirection))
        {
            plateauDirection = 'N';
        }

        DirectionType directionType = (DirectionType)Enum.ToObject(typeof(DirectionType), plateauDirection);

        Rover rover = new(new(positionX, positionY), plateau, directionType);

        Console.WriteLine("Please enter the command list of char");
        var command = Console.ReadLine();

        rover = richedRover.Command(rover, command!);

        Console.WriteLine(Environment.NewLine);
        Console.WriteLine("Output");
        richedRover.GetLastPosition(rover.Position, rover.DirectionType);

        Console.WriteLine("To continue, please enter Y/y");
        var isContinue = Console.ReadLine();
        if (!isContinue!.Equals("Y", StringComparison.InvariantCultureIgnoreCase))
        {
            break;
        }
    }
}
catch (Exception ex)
{
    log!.Error($"Met with the unhandled situation, {ex.Message}");
}
finally
{
    if (_serviceProvider is IDisposable disposable)
    {
        disposable.Dispose();
    }
}
