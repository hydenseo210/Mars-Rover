using System;
using System.Linq;
using Xunit;
using marsrover;

namespace marsrover.Tests;

public class DeployObjectTest
{
    DeployObject _deployObject = new DeployObject();
    
    [Fact]
    public void GetStartingPoint_Returns_XYCoordinateAsCoordinateType()
    {
        var XCoordinatesGenerated = new int[1000];
        var YCoordinatesGenerated = new int[1000];
        for (var i = 0; i < 1000; i++)
        {
            XCoordinatesGenerated[i] = _deployObject.GetRandomPoint(3 , 3)[0];
            YCoordinatesGenerated[i] = _deployObject.GetRandomPoint(3 , 3)[0];
        }
        Assert.Contains(0, XCoordinatesGenerated);
        Assert.Contains(1, XCoordinatesGenerated);
        Assert.Contains(2, XCoordinatesGenerated);
        Assert.Contains(0, YCoordinatesGenerated);
        Assert.Contains(1, YCoordinatesGenerated);
        Assert.Contains(2, YCoordinatesGenerated);
        Assert.Equal(XCoordinatesGenerated.Distinct().Count(), 3);
        Assert.Equal(YCoordinatesGenerated.Distinct().Count(), 3);

    }
    [Fact]
    public void GetStartingDirection_Returns_OneOf_NSEW_AtRandom()
    {
        var directionGenerated = new char[1000];
        for (var i = 0; i < 1000; i++)
        {
            directionGenerated[i] = _deployObject.GetStartingDirection();
        }
        Assert.Contains('N', directionGenerated);
        Assert.Contains('S', directionGenerated);
        Assert.Contains('W', directionGenerated);
        Assert.Contains('E', directionGenerated);
        Assert.Equal(directionGenerated.Distinct().Count(), 4);

    }
}
