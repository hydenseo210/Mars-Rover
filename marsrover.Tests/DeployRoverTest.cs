using System;
using System.Linq;
using Xunit;
using marsrover;

namespace marsrover.Tests;

public class DeployRoverTest
{
    DeployRover _deployRover = new DeployRover();
    
    [Fact]
    public void GetStartingPoint_Returns_XYCoordinateAsCoordinateType()
    {
        
        var actual = _deployRover.GetStartingPoint();
        var expected = new int[]{1,2};

        Assert.Equal(expected, actual);

    }
    [Fact]
    public void GetStartingDirection_Returns_OneOf_NSEW_AtRandom()
    {
        var directionGenerated = new char[1000];
        for (var i = 0; i < 1000; i++)
        {
            directionGenerated[i] = _deployRover.GetStartingDirection();
        }
        Assert.Contains('N', directionGenerated);
        Assert.Contains('S', directionGenerated);
        Assert.Contains('W', directionGenerated);
        Assert.Contains('E', directionGenerated);
        Assert.Equal(directionGenerated.Distinct().Count(), 4);

    }
}
