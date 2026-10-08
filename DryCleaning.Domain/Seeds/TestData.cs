using DryCleaning.Domain.Enums;

namespace DryCleaning.Domain.Seeds;

/// <summary>
/// Тестовый набор данных химчистки
/// </summary>
public class TestData
{
    /// <summary>
    /// Клиенты
    /// </summary>
    public List<Client> Clients { get; } =
    [
        new Client { Id = 1, FullName = "Александр Кузнецов", PhoneNumber = "+7 927 416 5823" },
        new Client { Id = 2, FullName = "Антон Смирнов", PhoneNumber = "+7 919 813 0876" },
        new Client { Id = 3, FullName = "Данила Морозов", PhoneNumber = "+7 918 191 4883" },
        new Client { Id = 4, FullName = "Матвей Бобров", PhoneNumber = "+7 902 815 7491" },
        new Client { Id = 5, FullName = "Михаил Волков", PhoneNumber = "+7 918 915 9235" },
        new Client { Id = 6, FullName = "Дмитрий Морсов", PhoneNumber = "+7 992 652 9123" },
        new Client { Id = 7, FullName = "Александр Мельник", PhoneNumber = "+7 924 639 8195" },
        new Client { Id = 8, FullName = "Ольга Новикова", PhoneNumber = "+7 987 429 3065" },
        new Client { Id = 9, FullName = "Алексей Попов", PhoneNumber = "+7 905 736 2184" },
        new Client { Id = 10, FullName = "Мария Васильева", PhoneNumber = "+7 919 582 6473" }
    ];

    /// <summary>
    /// Категории изделий
    /// </summary>
    public List<ItemCategory> Categories { get; } =
    [
        new ItemCategory { Id = 1, Name = "Одежда", RecommendedCleaningType = CleaningType.DryCleaning, Price = 1500m },
        new ItemCategory { Id = 2, Name = "Обувь", RecommendedCleaningType = CleaningType.WetCleaning, Price = 1000m },
        new ItemCategory { Id = 3, Name = "Аксессуары", RecommendedCleaningType = CleaningType.SteamCleaning, Price = 2500m },
        new ItemCategory { Id = 4, Name = "Ковры", RecommendedCleaningType = CleaningType.WetCleaning, Price = 3000m },
        new ItemCategory { Id = 5, Name = "Шторы", RecommendedCleaningType = CleaningType.SteamCleaning, Price = 4500m },
        new ItemCategory { Id = 6, Name = "Постельное", RecommendedCleaningType = CleaningType.WetCleaning, Price = 3500m },
        new ItemCategory { Id = 7, Name = "Вечерняя одежда", RecommendedCleaningType = CleaningType.DryCleaning, Price = 4000m },
        new ItemCategory { Id = 8, Name = "Мягкие игрушки", RecommendedCleaningType = CleaningType.HandWash, Price = 5000m },
        new ItemCategory { Id = 9, Name = "Рубашки", RecommendedCleaningType = CleaningType.Ironing, Price = 900m },
        new ItemCategory { Id = 10, Name = "Футболки", RecommendedCleaningType = CleaningType.Ironing, Price = 1200m }    
    ];

    /// <summary>
    /// Изделия
    /// </summary>
    public List<Item> Items { get; }

    /// <summary>
    /// Заказы
    /// </summary>
    public List<Order> Orders { get; }

    /// <summary>
    /// Создает тестовый набор
    /// </summary>
    public TestData()
    {
        Items =
        [
            new Item { Id = 1, Name = "Ковер в спальню", Material = "Шерсть", Category = Categories[3] },
            new Item { Id = 2, Name = "Спортивная сумка", Material = "Нейлон", Category = Categories[2] },
            new Item { Id = 3, Name = "Шерстяное одеяло", Material = "Шерсть", Category = Categories[5] },
            new Item { Id = 4, Name = "Черная футболка", Material = "Синтетика", Category = Categories[9] },
            new Item { Id = 5, Name = "Кожаные ботинки", Material = "Кожа", Category = Categories[1] },
            new Item { Id = 6, Name = "Плюшевая игрушка", Material = "Плюш", Category = Categories[7] },
            new Item { Id = 7, Name = "Пальто", Material = "Шерсть", Category = Categories[0] },
            new Item { Id = 8, Name = "Сарафан", Material = "Хлопок", Category = Categories[0] },
            new Item { Id = 9, Name = "Бархатные шторы", Material = "Бархат", Category = Categories[4] },
            new Item { Id = 10, Name = "Наволочка на подушку", Material = "Шёлк", Category = Categories[5] }        
        ];

        Orders = 
        [
            new Order { Id = 1, Client = Clients[0], Item = Items[0], Status = OrderStatus.InProgress, AcceptDate = new DateTime(2026, 9, 1), DueDays = 10},
            new Order { Id = 2, Client = Clients[0], Item = Items[0], Status = OrderStatus.Issued, AcceptDate = new DateTime(2026, 8, 1), DueDays = 5},
            new Order { Id = 3, Client = Clients[0], Item = Items[5], Status = OrderStatus.Completed, AcceptDate = new DateTime(2026, 7, 1), DueDays = 4},
            new Order { Id = 4, Client = Clients[0], Item = Items[5], Status = OrderStatus.Issued, AcceptDate = new DateTime(2026, 6, 1), DueDays = 6},
            new Order { Id = 5, Client = Clients[1], Item = Items[0], Status = OrderStatus.Issued, AcceptDate = new DateTime(2026, 5, 1), DueDays = 5},
            new Order { Id = 6, Client = Clients[1], Item = Items[0], Status = OrderStatus.Issued, AcceptDate = new DateTime(2026, 4, 1), DueDays = 6},
            new Order { Id = 7, Client = Clients[1], Item = Items[5], Status = OrderStatus.InProgress, AcceptDate = new DateTime(2026, 3, 1), DueDays = 7},
            new Order { Id = 8, Client = Clients[2], Item = Items[3], Status = OrderStatus.Completed, AcceptDate = new DateTime(2026, 9, 10), DueDays = 3},
            new Order { Id = 9, Client = Clients[2], Item = Items[5], Status = OrderStatus.InProgress, AcceptDate = new DateTime(2026, 1, 1), DueDays = 6},
            new Order { Id = 10, Client = Clients[3], Item = Items[7], Status = OrderStatus.Issued, AcceptDate = new DateTime(2026, 9, 5), DueDays = 20},
            new Order { Id = 11, Client = Clients[4], Item = Items[6], Status = OrderStatus.Issued, AcceptDate = new DateTime(2026, 2, 1), DueDays = 8},
            new Order { Id = 12, Client = Clients[5], Item = Items[1], Status = OrderStatus.Cancelled, AcceptDate = new DateTime(2026, 5, 2), DueDays = 5}
        ];
    }
}