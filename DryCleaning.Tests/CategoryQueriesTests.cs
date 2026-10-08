using DryCleaning.Domain.Seeds;
using DryCleaning.Tests.Services;

namespace DryCleaning.Tests;

/// <summary>
/// Тесты популярности категорий
/// </summary>

public class CategoryQueriesTests(TestData data) : IClassFixture<TestData>
{
    /// <summary>
    /// Топ-5 наиболее популярных категорий за 2026 год
    /// </summary>
    [Fact]
    public void MostPopularCategoriesAreCalculated()
    {
        var from = new DateTime(2026, 1, 1);
        var to = new DateTime(2027, 1, 1);

        int[] expectedIds = [4, 8, 1, 10, 3];

        var categories = OrderQueries.GetCategoryPopularity(
            data.Orders, data.Categories, from, to, descending: true);

        Assert.Equal(expectedIds, categories.Select(c => c.Id));
    }

    /// <summary>
    /// Топ-5 наименее популярных категорий за 2026 год
    /// </summary>
    [Fact]
    public void LeastPopularCategoriesAreCalculated()
    {
        var from = new DateTime(2026, 1, 1);
        var to = new DateTime(2027, 1, 1);

        int[] expectedIds = [3, 7, 2, 6, 9];

        var categories = OrderQueries.GetCategoryPopularity(
            data.Orders, data.Categories, from, to, descending: false);
        
        Assert.Equal(expectedIds, categories.Select(c => c.Id));
    }
}