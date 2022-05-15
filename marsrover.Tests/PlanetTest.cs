using Xunit;
using marsrover;
using System;
using System.IO;

namespace marsrover.Tests;

public class PlanetTest
{
    Planet _planet = new Planet(10, 10);
    
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
        IVehicle _testRover = new Rover('N', new Directions());
        Location _testLocation = new Location(_planet, 2 , 2);
        _planet.AddObject(_testRover, _testLocation);

        var Expected = _planet.IsObjectAt(_testLocation);
        Assert.Equal(Expected, true);

        _planet.RemoveObject(_testRover);
    }
    [Fact]
    public void GetObjectAt_ReturnsVehicle_AtLocation()
    {
        IVehicle _testRover = new Rover('N', new Directions());
        Location _testLocation = new Location(_planet, 2 , 2);
        _planet.AddObject(_testRover, _testLocation);

        var Expected = _planet.GetObjectAt(_testLocation);
        Assert.Equal(Expected, _testRover);

        _planet.RemoveObject(_testRover);
    }

    [Theory]
    [InlineData(10, 10, 11, 0)]
    [InlineData(20, 10, -1, 19)]
    public void CheckWrapping_ReturnsPotentialXCoordinate(int width, int height, int potentialXCoordinate, int expectedCoordinate)
    {
        // Given
        Planet testPlanet = new Planet(width , height);
        // When
        var actualCoordinate = _planet.CheckWrapping(potentialXCoordinate, width);
        // Then
        Assert.Equal(expectedCoordinate, actualCoordinate);
    }

    [Theory]
    [InlineData(10, 10, 11, 0)]
    [InlineData(10, 20, -1, 19)]
    public void CheckWrapping_ReturnsPotentialYCoordinate(int width, int height, int potentialYCoordinate, int expectedCoordinate)
    {
        // Given
        Planet testPlanet = new Planet(width , height);
        // When
        var actualCoordinate = _planet.CheckWrapping(potentialYCoordinate, height);
        // Then
        Assert.Equal(expectedCoordinate, actualCoordinate);
    }

    [Theory]
    [InlineData(10, 10, 35, 5)]
    [InlineData(20, 10, 10, 10)]
    public void CheckWrapping_MovesVehicle_AroundThePlanet_Vertically(int width, int height, int totalNumberOfMoves, int expectedXCoordinate)
    {
        // Given
        Planet testPlanet = new Planet(width , height);
        IVehicle testRover = new Rover('N', new Directions());
        testPlanet.AddObject(testRover, testPlanet.at(0, 0));
        // When
        for (var i = 0; i < totalNumberOfMoves; i++)
        {
            testPlanet.MoveVehicleUp(testRover);
        }
        var actualXCoordinate = testPlanet.GetLocationOfObject(testRover)._x;
        // Then
        Assert.Equal(expectedXCoordinate, actualXCoordinate);
    }

    [Theory]
    [InlineData(10, 10, 1, 9)]
    public void CheckWrapping_MovesVehicle_AroundThePlanet_Horizontally(int width, int height, int totalNumberOfMoves, int expectedYCoordinate)
    {
        // Given
        Planet testPlanet = new Planet(width , height);
        IVehicle testRover = new Rover('N', new Directions());
        testPlanet.AddObject(testRover, testPlanet.at(0, 0));
        // When
        for (var i = 0; i < totalNumberOfMoves; i++)
        {
            testPlanet.MoveVehicleLeft(testRover);
        }
        var actualYCoordinate = testPlanet.GetLocationOfObject(testRover)._y;
        // Then
        Assert.Equal(expectedYCoordinate, actualYCoordinate);
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


