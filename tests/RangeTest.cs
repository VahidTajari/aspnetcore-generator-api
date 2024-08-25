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

    [Fact]
    public void SortShouldOrderResults()
    {
        var range = new Range() { Count = 3, Sort = true };
        var values = new[] { "a", "b", "c" };
        var counter = 0;
        var generated = range.Of(() => values[counter++]).ToArray();
        Assert.Equal(new[] { "a", "b", "c" }, generated);
    }
}