using DryCleaning.Domain;
using DryCleaning.Domain.Enums;

namespace DryCleaning.Tests.Services;

/// <summary>
/// Аналитические запросы по заказам
/// </summary>

public static class OrderQueries
{
    /// <summary>
    /// Заказы, находящиеся в обработке, упорядоченные по дате приема
    /// </summary>
    public static List<Order> GetInProgressOrders(IEnumerable<Order> orders) =>
        [.. orders
            .Where(o => o.Status == OrderStatus.InProgress)
            .OrderBy(o => o.AcceptDate)
            .ThenBy(o => o.Id)];
    /// <summary>
    /// Топ-5 клиентов, сдавших более всего изделий за период
    /// </summary>
    public static List<Client> GetTop5Clients(
        IEnumerable<Order> orders, DateTime from, DateTime to) =>
        [.. orders
            .Where(o => o.AcceptDate >= from && o.AcceptDate < to)
            .Where(o => o.Status != OrderStatus.Cancelled)
            .GroupBy(o => o.Client.Id)
            .OrderByDescending(g => g.Count())
            .ThenBy(g => g.First().Client.FullName)
            .ThenBy(g => g.Key)
            .Take(5)
            .Select(g => g.First().Client)];
    /// <summary>
    /// Клиенты, чьи заказы обрабатывались дольше всего, упорядоченные по ФИО
    /// </summary>
    public static List<Client> GetClientsWithLongestProcessing(IEnumerable<Order> orders)
    {
        var maxDays = orders.Max(o => o.DueDays);

        return (List<Client>)[.. orders
            .Where(o => o.DueDays == maxDays)
            .Select(o => o.Client)
            .DistinctBy(c => c.Id)
            .OrderBy(c => c.FullName)
            .ThenBy(c => c.Id)];
    }

    /// <summary>
    /// Топ-5 категорий за период, упорядоченных по популярности
    /// </summary>
    public static List<ItemCategory> GetCategoryPopularity(
        IEnumerable<Order> orders,
        IEnumerable<ItemCategory> categories,
        DateTime from, DateTime to,
        bool descending)
    {
        List<Order> relevant = [.. orders
            .Where(o => o.AcceptDate >= from && o.AcceptDate < to)
            .Where(o => o.Status != OrderStatus.Cancelled)];

        var ordered = descending
            ? categories.OrderByDescending(c => relevant.Count(o => o.Item.Category.Id == c.Id))
            : categories.OrderBy(c => relevant.Count(o => o.Item.Category.Id == c.Id));

        return [.. ordered
            .ThenBy(c => c.Name)
            .ThenBy(c => c.Id)
            .Take(5)];
    }

    /// <summary>
    /// Клиент, потративший наибольшую сумму за весь период работы химчистки
    /// </summary>
    public static Client? GetTopSpendingClient(IEnumerable<Order> orders) =>
        orders
            .Where(o => o.Status == OrderStatus.Issued)
            .GroupBy(o => o.Client.Id)
            .Select(g => new
            {
                Owner = g.First().Client,
                Total = g.Sum(o => o.Item.Category.Price)
            })
            .OrderByDescending(x => x.Total)
            .ThenBy(x => x.Owner.FullName)
            .ThenBy(x => x.Owner.Id)
            .FirstOrDefault()
            ?.Owner;
}