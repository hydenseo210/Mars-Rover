using Xunit;

namespace marsrover.Tests;

public class RoverTest
{
    private IVehicle _testVehicle = new Rover('N', new Directions());
    [Theory]
    [InlineData('N','⍐')]
    [InlineData('S','⍗')]
    [InlineData('E','⍈')]
    [InlineData('W','⍇')]
    public void RoverReturns_EmojiCharacter_FacingCorrectDirection(char Direction, char Expected)
    {
        //Assert
        _testVehicle.ChangeDirection(Direction);
        //Act
        var Actual = _testVehicle.GetDisplayChar();
        //Assert
        Assert.Equal(Expected, Actual);
    }

    [Theory]
    [InlineData('N', 'N','f')]
    [InlineData('N', 'S','b')]
    [InlineData('N', 'E','r')]
    [InlineData('N', 'W','l')]

    [InlineData('S', 'N','b')]
    [InlineData('S', 'S','f')]
    [InlineData('S', 'E','l')]
    [InlineData('S', 'W','r')]

    [InlineData('E', 'N','l')]
    [InlineData('E', 'S','r')]
    [InlineData('E', 'E','f')]
    [InlineData('E', 'W','b')]

    [InlineData('W', 'N','r')]
    [InlineData('W', 'S','l')]
    [InlineData('W', 'E','b')]
    [InlineData('W', 'W','f')]
    public void RoverReturns_CorrectAction_WhenGivenCommand(char CurrentDirectionRoverIsFacing, char Command, char Expected)
    {
        //Arrange
        _testVehicle.ChangeDirection(CurrentDirectionRoverIsFacing);
        //Act
        var Actual = _testVehicle.Action(Command);
        //Assert
        Assert.Equal(Expected, Actual);
    } // change to multiple tests different rover facing directions
}
