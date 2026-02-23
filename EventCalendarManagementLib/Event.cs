namespace CalendarManagerLibrary;

/// <summary>
/// Класс для хранения свойств объекта событие
/// </summary>
public class Event
{
    public int _eventId;
    public string _eventname;
    public DateTime _eventDateTime;
    public string _description;
    public TypesEvent _eventType;
    public string _eventOrginezer;
    public List<string> _participants;

    //ID счетчик 
    private static int currentId = 1;

    /// <summary>
    /// Конструктор для объекта класса Event
    /// </summary>
    /// <param name="eventname">наименование события</param>
    /// <param name="description">описание события</param>
    /// <param name="eventDateTime">Дата-время начала события</param>
    /// <param name="eventType">Тип события</param>
    /// <param name="eventOrginezer">Организатор события</param>
    /// <param name="participants">Список участников события</param>
    public Event( string eventname, string description,  DateTime eventDateTime, TypesEvent eventType, string eventOrginezer, List<string> participants)
    {
        _eventId = currentId++;
        _eventname = eventname;
        _description = description;
        _eventDateTime = eventDateTime;
        _eventType = eventType;
        _eventOrginezer = eventOrginezer;
        _participants = participants;
    }

    /// <summary>
    /// Метод для сброса счетчика событий
    /// </summary>
    public static void ResetID()
    {
        currentId = 1;
    }
}