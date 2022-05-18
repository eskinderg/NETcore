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
    public IRepository<Event> Repository { get; }
    public IEnumerable<Event> AllEvents => Repository.Table.ToList();

    public EventService(IRepository<Event> repository) => Repository = repository;

    public Event Add(Event e)
    {
      Repository.Insert(e);
      return e;
    }

    public Event Update(Event e)
    {
      Repository.Update(e);
      return e;
    }

    public Event GetEventById(int id, string userId) => Repository.GetById(id, userId);

    public Event Delete(Event e)
    {
      Repository.Delete(e);
      return e;
    }

    public IEnumerable<Event> GetEventsByUserId (string userid) => 
      Repository.Table.Where(e => e.UserID == userid);
  }
}
