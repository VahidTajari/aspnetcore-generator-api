using System.ComponentModel.DataAnnotations;
using Range = api.Controllers.Range;

namespace tests;

public class RangeTest
{
    [Fact]
    public void CountShouldControlNumberOfResults()
    {
        var range = new Range() { Count = 3 };
        var generated = range.Of(() => "");
        Assert.Equal(3, generated.Count());
    }
}