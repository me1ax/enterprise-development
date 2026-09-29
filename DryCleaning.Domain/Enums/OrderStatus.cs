namespace  DryCleaning.Domain.Enums;

///<summary>
/// Статус заказа в химчистке
///</summary>
public enum OrderStatus
{
    ///<summary>
    /// Принят
    ///</summary>
    Accepted,

    ///<summary>
    /// В обработке
    ///</summary>
    InProgress,

    ///<summary>
    /// Выполнен
    ///</summary>
    Completed,

    ///<summary>
    /// Выдан
    ///</summary>
    Issued,

    ///<summary>
    ///Отменен
    ///</summary>
    Cancelled
}