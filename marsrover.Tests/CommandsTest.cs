using Xunit;
using marsrover;

namespace marsrover.Tests;

public class CommandsTest
{
    [Fact]
    public void ReturnCommands_Returns_ACharacterOfArrays()
    {
        var _commands = new Commands();
        var actual = _commands.ReturnCommands();
        var expected = new []{'N','N','S','E','W','W'};

        Assert.Equal(expected, actual);
        // consider mock or stub as input
    }
}