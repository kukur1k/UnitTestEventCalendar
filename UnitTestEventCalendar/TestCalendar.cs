
using NUnit.Framework;
using NUnit.Framework.Internal.Execution;
using CalendarManagerLibrary;

namespace UnitTestingCalendar;

public class calendarTest
{

    private CalendarManagment _eventManagment;
    private CalendarManagerLibrary.Event event1;
    private CalendarManagerLibrary.Event event2;
    private CalendarManagerLibrary.Event event3;

    [SetUp]
    public void Setup()
    {
        //Сброс ID событий для корректности тестов
        CalendarManagerLibrary.Event.ResetID();

        //Инициализация нескольких событий для тестирования
        event1 = new CalendarManagerLibrary.Event(
        "Event1",
        "Is event number 1",
        new DateTime(2026, 7, 20, 18, 30, 25),
        TypesEvent.Holiday,
        "Orginezer 1",
        new List<string> { "participant 1", "participant 2", "participant 3" });

        event2 = new CalendarManagerLibrary.Event(
        "Event2",
        "Is event number 2",
        new DateTime(2026, 7, 20, 15, 30, 20),
        TypesEvent.Birthday,
        "Orginezer 2",
        new List<string> { "participant 1", "participant 2", "participant 4" });

        event3 = new CalendarManagerLibrary.Event(
        "Event3",
        "Is event number 3",
        new DateTime(2026, 9, 20, 18, 30, 25),
        TypesEvent.Holiday,
        "Orginezer 3",
        new List<string> { "participant 1", "participant 2", "participant 5" });

        //Добавление событий в список
        _eventManagment = new CalendarManagment();
        _eventManagment.AddEventIncalendar(event1);
        _eventManagment.AddEventIncalendar(event2);
        _eventManagment.AddEventIncalendar(event3);

    }

    //Тест для проверки успешного добавления события
    [Test]
    public void WorkWithEventList_AddEvent_SuccessAdding()
    {
        int CountIvent = _eventManagment.GetCountEvent();

        CalendarManagerLibrary.Event event4 = new CalendarManagerLibrary.Event(
        "Event4",
        "Is event number 3",
        new DateTime(2026, 9, 20, 18, 30, 25),
        TypesEvent.Holiday,
        "Orginezer 3",
        new List<string> { "participant 1", "participant 2", "participant 5" });

        _eventManagment.AddEventIncalendar(event4);

        int NewCountIvent = _eventManagment.GetCountEvent();

        Assert.That(NewCountIvent, Is.EqualTo(CountIvent + 1));

    }

    //Тест для проверки обработки попытки добавления уже существующего события
    [Test]
    public void WorkWithEventList_AddEvent_DublicateError()
    {
        int CountIvent = _eventManagment.GetCountEvent();

        CalendarManagerLibrary.Event event4 = new CalendarManagerLibrary.Event(
        "Event3",
        "Is event number 3",
        new DateTime(2026, 9, 20, 18, 30, 25),
        TypesEvent.Holiday,
        "Orginezer 3",
        new List<string> { "participant 1", "participant 2", "participant 5" });


        var exception = Assert.Throws<Exception>(() =>
            _eventManagment.AddEventIncalendar(event4));

        Assert.That(exception.Message, Is.EqualTo("This Event already exsist"));
    }

    //Тест для проверки успешного удаления события по ID
    [Test]
    public void WorkWithEventList_DeleteEvent_SuccessDelete()
    {
        int CountIvent = _eventManagment.GetCountEvent();
        _eventManagment.DeleteEventInCalendar(1);
        int NewCountIvent = _eventManagment.GetCountEvent();

        Assert.That(NewCountIvent, Is.EqualTo(CountIvent - 1));
    }

    //Тест для проверки обработки попытки удаления не существующего события
    [Test]
    public void WorkWithEventList_DeleteEvent_ErrorDelete()
    {
        int CountIvent = _eventManagment.GetCountEvent();
        var exception = Assert.Throws<Exception>(() =>
            _eventManagment.DeleteEventInCalendar(4));
        int NewCountIvent = _eventManagment.GetCountEvent();

        Assert.That(exception.Message, Is.EqualTo("This Event does not exist"));
    }

    //Тест для проверки успешного изменения описания события
    [Test]
    public void WorkWithEventList_EditEventDescription()
    {
        List<CalendarManagerLibrary.Event> events = _eventManagment.GetAllEvents();
        string desc = events[1]._description;
        _eventManagment.EditEventDescription(2, (desc + "-- is new description"));
        string newDesc = events[1]._description;

        Assert.That(newDesc, Is.EqualTo(desc + "-- is new description"));
    }

    //Тест для проверки успешного изменения наименования события
    [Test]
    public void WorkWithEventList_EditEventName()
    {
        List<CalendarManagerLibrary.Event> events = _eventManagment.GetAllEvents();
        string name = events[1]._eventname;
        _eventManagment.EditEventName(2, (name + "-- is new Name"));
        string newName = events[1]._eventname;

        Assert.That(newName, Is.EqualTo(name + "-- is new Name"));
    }

    //Тест для проверки успешного изменения даты (дата-время) события
    [Test]
    public void WorkWithEventList_EditEventDateTime()
    {
        List<CalendarManagerLibrary.Event> events = _eventManagment.GetAllEvents();
        DateTime DT = events[1]._eventDateTime;
        _eventManagment.EditEventDateTime(2, DT.AddHours(1));
        DateTime newDT = events[1]._eventDateTime;

        Assert.That(newDT, Is.EqualTo(new DateTime(2026, 7, 20, 16, 30, 20)));
    }

    //Тест для проверки успешного изменения организатора события
    [Test]
    public void WorkWithEventList_EditEventOrginezer()
    {
        List<CalendarManagerLibrary.Event> events = _eventManagment.GetAllEvents();
        string Org = events[1]._eventOrginezer;
        _eventManagment.EditEventOrginezer(2, "New orginezer");
        string newOrg = events[1]._eventOrginezer;

        Assert.That(newOrg, Is.EqualTo("New orginezer"));
    }

    //Тест для проверки успешного получения события по ID
    [Test]
    public void WorkWithEventList_GetEventById_SuccessGet()
    {
        CalendarManagerLibrary.Event ev = _eventManagment.GetEventByID(1);
        Assert.That(ev, Is.EqualTo(event1));
    }

    //Тест для проверки обработки попытки получения несуществующего события по ID
    [Test]
    public void WorkWithEventList_GetEventById_GetNull()
    {
        CalendarManagerLibrary.Event ev = _eventManagment.GetEventByID(5);
        Assert.That(ev, Is.EqualTo(null));
    }

    //Тест для проверки успешного получения списка всех событий
    [Test]
    public void WorkWithEventList_GetAllEvents()
    {
        List<CalendarManagerLibrary.Event> events = _eventManagment.GetAllEvents();

        Assert.Multiple(() =>
        {
            Assert.That(events.Count(), Is.EqualTo(3));
            Assert.That(events[0]._eventId, Is.EqualTo(1));
            Assert.That(events[1]._eventId, Is.EqualTo(2));
            Assert.That(events[2]._eventId, Is.EqualTo(3));
            Assert.That(events[0]._eventname, Is.EqualTo("Event1"));
            Assert.That(events[1]._eventname, Is.EqualTo("Event2"));
            Assert.That(events[2]._eventname, Is.EqualTo("Event3"));
        });

    }

    //Тест для проверки успешного получения событий по дате
    [Test]
    public void WorkWithEventList_GetEventsByDate()
    {
        List<CalendarManagerLibrary.Event> events =
            _eventManagment.GetEventsByDate(new DateTime(2026, 7, 20, 18, 30, 25));

        Assert.Multiple(() =>
        {
            Assert.That(events[0]._eventId, Is.EqualTo(1));
            Assert.That(events[1]._eventId, Is.EqualTo(2));
        });

        

    }

    //Тест для проверки успешного получения события по ID
    [Test]
    public void WorkWithEventList_GetEventsByType()
    {
        List<CalendarManagerLibrary.Event> events =
            _eventManagment.GetEventsByType(TypesEvent.Birthday);

        Assert.That(events[0]._eventType, Is.EqualTo(TypesEvent.Birthday));
    }

    //Тест для проверки успешного получения колиества событий
    [Test]
    public void WorkWithEventList_GetCountEvents()
    {
        int count = _eventManagment.GetCountEvent();
        Assert.That(count, Is.EqualTo(3));
    }


    //Тест для проверки успешного получения событий по списку участников
    [Test]
    public void WorkWithEventList_GetEventByListOfParticipants_ReturnAllEvents()
    {
        List<CalendarManagerLibrary.Event> events =
            _eventManagment.GetEventByListOfParticipants(new List<string> { "participant 1", "participant 2" });

        Assert.Multiple(() =>
        {
            Assert.That(events[0]._eventId, Is.EqualTo(1));
            Assert.That(events[1]._eventId, Is.EqualTo(2));
            Assert.That(events[2]._eventId, Is.EqualTo(3));
        });
    }

    //Тест для проверки успешного получения событий по списку участников (при одиночном совпадении)
    [Test]
    public void WorkWithEventList_GetEventByListOfParticipants_ReturnOneEvents()
    {
        List<CalendarManagerLibrary.Event> events =
            _eventManagment.GetEventByListOfParticipants(new List<string> { "participant 1", "participant 3" });

        Assert.That(events[0]._eventId, Is.EqualTo(1));
    }

    //Тест для проверки успешного получения события по организатору
    [Test]
    public void WorkWithEventList_GetEventByOrginezer()
    {
        List<CalendarManagerLibrary.Event> events =
            _eventManagment.GetEventsByOrginezer("Orginezer 1");

        Assert.That(events[0]._eventId, Is.EqualTo(1));
    }

}
