using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Project.Infra;
using AutoMapper;
using Project.Model.Models;
using System.Security.Claims;
using System.Collections.Generic;
using Project.Model.ViewModels;
using Microsoft.AspNetCore.Http;
using ProjectAPI.Identity.Authorization;
/* using Microsoft.AspNetCore.Cors; */

namespace ProjectAPI.Controllers
{
  [Route("api/[controller]")]
  [Authorize]
  [ApiVersion("1.0")]
  public class EventsController : BaseController
  {
    public EventsController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }

    [HttpGet]
    [Authorize(Policy = "CanRead")]
    public JsonResult Get()
    {
      var events = Mapper.Map<IEnumerable<Event>,List<EventViewModel>>(UnitOfWork.Events.GetEventsByUserId(HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)));
      /* return Json(UnitOfWork.Events.GetEventsByUserId(HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier))); */
      return Json(events);
    }

    // POST api/events
    [HttpPost]
    [Authorize(Policy = "CanWrite")]
    public JsonResult Post([FromBody]Event model)
    {
      if (ModelState.IsValid)
      {
        model.UserID = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        UnitOfWork.Events.Add(model);
        UnitOfWork.Save();
        return Json(model);
      }
      return Json(BadRequest(ModelState));
    }

    // GET api/events/5
    [HttpGet("{id}")]
    [Authorize(Policy = "CanRead")]
    public JsonResult Get(int id) => Json(UnitOfWork.Events.GetEventById(id, HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)));

    // DELETE api/events/5
    [HttpDelete("{id}")]
    [Authorize(Policy = "CanWrite")]
    public JsonResult Delete(int id)
    {
      var evnt = UnitOfWork.Events.GetEventById(id, HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
      UnitOfWork.Events.Delete(evnt);
      UnitOfWork.Save();
      return Json(evnt);
    }

    // PUT api/events/
    [HttpPut()]
    [Authorize(Policy = "CanWrite")]
    public JsonResult Put([FromBody]Event model)
    {
      model.UserID = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
      var updated = UnitOfWork.Events.Update(model);
      if(updated != null) {
        UnitOfWork.Save();
        return Json(updated);
      }
      Response.StatusCode = StatusCodes.Status400BadRequest;
      return Json(model);
    }

    // PUT api/events/
    [Authorize(Policy = "CanWrite")]
    [HttpPut("Toggle")]
    public JsonResult Toggle([FromBody]Event model)
    {
      model.Complete = !model.Complete;
      model.UserID = User.GetLoggedInUserId<string>();
      var updated = UnitOfWork.Events.Update(model);
      if(updated != null) {
        UnitOfWork.Save();
        return Json(updated);
      }
      Response.StatusCode = StatusCodes.Status400BadRequest;
      return Json(model);
    }
  }
}
