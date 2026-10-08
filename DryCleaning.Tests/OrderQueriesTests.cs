using DryCleaning.Domain.Seeds;
using DryCleaning.Tests.Services;

namespace DryCleaning.Tests;

/// <summary>
/// Тесты запросов по заказам
/// </summary>
public class OrderQueriesTests(TestData data) : IClassFixture<TestData>
{
    /// <summary>
    /// Заказы в обработке, упорядоченные по дате приема
    /// </summary>
    [Fact]
    public void InProgressOrderAreSortedByAcceptDate()
    {
        int[] expectedIds = [9, 7, 1];
        
        var orders = OrderQueries.GetInProgressOrders(data.Orders);

        Assert.Equal(expectedIds, orders.Select(o => o.Id));
    }
}