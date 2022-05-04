using System.Linq;
using Xunit;
using marsrover;

namespace marsrover.Tests;

public class DeployRoverTest
{
    [Fact]
    public void GetStartingPoint_Returns_XYCoordinateAsCoordinateType()
    {
        var _deployRover = new DeployRover();
        var actual = _deployRover.GetStartingPoint();
        var expected = new int[]{1,2};

        Assert.Equal(expected, actual);

    }
    [Fact]
    public void GetStartingDirection_Returns_OneOf_NSEW_AtRandom()
    {
        var directionGenerated = Enumerable.Range(0,1000).Select(x => _deployRover.GetStartingDirection).Distinct().ToArray();
        Assert.Contains('N', directionGenerated);
        Assert.Contains('S', directionGenerated);
        Assert.Contains('W', directionGenerated);
        Assert.Contains('E', directionGenerated);
        Assert.Equal(directionGenerated.Distinct().Count(), 4);

    }
}
