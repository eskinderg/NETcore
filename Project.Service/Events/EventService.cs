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

    IEnumerable<Event> IEventService.AllEvents => Repository.Table.ToList();

    public EventService(IRepository<Event> repository) => Repository = repository;

    Event IEventService.Add(Event e) => Repository.Insert(e);

    Event IEventService.Update(Event e) => Repository.Update(e);

    Event IEventService.GetEventById(int id, string userId) => Repository.GetById(id, userId);

    Event IEventService.Delete(Event e)
    {
      Repository.Delete(e);
      return e;
    }

    IEnumerable<Event> IEventService.Delete(IEnumerable<Event> events) => Repository.Delete(events);

    IEnumerable<Event> IEventService.GetEventsByUserId (string userid) => Repository.Table.Where(e => e.UserID == userid);
    }
  }

