namespace CalendarManagerLibrary;

public class Event
{
    public int _eventId;
    public string _eventname;
    public DateTime _eventDateTime;
    public string _description;
    public TypesEvent _eventType;
    public string _eventOrginezer;
    public List<string> _participants;

    private static int currentId = 1;
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

    public static void ResetID()
    {
        currentId = 1;
    }
}