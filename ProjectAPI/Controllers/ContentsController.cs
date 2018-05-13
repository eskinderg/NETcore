using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Project.Services;
using Project.Model.Models;
using AutoMapper;
using Project.Model.ViewModels;
using Project.Infra;

namespace ProjectAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [EnableCors("CorsPolicy")]
    [Authorize]
    [ApiVersion("1.0")]
    public class ContentsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ContentsController(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        // GET api/contents
        [HttpGet]
        [Authorize(Policy="CanWriteCustomerData")]
        public JsonResult Get()
        {
            return Json(_unitOfWork.Contents.GetAllContents());
        }

        // GET api/Content/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            return Json(_unitOfWork.Contents.GetContent(id));
        }

        // POST api/contents
        [HttpPost]
        public ContentViewModel Post([FromBody]Content content)
        {
            if (content == null)
                return null;

            _unitOfWork.Contents.AddContent(content);
            _unitOfWork.Save();

            return _mapper.Map<ContentViewModel>(content);
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
