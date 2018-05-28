using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Project.Infra;
using AutoMapper;
using Project.Model.Models;
using Microsoft.AspNetCore.Cors;

namespace ProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiVersion("1.0")]
    public class NotesController : BaseController
    {
        public NotesController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }

        [HttpGet]
        [Authorize(Policy = "CanWriteCustomerData")]
        public JsonResult Get()
        {
            return Json(UnitOfWork.Notes.AllNotes);
        }

        // POST api/notes
        [HttpPost]
        public JsonResult Post([FromBody]Note model)
        {
            if (ModelState.IsValid)
            {
                UnitOfWork.Notes.Add(model);
                UnitOfWork.Save();
                return Json(model);
            }
            return Json(BadRequest(ModelState));
        }

        // GET api/notes/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            return Json(UnitOfWork.Notes.GetNoteById(id));
        }

        // DELETE api/notes/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            var evnt = UnitOfWork.Notes.GetNoteById(id);
            UnitOfWork.Notes.Delete(evnt);
            UnitOfWork.Save();
            return Json(evnt);
        }

        // PUT api/notes/
        // [HttpPut("{id}")]
        public JsonResult Put([FromBody]Note model)
        {
            var updated = UnitOfWork.Notes.Update(model);
            UnitOfWork.Save();
            return Json(updated);
        }
    }
}
