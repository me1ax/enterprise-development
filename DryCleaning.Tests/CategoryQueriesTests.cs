using DryCleaning.Domain.Queries;
using DryCleaning.Domain.Seeds;

namespace DryCleaning.Tests;

///<summary>
///Тесты популярности категорий
///</summary>

public class CategoryQueriesTests(TestData data) : IClassFixture<TestData>
{
    ///<summary>
    ///Топ-5 наиболее популярных категорий за 2026 год
    ///</summary>
    [Fact]
    public void MostPopularCategoriesAreCalculated()
    {
        var from = new DateTime(2026, 1, 1);
        var to = new DateTime(2027, 1, 1);

        int[] expectedIds = [1, 6, 7, 4, 8];

        var categories = OrderQueries.GetMostPopularCategories(
            data.Orders, data.Categories, from, to);

        Assert.Equal(expectedIds, categories.Select(c => c.Id));
    }

    ///<summary>
    ///Топ-5 наименее популярных категорий за 2026 год
    ///</summary>
    [Fact]
    public void LeastPopularCategoriesAreCalculated()
    {
        var from = new DateTime(2026, 1, 1);
        var to = new DateTime(2027, 1, 1);

        int[] expectedIds = [3, 2, 9, 10, 5];

        var categories = OrderQueries.GetLeastPopularCategories(
            data.Orders, data.Categories, from, to);
        
        Assert.Equal(expectedIds, categories.Select(c => c.Id));
    }
}