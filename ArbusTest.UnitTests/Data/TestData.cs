namespace ArbusTest.UnitTests.Data;

public static class TestData
{
    public static IEnumerable<string> GetDishes(int count)
    {
        return Enumerable.Range(1, count)
            .Select(x => x.ToString());
    }
}