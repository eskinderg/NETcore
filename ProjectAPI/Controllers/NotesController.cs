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
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;

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
      (UnitOfWork.Notes.GetNotesByUserId(User.GetLoggedInUserId<string>())
      .OrderByDescending(n => n.DateModified));
      /* .OrderByDescending(n => n.DateModified)) */
      /* .OrderByDescending(n => n.PinOrder); */
      /* if(User.GetUsersDevice == "Android") { */
      /*   foreach (var n in notes) { */
      /*     n.UserId */
      /*   } */
      /* } */
      return Json(notes);
    }

    [HttpGet("archived")]
    [Authorize(Policy = "CanRead")]
    public JsonResult archived()
    {
      var notes = Mapper.Map<IEnumerable<Note>, List<NoteViewModel>>
     (UnitOfWork.Notes.GetArchivedNotesByUserId(User.GetLoggedInUserId<string>()));
      return Json(notes);
    }

    // POST api/notes
    [HttpPost]
    [Authorize(Policy = "CanWrite")]
    public JsonResult Post([FromBody] Note model)
    {
      model.UserId = User.GetLoggedInUserId<string>();
      model.Owner = User.GetLoggedInUserName();

      if (ModelState.IsValid)
      {
        var result = UnitOfWork.Notes.Add(model);
        UnitOfWork.Save();
        return Json(result);
      }
      return Json(BadRequest(ModelState));
    }

    [HttpPost("insert")]
    [Authorize(Policy = "CanWrite")]
    public JsonResult Insert([FromBody] IEnumerable<Note> notes)
    {
      foreach (var n in notes) {
        this.Post(n);
      }
      return Json(notes);
    }

    // GET api/notes/5
    [HttpGet("{id}")]
    [Authorize(Policy = "CanRead")]
    public JsonResult Get(int id) => Json(UnitOfWork.Notes.GetNoteById(id, User.GetLoggedInUserId<string>()));

    // DELETE api/notes/5
    [HttpDelete("{id}")]
    [Authorize(Policy = "CanWrite")]
    public JsonResult Delete(int id)
    {
      var evnt = UnitOfWork.Notes.GetNoteById(id, User.GetLoggedInUserId<string>());
      UnitOfWork.Notes.Delete(evnt);
      UnitOfWork.Save();
      return Json(evnt);
    }

    // PUT api/notes/
    [HttpPut]
    [Authorize(Policy = "CanWrite")]
    public JsonResult Put([FromBody] Note model)
    {
      model.UserId = User.GetLoggedInUserId<string>();
      model.Owner = User.GetLoggedInUserName();
      var updated = UnitOfWork.Notes.Update(model);
      if (updated != null)
      {
        try {
          UnitOfWork.Save();
          UnitOfWork.AppDbContext.Entry<Note>(updated).Reload();
        }catch(DbUpdateException ex) when (((MySqlException)ex.InnerException).Number == 12121) {
          System.Console.WriteLine("Sync failed");
          Response.StatusCode = StatusCodes.Status409Conflict;
          return Json(model);
        }

        return Json(Mapper.Map<NoteViewModel>(updated));
      }
      Response.StatusCode = StatusCodes.Status400BadRequest;
      return Json(model);
    }

    [HttpPut("update")]
    [Authorize(Policy = "CanWrite")]
    public JsonResult Update([FromBody] IEnumerable<Note> notes)
    {
      try {

        foreach (var n in notes) {
          n.UserId = User.GetLoggedInUserId<string>();
          n.Owner = User.GetLoggedInUserName();
          var updated = UnitOfWork.Notes.Update(n);

          if (updated != null) {
            UnitOfWork.Save();
            UnitOfWork.AppDbContext.Entry<Note>(updated).Reload();

          }
        }
      }catch(DbUpdateException ex) when (((MySqlException)ex.InnerException).Number == 12121) {
          System.Console.WriteLine("Sync failed");
          Response.StatusCode = StatusCodes.Status409Conflict;
          return Json(notes);
      }

      return Json(notes);
    }
  }
}
