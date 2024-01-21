using System;
using System.Collections.Generic;
using Project.Model.Models;

namespace Project.Services
{
  public interface IEventService : IService<Event>
  {
    IEnumerable<Event> AllEvents { get; }
    Event GetEventById(int id, Guid userId);
    Event Add(Event e);
    Event Update(Event e);
    Event Delete(Event e);
    IEnumerable<Event> Delete(IEnumerable<Event> events);
    IEnumerable<Event> GetEventsByUserId (Guid userid);
  }
}
