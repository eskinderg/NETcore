/* using System; */
/* using Microsoft.EntityFrameworkCore; */
using System.Collections.Generic;
using Project.Model.Models;
using Project.Data;
using System.Linq;

namespace Project.Services
{
  public class EventService : IEventService
  {
    public IRepository<Event> EventRepository { get; }
    public IEnumerable<Event> AllEvents => EventRepository.Table.ToList();

    public EventService(IRepository<Event> eventRepo) => EventRepository = eventRepo;

    public Event Add(Event e)
    {
      EventRepository.Insert(e);
      return e;
    }

    public Event Update(Event e)
    {
      EventRepository.Update(e);
      return e;
    }

    public Event GetEventById(int id) => EventRepository.GetById(id);

    public Event Delete(Event e)
    {
      EventRepository.Delete(e);
      return e;
    }
  }
}
