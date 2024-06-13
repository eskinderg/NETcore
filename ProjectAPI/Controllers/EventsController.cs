using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Project.Infra;
using AutoMapper;
using Project.Model.Models;
using System.Collections.Generic;
using Project.Model.ViewModels;
using Microsoft.AspNetCore.Http;
using ProjectAPI.Identity.Authorization;

namespace ProjectAPI.Controllers
{
  [Route("api/[controller]")]
  [Authorize]
  [ApiVersion("1.0")]
  public class EventsController : BaseController
  {
    public EventsController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }

    [HttpGet]
    [Authorize]
    public JsonResult Get()
    {
      var events = Mapper.Map<IEnumerable<Event>, List<EventViewModel>>
        (UnitOfWork.Events.GetEventsByUserId(User.GetLoggedInUserId<string>()));
      return Json(events);
    }

    // POST api/events
    [HttpPost]
    [Authorize]
    public JsonResult Post([FromBody] Event model)
    {
      if (ModelState.IsValid)
      {
        model.UserID = User.GetLoggedInUserId<string>();
        UnitOfWork.Events.Add(model);
        UnitOfWork.Save();
        return Json(model);
      }
      return Json(BadRequest(ModelState));
    }

    // GET api/events/5
    [HttpGet("{id}")]
    [Authorize]
    public JsonResult Get(int id) => Json(UnitOfWork.Events.GetEventById(id, User.GetLoggedInUserId<string>()));

    // DELETE api/events/5
    [HttpDelete("{id}")]
    [Authorize(Policy = "CanWrite")]
    public JsonResult Delete(int id)
    {
      var evnt = UnitOfWork.Events.GetEventById(id, User.GetLoggedInUserId<string>());
      UnitOfWork.Events.Delete(evnt);
      UnitOfWork.Save();
      return Json(evnt);
    }

    // DELETE api/events/
    [HttpDelete()]
    [Authorize]
    public JsonResult Delete([FromBody] IEnumerable<Event> events)
    {

      /* var evnts = UnitOfWork.Events.GetEventsById(events, User.GetLoggedInUserId<string>()); */

      /* foreach (var e in events) { */
      /*   e.UserID = User.GetLoggedInUserId<string>(); */
      /* } */

      /* UnitOfWork.Events.Delete(events); */
      /* UnitOfWork.Save(); */
      return Json(events);
    }

    // PUT api/events/
    [HttpPut()]
    [Authorize]
    public JsonResult Put([FromBody] Event model)
    {
      model.UserID = User.GetLoggedInUserId<string>();
      var updated = UnitOfWork.Events.Update(model);
      if (updated != null)
      {
        UnitOfWork.Save();
        return Json(Mapper.Map<EventViewModel>(updated));
      }
      Response.StatusCode = StatusCodes.Status400BadRequest;
      return Json(model);
    }

    // PUT api/events/
    [Authorize]
    [HttpPut("Toggle")]
    public JsonResult Toggle([FromBody] Event model)
    {
      model.Complete = !model.Complete;
      model.UserID = User.GetLoggedInUserId<string>();
      var updated = UnitOfWork.Events.Update(model);
      if (updated != null)
      {
        UnitOfWork.Save();
        return Json(Mapper.Map<EventViewModel>(updated));
      }
      Response.StatusCode = StatusCodes.Status400BadRequest;
      return Json(model);
    }
  }
}
