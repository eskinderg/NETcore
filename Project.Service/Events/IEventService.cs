using System;
using System.Collections.Generic;
using Project.Model.Models;

namespace Project.Services
{
    public interface IEventService
    {
        IEnumerable<Event> AllEvents { get; }
        Event GetEventById(int id);
        Event Add(Event e);
        Event Update(Event e);
        Event Delete(Event e);
    }
}
