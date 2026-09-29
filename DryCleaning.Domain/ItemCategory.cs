using DryCleaning.Domain.Enums;

namespace DryCleaning.Domain;

///<summary>
/// Категория изделия
///</summary>
public class ItemCategory
{
    ///<summary>
    /// Клиент химчистки
    ///</summary>
    public int Id { get; set; }

    ///<summary>
    /// Название категории
    ///</summary>
    public required string Name { get; set; }

    ///<summary>
    /// Рекомендуемый вид чистки
    ///</summary>
    public CleaningType RecommendedCleaningType { get; set; }

    ///<summary>
    /// Стоимость чистки
    ///</summary>
    public decimal Price { get; set; }
}