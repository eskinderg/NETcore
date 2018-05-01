using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Project.Services;
using Project.Model.Models;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using System;
using System.Text;
using AutoMapper;
using Project.Model.ViewModels;

namespace ProjectAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [EnableCors("CorsPolicy")]
    //[Authorize]
    public class ContentsController : Controller
    {
        private readonly IContentService _contentService;
        private readonly IMapper _mapper;

        public ContentsController(IContentService contentService,IMapper mapper)
        {
            _mapper = mapper;
            _contentService = contentService;
        }

        // GET api/contents
        [HttpGet]
        // [Authorize]
        public JsonResult Get()
        {
            return Json(_contentService.GetAllContents());
        }

        // GET api/Content/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            return Json(_contentService.GetContent(id));
        }

        // POST api/contents
        [HttpPost]
        public ContentViewModel Post([FromBody]Content content)
        {
            if (content == null)
                return null;
            _contentService.AddContent(content);
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
