using Microsoft.AspNetCore.Mvc;
using ProjectAPI.Services;
using Microsoft.AspNetCore.Authorization;

namespace ProjectAPI.Controllers
{
  [Produces("application/json")]
  [Route("api/[controller]")]
  [Authorize]
  [ApiVersion("1.0")]
  public class MoviesController : Controller
  {
    public IMovieService MovieSerice { get; set; }
    public MoviesController(IMovieService movieService)
    {
      this.MovieSerice = movieService;
    }

    [HttpGet]
    // [Authorize(Policy="CanWriteCustomerData")]
      public JsonResult Get()
      {
        return Json(this.MovieSerice.GetPopular());
      }
  }
}
