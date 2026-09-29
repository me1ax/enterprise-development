namespace DryCleaning.Domain.Enums;

///<summary>
/// Вид чистки изделия
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