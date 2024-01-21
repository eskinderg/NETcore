using System;
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

    public Event Add(Event e) => Repository.Insert(e);

    public Event Update(Event e) => Repository.Update(e); 

    public Event GetEventById(int id, Guid userId) => Repository.GetById(id, userId);

    public Event Delete(Event e)
    {
      Repository.Delete(e);
      return e;
    }

    public IEnumerable<Event> Delete(IEnumerable<Event> events) => Repository.Delete(events);

    public IEnumerable<Event> GetEventsByUserId (Guid userid) => Repository.Table.Where(e => e.UserID == userid);

    }
  }

