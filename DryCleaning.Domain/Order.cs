using DryCleaning.Domain.Enums;

namespace DryCleaning.Domain;

///<summary>
/// Заказ на обработку изделия
///</summary>
public class Order
{
    //<summary>
    // Идентификатор заказа
    //</summary>
    public int Id { get; set; }

    ///<summary>
    /// Клиент
    ///</summary>
    public required Client Client { get; set; }

    ///<summary>
    /// Изделие
    ///</summary>
    public required Item Item { get; set; }

    ///<summary>
    ///Дата приема заказа
    ///</summary>
    public DateTime AcceptDate { get; set; }  

    ///<summary>
    // Срок выполнения заказа
    //</summary>
    public int DueDays { get; set; }

    ///<summary>
    /// Статус заказа
    ///</summary>
    public OrderStatus Status { get; set; }
}