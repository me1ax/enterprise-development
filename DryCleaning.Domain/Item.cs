namespace DryCleaning.Domain;
    
/// <summary>
/// Изделие, принятое в химчистку
/// </summary>
public class Item 
{
    /// <summary>
    /// Идентификатор изделия
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Наименование изделия
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Материал изделия
    /// </summary>
    public required string Material { get; set; }

    /// <summary>
    /// Категория изделия
    /// </summary>
    public required ItemCategory Category { get; set; }
}