namespace Vizor.ECharts.Tests.Unit.Serialization;

[TestClass]
public class ExternalDataSourceRefTests
{
    private static JsonSerializerOptions CreateOptions() => new TestFixtures.TestChart().GetSerializerOptions();

    [TestMethod]
    public void SerializesFetchIdIntoRawExpression()
    {
        var dataSource = new ExternalDataSource(
            url: "https://example.com/data.json",
            fetchId: "fetch-1");

        var reference = new ExternalDataSourceRef(dataSource, "items[0]");
        string json = JsonSerializer.Serialize(reference, CreateOptions());

        Assert.IsTrue(json.Contains("fetch-1"));
        Assert.IsTrue(json.Contains("items[0]"));
        Assert.IsFalse(json.StartsWith("\""), "Reference should be written as raw JS expression, not quoted JSON string");
    }

    [TestMethod]
    public void KeepsPathWhenAlreadyPrefixed()
    {
        var reference = new ExternalDataSourceRef("fetch-2", ".data.values");
        string json = JsonSerializer.Serialize(reference, CreateOptions());

        Assert.IsTrue(json.Contains("fetch-2"));
        Assert.IsTrue(json.Contains(".data.values"));
    }
}
