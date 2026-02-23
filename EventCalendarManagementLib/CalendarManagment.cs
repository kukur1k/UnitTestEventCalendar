namespace CalendarManagerLibrary;

public class CalendarManagment
{
    private List<Event> _eventsList = new List<Event>();

    //============Добавление===========
    public void AddEventInCalendar(
        string eventname,
        string description, 
        DateTime eventDateTime,
        TypesEvent eventType,
        string eventOrginezer, 
        List<string> participants)
    {
        Event newEv = new Event(eventname, description, eventDateTime, eventType, eventOrginezer, participants);
        _eventsList.Add(newEv);
    }

    //Вариант с готовым событием
    public void AddEventIncalendar(Event ev)
    {
        foreach (var item in _eventsList)
        {
            if (item._eventDateTime == ev._eventDateTime && item._eventname == ev._eventname)
            {
                throw new Exception("This Event already exsist");
            }
        }
        _eventsList.Add(ev);
    }

    //============Удаление===========
    public void DeleteEventInCalendar(int eventId)
    {

        int countdownEvent = _eventsList.Count;
        _eventsList.RemoveAll(item => item._eventId == eventId);

        if (_eventsList.Count == countdownEvent)
        {
            throw new Exception("This Event does not exist");
        }
             
    }

    //============Изменения параметров===========
    public void EditEventName(int eventId, string newEventName)
    {
        foreach (var item in _eventsList)
        {
            if (item._eventId == eventId)
            {
                item._eventname = newEventName;
            }
        }
    }
    public void EditEventDescription(int eventId, string newEventDescription)
    {
        foreach (var item in _eventsList)
        {
            if (item._eventId == eventId)
            {
                item._description = newEventDescription;
            }
        }
    }
    public void EditEventDateTime(int eventId, DateTime newEventDateTime)
    {
        foreach (var item in _eventsList)
        {
            if (item._eventId == eventId)
            {
                item._eventDateTime = newEventDateTime;
            }
        }
    }
    public void EditEventOrginezer(int eventId, string newEventOrginezer)
    {
        foreach (var item in _eventsList)
        {
            if (item._eventId == eventId)
            {
                item._eventOrginezer = newEventOrginezer;
            }
        }
    }
    
    //============Печать информации о событии по ID============
    public void ShowEventByID(int eventId)
    {
        foreach (var item in _eventsList)
        {
            if (item._eventId == eventId)
            {
                Console.WriteLine( $"Наименование: {item._eventname}");
                Console.WriteLine( $"Описание: {item._description}");
                Console.WriteLine( $"Дата и время: {item._eventDateTime}");
                Console.WriteLine( $"Тип события: {item._eventType}");
                Console.WriteLine( $"Организатор: {item._eventOrginezer}");
                Console.WriteLine("Список участников:");
                int PartIdx = 1;
                foreach (var particip in item._participants)
                {
                    Console.WriteLine($"{PartIdx} -- {particip}");
                    PartIdx++;
                }
                Console.WriteLine("\n");
            }
        }
    }

    //============Печать информации о событии (принимает список событий)============
    public void ShowEvents(List<Event> listEv)
    {
        foreach (var item in listEv)
        {
            Console.WriteLine($"Наименование: {item._eventname}");
            Console.WriteLine($"Описание: {item._description}");
            Console.WriteLine($"Дата и время: {item._eventDateTime}");
            Console.WriteLine($"Тип события: {item._eventType}");
            Console.WriteLine($"Организатор: {item._eventOrginezer}");
            Console.WriteLine("Список участников:");
            int PartIdx = 1;
            foreach (var particip in item._participants)
            {
                Console.WriteLine($"{PartIdx} -- {particip}");
                PartIdx++;
            }
            Console.WriteLine("\n");
           
        }
    }

    //============Получение события по ID============
    public Event GetEventByID(int eventId)
    {
        foreach (var item in _eventsList)
        {
            if (item._eventId == eventId)
            {
                return item;
            }
        }
        return null;
    }

    //============Печать всех событий============
    public void ShowAllEvents()
    {
        foreach (var item in _eventsList)
        {
            ShowEventByID(item._eventId);
        }
    }

    //============Получение всех событий============
    public List<Event> GetAllEvents()
    {
        return _eventsList;
    }
    
    //============Печать информации о событии по дате============
    public void ShowEventsByDate(DateTime eventDateTime)
    {
        foreach (var item in _eventsList)
        {
            if (item._eventDateTime.Date == eventDateTime)
            {
                ShowEventByID(item._eventId);
            }
        }
    }


    //============Получение информации о событиях по дате============
    public List<Event> GetEventsByDate(DateTime eventDateTime)
    {
        return _eventsList.Where(x => x._eventDateTime.Date == eventDateTime.Date).ToList();
    }
    
    //============Печать информации о событиях по типу============
    public void ShowEventsByType(TypesEvent Type)
    {
        foreach (var item in _eventsList)
        {
            if (item._eventType == Type)
            {
                ShowEventByID(item._eventId);
            }
        }
    }

    //============Получение информации о событиях по типу============
    public List<Event> GetEventsByType(TypesEvent Type)
    {
        return _eventsList.Where(x => x._eventType == Type).ToList();
    }


    //============Печать информации о событиях по организатору============
    public void ShowEventsByOrginezer(string orginezer)
    {
        foreach (var item in _eventsList)
        {
            if (item._eventOrginezer == orginezer)
            {
                ShowEventByID(item._eventId);
            }
        }
    }
    
    //============Получение информации о событиях по организатору============
    public List<Event> GetEventsByOrginezer(string orginezer)
    {
        return _eventsList.Where(x => x._eventOrginezer == orginezer).ToList();
    }

    //============Получение количества событий============
    public int GetCountEvent()
    {
        return _eventsList.Count;
    }

    //============Печать количества событий============
    public void ShowCountEvent()
    {
        Console.WriteLine($"Количество событий - {this.GetCountEvent()}");
    }


    //============Получение информации о событиях по списку участников============
    public List<Event> GetEventByListOfParticipants(List<string> participants)
    {
        List<Event> events = new List<Event>();
        bool flag = false;
        foreach (var item in _eventsList)
        {
            foreach (var participant in participants) {
                if (item._participants.Contains(participant))
                {
                    flag = true;
                }
            }
            if (flag) { events.Add(item); }
        }
        return events;
    }

}