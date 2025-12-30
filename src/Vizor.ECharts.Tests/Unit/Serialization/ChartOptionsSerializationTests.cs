using Vizor.ECharts.Tests.TestFixtures;

namespace Vizor.ECharts.Tests.Unit.Serialization;

[TestClass]
public class ChartOptionsSerializationTests
{
    private static JsonSerializerOptions CreateOptions() => new TestChart().GetSerializerOptions();

    [TestMethod]
    public void SerializesLineChartWithBasicOptions()
    {
        var options = ChartOptionsBuilder.LineChartBasic();
        var serializerOptions = CreateOptions();

        string json = JsonSerializer.Serialize(options, serializerOptions);

        Assert.IsFalse(string.IsNullOrWhiteSpace(json));
        Assert.IsTrue(json.Contains("\"title\""));
        Assert.IsTrue(json.Contains("\"line\""));

        SnapshotHelper.AssertJsonSnapshot(
            options,
            nameof(ChartOptionsSerializationTests),
            nameof(SerializesLineChartWithBasicOptions),
            serializerOptions);
    }

    [TestMethod]
    public void SerializesBarChartWithMultipleSeries()
    {
        var options = ChartOptionsBuilder.BarChartMultipleSeries();
        var serializerOptions = CreateOptions();

        string json = JsonSerializer.Serialize(options, serializerOptions);

        Assert.IsFalse(string.IsNullOrWhiteSpace(json));
        Assert.IsTrue(json.Contains("\"bar\""));
        Assert.IsTrue(json.Contains("\"stack\""));

        SnapshotHelper.AssertJsonSnapshot(
            options,
            nameof(ChartOptionsSerializationTests),
            nameof(SerializesBarChartWithMultipleSeries),
            serializerOptions);
    }
}
