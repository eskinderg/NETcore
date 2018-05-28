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
    public class EventsController : BaseController
    {
        public EventsController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }

        [HttpGet]
        [Authorize(Policy = "CanWriteCustomerData")]
        public JsonResult Get()
        {
            return Json(UnitOfWork.Events.AllEvents);
        }

        // POST api/events
        [HttpPost]
        public JsonResult Post([FromBody]Event model)
        {
            if (ModelState.IsValid)
            {
                UnitOfWork.Events.Add(model);
                UnitOfWork.Save();
                return Json(model);
            }
            return Json(BadRequest(ModelState));
        }

        // GET api/events/5
        [HttpGet("{id}")]
        public JsonResult Get(int id) => Json(UnitOfWork.Events.GetEventById(id));

        // DELETE api/events/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            var evnt = UnitOfWork.Events.GetEventById(id);
            UnitOfWork.Events.Delete(evnt);
            UnitOfWork.Save();
            return Json(evnt);
        }

        // PUT api/events/
        [HttpPut()]
        public JsonResult Put([FromBody]Event model)
        {
            var updated = UnitOfWork.Events.Update(model);
            UnitOfWork.Save();
            return Json(updated);
        }

        // PUT api/events/
        [HttpPut("Toggle")]
        public JsonResult Toggle([FromBody]Event model)
        {
            model.Complete = !model.Complete;
            var updated = UnitOfWork.Events.Update(model);
            UnitOfWork.Save();
            return Json(updated);
        }
    }
}
