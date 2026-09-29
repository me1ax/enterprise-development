using DryCleaning.Domain.Enums;

namespace DryCleaning.Domain.Queries;

///<summary>
///Аналитические запросы по заказам
///</summary>

public static class OrderQueries
{
    ///<summary>
    ///Заказы, находящиеся в оброботку, упорядоченные по дате приема
    ///</summary>
    public static List<Order> GetInProgressOrders(IEnumerable<Order> orders) =>
        orders
            .Where(o => o.Status == OrderStatus.InProgress)
            .OrderBy(o => o.AcceptDate)
            .ThenBy(o => o.Id)
            .ToList();
    ///<summary>
    ///Топ-5 клиентов, сдавших более всего изделий за период
    ///</summary>
    public static List<Client> GetTop5Clients(
        IEnumerable<Order> orders, DateTime from, DateTime to) =>
        orders
            .Where(o => o.AcceptDate >= from && o.AcceptDate < to)
            .Where(o => o.Status != OrderStatus.Cancelled)
            .GroupBy(o => o.Client.Id)
            .OrderByDescending(g => g.Count())
            .ThenBy(g => g.First().Client.FullName)
            .ThenBy(g => g.Key)
            .Take(5)
            .Select(g => g.First().Client)
            .ToList();
    ///<summary>
    ///Клиенты, чьи заказы обрабатывались дольше всего, упорядоченные по ФИО
    ///</summary>
    public static List<Client> GetClientsWithLongestProcessing(IEnumerable<Order> orders)
    {
        var maxDays = orders.Max(o => o.DueDays);

        return orders
            .Where(o => o.DueDays == maxDays)
            .Select(o => o.Client)
            .DistinctBy(c => c.Id)
            .OrderBy(c => c.FullName)
            .ThenBy(c => c.Id)
            .ToList();
    }

    ///<summary>
    ///Топ-5 наиболее популярных категорий за период
    ///</summary>
    public static List<ItemCategory> GetMostPopularCategories(
        IEnumerable<Order> orders,
        IEnumerable<ItemCategory> categories,
        DateTime from, DateTime to)
    {
        var relevant = orders
            .Where(o => o.AcceptDate >= from && o.AcceptDate < to)
            .Where(o => o.Status != OrderStatus.Cancelled)
            .ToList();

        return categories
            .OrderByDescending(c => relevant.Count(o => o.Item.Category.Id == c.Id))
            .ThenBy(c => c.Name)
            .ThenBy(c => c.Id)
            .Take(5)
            .ToList();
    }

    ///<summary>
    ///Топ-5 наименее популярных категорий за период
    ///</summary>
    public static List<ItemCategory> GetLeastPopularCategories(
        IEnumerable<Order> orders,
        IEnumerable<ItemCategory> categories,
        DateTime from, DateTime to)
    {
        var relevant = orders
            .Where(o => o.AcceptDate >= from && o.AcceptDate < to)
            .Where(o => o.Status != OrderStatus.Cancelled)
            .ToList();

        return categories
            .OrderBy(c => relevant.Count(o => o.Item.Category.Id == c.Id))
            .ThenBy(c => c.Name)
            .ThenBy(c => c.Id)
            .Take(5)
            .ToList();
    }
    ///<summary>
    ///Клиент, потративший наибольшую сумму за весь период работы химчистки
    ///</summary>
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