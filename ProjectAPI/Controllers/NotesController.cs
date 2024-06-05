using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Project.Infra;
using AutoMapper;
using Project.Model.Models;
using ProjectAPI.Identity.Authorization;
using System.Collections.Generic;
using Project.Model.ViewModels;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace ProjectAPI.Controllers
{
  [Route("api/[controller]")]
  [Authorize]
  [ApiVersion("1.0")]
  public class NotesController : BaseController
  {
    public NotesController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }

    // GET api/notes
    [HttpGet]
    [Authorize(Policy = "CanRead")]
    public JsonResult Get()
    {
      var notes = Mapper.Map<IEnumerable<Note>, List<NoteViewModel>>
      (UnitOfWork.Notes.GetNotesByUserId(User.GetLoggedInUserId<Guid>())
      .OrderByDescending(n => n.DateModified))
      .OrderByDescending(n => n.PinOrder);
      return Json(notes);
    }

    // POST api/notes
    [HttpPost]
    [Authorize(Policy = "CanWrite")]
    public JsonResult Post([FromBody] Note model)
    {
      model.UserId = User.GetLoggedInUserId<Guid>();

      if (ModelState.IsValid)
      {
        var result = UnitOfWork.Notes.Add(model);
        UnitOfWork.Save();
        return Json(result);
      }
      return Json(BadRequest(ModelState));
    }

    // GET api/notes/5
    [HttpGet("{id}")]
    [Authorize(Policy = "CanRead")]
    public JsonResult Get(int id) => Json(UnitOfWork.Notes.GetNoteById(id, User.GetLoggedInUserId<Guid>()));

    // DELETE api/notes/5
    [HttpDelete("{id}")]
    [Authorize(Policy = "CanWrite")]
    public JsonResult Delete(int id)
    {
      var evnt = UnitOfWork.Notes.GetNoteById(id, User.GetLoggedInUserId<Guid>());
      UnitOfWork.Notes.Delete(evnt);
      UnitOfWork.Save();
      return Json(evnt);
    }

    // PUT api/notes/
    [HttpPut]
    [Authorize(Policy = "CanWrite")]
    public JsonResult Put([FromBody] Note model)
    {
      model.UserId = User.GetLoggedInUserId<Guid>();
      var updated = UnitOfWork.Notes.Update(model);
      if (updated != null)
      {
        UnitOfWork.Save();
        UnitOfWork.AppDbContext.Entry<Note>(updated).Reload();

        return Json(Mapper.Map<NoteViewModel>(updated));
      }
      Response.StatusCode = StatusCodes.Status400BadRequest;
      return Json(model);
    }
  }
}
