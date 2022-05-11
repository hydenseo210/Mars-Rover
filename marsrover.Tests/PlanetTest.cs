using Xunit;
using marsrover;
using System;
using System.IO;

namespace marsrover.Tests;

public class PlanetTest
{
    Planet _planet = new Planet(10, 10);
    ICommands _command = new Commands();
    
    [Fact]
    public void Draw_Returns_BoardToConsole()
    {
        TestConsole _testConsole = new TestConsole();
        _planet.draw(_testConsole);
        
        Assert.Equal(_testConsole.Board, "....................................................................................................");
    }
    [Fact]
    public void AddObject_AddsVehicle_InTheCorrectLocation()
    {
        IVehicle _testRover = new Rover('N', new DummyDirections());
        Location _testLocation = new Location(_planet, 2 , 2);
        _planet.AddObject(_testRover, _testLocation);

        var Expected = _planet.IsObjectAt(_testLocation);
        Assert.Equal(Expected, true);

        _planet.RemoveObject(_testRover);
    }
    [Fact]
    public void GetObjectAt_ReturnsVehicle_AtLocation()
    {
        IVehicle _testRover = new Rover('N', new DummyDirections());
        Location _testLocation = new Location(_planet, 2 , 2);
        _planet.AddObject(_testRover, _testLocation);

        var Expected = _planet.GetObjectAt(_testLocation);
        Assert.Equal(Expected, _testRover);

        _planet.RemoveObject(_testRover);
    }

    [Theory]
    [InlineData(0, 0, 'N', 9, 9)]
    [InlineData(9, 9, 'S', 0, 0)]
    public void CheckWrapping_Returns_CorrectLocation_When_VehicleMovesOutOfBounds(int X, int Y, char Direction, int ExpectedX, int ExpectedY)
    {
        IVehicle _testRover = new Rover(Direction, new DummyDirections());
        Location _testLocation = new Location(_planet, X , Y);
        _planet.AddObject(_testRover, _testLocation);

        _planet.MoveVehicleUp(_testRover);
        _planet.MoveVehicleLeft(_testRover);

        Location _vehicleLocation = _planet.at(ExpectedX ,ExpectedY);

        var Expected = _planet.GetObjectAt(_vehicleLocation);
        Assert.Equal(Expected, _testRover);

        _planet.RemoveObject(_testRover);
    }

}

public class DummyDirections : IDirections 
{
    public (char,char)  WhenFacingNorth(char Command)
    {
        switch (Command)
        {
            case 'N':
                return ('f', 'N');
            case 'S':
                return ('b', 'N');
            case 'E':
                return ('r', 'E');
            case 'W':
                return ('l', 'W');
            default:
                throw new Exception();
        }
    }
    public (char,char)  WhenFacingSouth(char Command)
    {
        switch (Command)
        {
            case 'N':
                return ('b', 'S');
            case 'S':
                return ('f', 'S');
            case 'E':
                return ('l', 'E');
            case 'W':
                return ('r', 'W');
            default:
                throw new Exception();
        }
    }
    public (char,char)  WhenFacingEast(char Command)
    {
        return ('l', 'N');
    }
    public (char,char)  WhenFacingWest(char Command)
    {
        return ('r', 'N');
    }
}


public class TestConsole : IConsole
    {
        public string Board = ""; 
        public string Read(){
            return Console.ReadLine();
        }
        public void Write(string output)
        {
            Console.WriteLine(output);
        }

        public void Print(IPrintable printable)
        {
            Board += printable.GetDisplayChar();
        }
        public void EndLine() 
        {
            Console.WriteLine("");
        }
}


