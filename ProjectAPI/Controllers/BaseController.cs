using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using Project.Infra;
using AutoMapper;

namespace ProjectAPI.Controllers
{
  [Produces("application/json")]
  [EnableCors("CorsPolicy")]
  public class BaseController : Controller
  {
    public IMapper Mapper { get;}
    public IUnitOfWork UnitOfWork { get; }
    public BaseController(IUnitOfWork unitOfWork,IMapper mapper) {
      Mapper = mapper;
      UnitOfWork = unitOfWork;
    }
  }
}
