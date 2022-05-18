using Microsoft.AspNetCore.Mvc;
using Project.Infra;
using AutoMapper;

namespace ProjectAPI.Controllers
{
  [Produces("application/json")]
  public class BaseController : Controller
  {

    public IMapper Mapper { get; }

    public IUnitOfWork UnitOfWork { get; }

    public BaseController(IUnitOfWork unitOfWork, IMapper mapper)
    {
      Mapper = mapper;
      UnitOfWork = unitOfWork;
    }
  }
}
