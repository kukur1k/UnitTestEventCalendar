# CalendarManagment Library
## Описание
Библиотека CalendarManagment предназначена для работы с событиями и ведения списка событий. Она предоставляет функционал для добавления, изменения и поиска событий (с фильтрацией по свойствам). Библиотека реализована в виде .NET DLL. 
## Класс Event
### Конструктор: `public Event( string eventname, string description,  DateTime eventDateTime, TypesEvent eventType, string eventOrginezer, List<string> participants)`
- инициализирует объект класса Event - само событие
### `public static void ResetID() `
- сбрасывает счетчик событий
## Класс CalendarManagment
### `private List<Event> _eventsList`
- инициализирует список для хранения событий
### `AddEventInCalendar(string eventname, string description, DateTime eventDateTime, TypesEvent eventType, string eventOrginezer, List<string> participants)`
- Метод для добавления события в список (если событие не инициализировано)
- Параметры:
  - `eventname`: наименование
  - `description`: описание
  - `eventDateTime`: Дата-время начала
  - `eventType`: тип события
  - `eventOrginezer`: Организатор события
  - `participants`: Список участников
### `AddEventIncalendar(Event ev)`
- Метод для добавления события в список (если событие уже создано)
- Параметры:
  - `ev`: событие
### `DeleteEventInCalendar(int eventId)`
- Метод для удаления события по ID
- Параметры:
  - `eventID`: ID события
### `EditEventName(int eventId, string newEventName)`
- Метод для смены наименования события
- Параметры:
  - `eventID`: ID события
  - `newEventName`: новое наименование
### `EditEventDescription(int eventId, string newEventDescription)`
- Метод для смены описания события
- Параметры:
  - `eventID`: ID события
  - `newEventDescription`: новвое описание
### `EditEventDateTime(int eventId, DateTime newEventDateTime)`
- Метод для смены Даты-времени начала события
- Параметры:
  - `eventID`: ID события
  - `newEventDateTime`: новая Дата-время
### `EditEventOrginezer(int eventId, string newEventOrginezer)`
- Метод для смены организатора события
- Параметры:
  - `eventID`: ID события
  - `newEventOrginezer`: новый организатор
### `GetEventByID(int eventId)`
- Метод для получения события по ID
- Параметры:
  - `eventID`: ID события
### `GetAllEvents()`
- Метод возвращающий список всех событий
### `GetEventsByDate(DateTime eventDateTime)`
- Метод возвращающий список событий по дате (фильтрация).
- Метод сравнивает дату, независимо от времени
- Параметры:
  - `eventDateTime`: Дата-время события
### `GetEventsByType(TypesEvent Type)`
- Метод возвращающий список событий по типу события (фильтрация)
- Параметры:
  - `Type`: тип события
### `GetEventsByOrginezer(string orginezer)`
- Метод для печати информации о событиях по Организатору(фильтрация)
- Параметры:
  - `orginezer`: Организатор
### `GetCountEvent()`
- Метод возвращающий общее количество событий
### `GetEventByListOfParticipants(List<string> participants)`
- Метод для получения событий по списку участников
- Параметры:
  - `participants`: список участников
## Помимо методов, возрвращающих списки событий, в библиотеке присутствуют методы `Show...`, аналогичные по сигнатуре методам `Get...`

## Использование
Для использования библиотеки `CalendarManagment` необходимо добавить ссылку на DLL в проект. После этого можно создавать экземпляры класса Event, экземпляр класса `CalendarManagment`, и добавлять в него события, чтобы  в аольнейшем работать с ними
## Тестирование
Библиотека `CalendarManagment` включает в себя набор автоматизированных тестов, реализованных с использованием фреймворка NUnit. Тесты находятся в классе `TestCalendar` и охватывают следующие аспекты:
-	Проверка успешности создания события в календаре;
-	Проверка успешности удаления события;
-	Проверка успешности изменения информации о событии (дата, время, описание и т;д;);
-	Проверка успешности получения информации о событии по ID;
-	Проверка успешности получения списка всех событий;
-	Проверка успешности получения событий по дате;
-	Проверка успешности получения событий по типу (праздник, встреча и т;д;);
-	Проверка успешности получения количества событий;
-	Проверка успешности получения событий по участникам;
-	Проверка успешности получения событий по организатору;

## Рефакторинг кода
В коде бибилиотеки для повышения читаемости был проведен рефакторинг
