namespace DryCleaning.Domain.Enums;

///<summary>
/// Клиент химчистки
///</summary>
public enum CleaningType
{
    ///<summary>
    /// Химчистка
    ///</summary>
    DryCleaning,

    ///<summary>
    /// Аквачистка
    ///</summary>
    WetCleaning,

    ///<summary>
    /// Паровая обработка
    ///</summary>
    SteamCleaning,

    ///<summary>
    /// Ручная стирка
    ///</summary>
    HandWash,

    ///<summary>
    /// Глажение
    ///</summary>
    Ironing
}