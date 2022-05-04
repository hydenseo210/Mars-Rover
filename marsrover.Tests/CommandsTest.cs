using Xunit;

namespace marsrover.Tests;

public class CommandsTest
{
    [Fact]
    public void ReturnCommands_Returns_ACharacterOfArrays()
    {
        var _commands = new Commands();
        var actual = Commands.ReturnCommands();
        var expected = new []{'f','b','l','r'};

        Assert.Equal(expected, actual);

    }
}