namespace CalendarManagerLibrary;

public class CalendarManagment
{
    // List для хранения событий (объекты класса Event)
    private List<Event> _eventsList = new List<Event>();

    
    /// <summary>
    /// Метод для добавления события в список (если событие не инициализировано)
    /// </summary>
    /// <param name="eventname">наименования события</param>
    /// <param name="description">описание</param>
    /// <param name="eventDateTime">дата-время начала</param>
    /// <param name="eventType">тип события</param>
    /// <param name="eventOrginezer">Организатор</param>
    /// <param name="participants"> список участников</param>
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

    /// <summary>
    /// Метод для добавления события в список (если событие уже создано)
    /// </summary>
    /// <param name="ev"> событие (объект класса Event)</param>
    /// <exception cref="Exception"></exception>
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

    /// <summary>
    /// Метод для удаления события
    /// </summary>
    /// <param name="eventId">ID события</param>
    /// <exception cref="Exception"></exception>
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

    /// <summary>
    /// Метод для смены наименования события
    /// </summary>
    /// <param name="eventId">ID события</param>
    /// <param name="newEventName">Новое наименование события</param>
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

    /// <summary>
    /// Метод для смены описания события
    /// </summary>
    /// <param name="eventId">ID события</param>
    /// <param name="newEventDescription">Новое описание события</param>
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

    /// <summary>
    /// Метод для смены Даты-времени начала события
    /// </summary>
    /// <param name="eventId">ID события</param>
    /// <param name="newEventDateTime"> Новая Дата-время начала события</param>
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

    /// <summary>
    /// Метод для смены организатора события
    /// </summary>
    /// <param name="eventId">ID события</param>
    /// <param name="newEventOrginezer">Новый организатор события</param>
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
    
    /// <summary>
    /// Метод для печати информации о событии по ID
    /// </summary>
    /// <param name="eventId">ID события</param>
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

    /// <summary>
    /// Метод для печати информации о событиях из произвольного списка событий (Объектов класса Event)
    /// </summary>
    /// <param name="listEv">Список события</param>
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


    /// <summary>
    /// Метод для получения события по ID
    /// </summary>
    /// <param name="eventId">ID события</param>
    /// <returns>Событие (Event)</returns>
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

    
    /// <summary>
    /// Метод для печати всех событий
    /// </summary>
    public void ShowAllEvents()
    {
        foreach (var item in _eventsList)
        {
            ShowEventByID(item._eventId);
        }
    }

    /// <summary>
    /// Метод возвращающий список всех событий
    /// </summary>
    /// <returns>Список событий (List<Event>)</returns>
    public List<Event> GetAllEvents()
    {
        return _eventsList;
    }
    
    /// <summary>
    /// Метод для печати информации о событии по дате
    /// </summary>
    /// <param name="eventDateTime">Дата-время начала события</param>
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


    /// <summary>
    /// Метод возвращающий список событий по дате (фильтрация).
    /// Метод сравнивает дату, независимо от времени
    /// </summary>
    /// <param name="eventDateTime">Дата-время начала события</param>
    /// <returns>Список событий (List<Event>)</returns>
    public List<Event> GetEventsByDate(DateTime eventDateTime)
    {
        return _eventsList.Where(x => x._eventDateTime.Date == eventDateTime.Date).ToList();
    }

    /// <summary>
    /// Метод для печати информации о событиях по типу события (фильтрация)
    /// </summary>
    /// <param name="Type">Тип события (Объект enum TypesEvent)</param>
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

    /// <summary>
    /// Метод возвращающий список событий по типу события (фильтрация)
    /// </summary>
    /// <param name="Type">Тип события (Объект enum TypesEvent)</param>
    /// <returns>Список событий (List<Event>)</returns>
    public List<Event> GetEventsByType(TypesEvent Type)
    {
        return _eventsList.Where(x => x._eventType == Type).ToList();
    }


    /// <summary>
    /// Метод для печати информации о событиях по Организатору(фильтрация)
    /// </summary>
    /// <param name="orginezer">Организатор события</param>
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

    /// <summary>
    /// Метод возвращающий список событий по Организатору (фильтрация)
    /// </summary>
    /// <param name="orginezer">Организатор</param>
    /// <returns>Список событий (List<Event>)</returns>
    public List<Event> GetEventsByOrginezer(string orginezer)
    {
        return _eventsList.Where(x => x._eventOrginezer == orginezer).ToList();
    }

    /// <summary>
    /// Метод возвращающий общее количество событий
    /// </summary>
    /// <returns>Количество (int)</returns>
    public int GetCountEvent()
    {
        return _eventsList.Count;
    }

    /// <summary>
    /// Метод для печати общего количества событий
    /// </summary>
    public void ShowCountEvent()
    {
        Console.WriteLine($"Количество событий - {this.GetCountEvent()}");
    }


    /// <summary>
    /// Метод для получения событий по списку участников
    /// </summary>
    /// <param name="participants"></param>
    /// <returns>Список событий (List<Event>)</returns>
    public List<Event> GetEventByListOfParticipants(List<string> participants)
    {
        List<Event> events = new List<Event>();
        
        foreach (var item in _eventsList)
        {
            bool flag = false;
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