namespace Vizor.ECharts.Tests.Unit.Serialization;

[TestClass]
public class JavascriptFunctionSerializationTests
{
    private static JsonSerializerOptions CreateOptions() => new TestFixtures.TestChart().GetSerializerOptions();

    [TestMethod]
    public void WritesRawFunctionBody()
    {
        var options = new ChartOptions
        {
            Tooltip = new()
            {
                Formatter = new JavascriptFunction("function (params) { return params[0].value; }")
            }
        };

        string json = JsonSerializer.Serialize(options, CreateOptions());

        Assert.IsTrue(json.Contains("function (params)"));
        Assert.IsFalse(json.Contains("\\\\"), "Function should not be double-escaped");
    }
}
