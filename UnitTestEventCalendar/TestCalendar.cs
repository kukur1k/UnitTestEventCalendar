
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
        CalendarManagerLibrary.Event.ResetID();

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
        new DateTime(2026, 8, 20, 18, 30, 25),
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

        _eventManagment = new CalendarManagment();
        _eventManagment.AddEventIncalendar(event1);
        _eventManagment.AddEventIncalendar(event2);
        _eventManagment.AddEventIncalendar(event3);

    }

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

    [Test]
    public void WorkWithEventList_DeleteEvent_SuccessDelete()
    {
        int CountIvent = _eventManagment.GetCountEvent();
        _eventManagment.DeleteEventInCalendar(1);
        int NewCountIvent = _eventManagment.GetCountEvent();

        Assert.That(NewCountIvent, Is.EqualTo(CountIvent - 1));
    }

    [Test]
    public void WorkWithEventList_DeleteEvent_ErrorDelete()
    {
        int CountIvent = _eventManagment.GetCountEvent();
        var exception = Assert.Throws<Exception>(() =>
            _eventManagment.DeleteEventInCalendar(4));
        int NewCountIvent = _eventManagment.GetCountEvent();

        Assert.That(exception.Message, Is.EqualTo("This Event does not exist"));
    }

    [Test]
    public void WorkWithEventList_EditEventDescription()
    {
        List<CalendarManagerLibrary.Event> events = _eventManagment.GetAllEvents();
        string desc = events[1]._description;
        _eventManagment.EditEventDescription(2, (desc + "-- is new description"));
        string newDesc = events[1]._description;

        Assert.That(newDesc, Is.EqualTo(desc + "-- is new description"));
    }

    [Test]
    public void WorkWithEventList_EditEventName()
    {
        List<CalendarManagerLibrary.Event> events = _eventManagment.GetAllEvents();
        string name = events[1]._eventname;
        _eventManagment.EditEventName(2, (name + "-- is new Name"));
        string newName = events[1]._eventname;

        Assert.That(newName, Is.EqualTo(name + "-- is new Name"));
    }

    [Test]
    public void WorkWithEventList_EditEventDateTime()
    {
        List<CalendarManagerLibrary.Event> events = _eventManagment.GetAllEvents();
        DateTime DT = events[1]._eventDateTime;
        _eventManagment.EditEventDateTime(2, DT.AddHours(1));
        DateTime newDT = events[1]._eventDateTime;

        Assert.That(newDT, Is.EqualTo(DT.AddHours(1)));
    }

    [Test]
    public void WorkWithEventList_EditEventOrginezer()
    {
        List<CalendarManagerLibrary.Event> events = _eventManagment.GetAllEvents();
        string Org = events[1]._eventOrginezer;
        _eventManagment.EditEventOrginezer(2, "New orginezer");
        string newOrg = events[1]._eventOrginezer;

        Assert.That(newOrg, Is.EqualTo("New orginezer"));
    }

    [Test]
    public void WorkWithEventList_GetEventById_SuccessGet()
    {
        CalendarManagerLibrary.Event ev = _eventManagment.GetEventByID(1);
        Assert.That(ev, Is.EqualTo(event1));
    }

    [Test]
    public void WorkWithEventList_GetEventById_GetNull()
    {
        CalendarManagerLibrary.Event ev = _eventManagment.GetEventByID(5);
        Assert.That(ev, Is.EqualTo(null));
    }

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

    [Test]
    public void WorkWithEventList_GetEventsByDate()
    {
        List<CalendarManagerLibrary.Event> events =
            _eventManagment.GetEventsByDate(new DateTime(2026, 7, 20, 18, 30, 25));
        CalendarManagerLibrary.Event ev = events[0];

        Assert.That(ev._eventId, Is.EqualTo(1));

    }

    [Test]
    public void WorkWithEventList_GetEventsByType()
    {
        List<CalendarManagerLibrary.Event> events =
            _eventManagment.GetEventsByType(TypesEvent.Birthday);
        CalendarManagerLibrary.Event ev = events[0];

        Assert.That(ev._eventType, Is.EqualTo(TypesEvent.Birthday));
    }

    [Test]
    public void WorkWithEventList_GetCountEvents()
    {
        int count = _eventManagment.GetCountEvent();
        Assert.That(count, Is.EqualTo(3));
    }

    [Test]
    public void WorkWithEventList_GetEventByParticipant()
    {
        List<CalendarManagerLibrary.Event> events =
            _eventManagment.GetEventsByParticipant("participant 3");
        CalendarManagerLibrary.Event ev = events[0];

        Assert.That(ev._eventId, Is.EqualTo(1));
    }

    [Test]
    public void WorkWithEventList_GetEventByListOfParticipants_ReturnAllEvents()
    {
        List<CalendarManagerLibrary.Event> events =
            _eventManagment.GetEventByListOfParticipants(new List<string> { "participant 1", "participant 2" });
        CalendarManagerLibrary.Event ev = events[0];

        Assert.That(ev._eventId, Is.EqualTo(1));
    }

    [Test]
    public void WorkWithEventList_GetEventByListOfParticipants_ReturnFirstEvents()
    {
        List<CalendarManagerLibrary.Event> events =
            _eventManagment.GetEventByListOfParticipants(new List<string> { "participant 1", "participant 3" });
        CalendarManagerLibrary.Event ev = events[0];

        Assert.That(ev._eventId, Is.EqualTo(1));
    }

    [Test]
    public void WorkWithEventList_GetEventByOrginezer()
    {
        List<CalendarManagerLibrary.Event> events =
            _eventManagment.GetEventsByOrginezer("Orginezer 1");
        CalendarManagerLibrary.Event ev = events[0];

        Assert.That(ev._eventId, Is.EqualTo(1));
    }

}
