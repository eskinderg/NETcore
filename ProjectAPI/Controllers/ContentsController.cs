using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.Model.Models;
using AutoMapper;
using Project.Model.ViewModels;
using Project.Infra;
/* using System.Security.Claims; */
using Microsoft.Extensions.Options;
using System;

namespace ProjectAPI.Controllers
{
  [Produces("application/json")]
  [Route("api/[controller]")]
  /* [EnableCors("CorsPolicy")] */
  [Authorize]
  [ApiVersion("1.0")]
  public class ContentsController : Controller
  {
    public IMapper     Mapper      { get;}
    public IUnitOfWork UnitOfWork  { get; }
    public AppSettings AppSettings { get; set; }

    public ContentsController(IUnitOfWork unitOfWork,IMapper mapper, IOptions<AppSettings> appSettings)
    {
      Mapper      = mapper;
      UnitOfWork  = unitOfWork;
      AppSettings = appSettings.Value;
    }

    // GET api/contents
    [HttpGet]
    // [Authorize(Policy="CanWriteCustomerData")]
      public JsonResult Get()
      {
        // return Json ( HttpContext.User.Identity.IsAuthenticated);
        // return Json(((ClaimsIdentity)HttpContext.User.Identity).FindFirst(ClaimTypes.Name));
        return Json(UnitOfWork.Contents.AllContents);
      }

    // GET api/Content/5
    [HttpGet("{id}")]
    public JsonResult Get(Guid id) => Json(UnitOfWork.Contents.GetContent(id));

    // POST api/contents
    [HttpPost]
    public string Post([FromBody]ContentViewModel model)
    {
      if(ModelState.IsValid)
      {
        UnitOfWork.Contents.AddContent(Mapper.Map<Content>(model));
        UnitOfWork.Save();
        return model.ToString();
      }
      return BadRequest(ModelState).ToString();
    }

    // PUT api/values/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody]string value)
    {
    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
  }
}
