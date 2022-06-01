using Microsoft.AspNetCore.Mvc;
using Project.Services;
using Microsoft.AspNetCore.Authorization;

namespace ProjectAPI.Controllers
{
  [Produces("application/json")]
  [Route("api/Folders")]
  [Authorize]
  public class FoldersController : Controller
  {
    private readonly IFolderService _folderService;

    public FoldersController(IFolderService folderService)
    {
      _folderService = folderService;
    }

    // GET api/folders
    [HttpGet]
    public JsonResult Get()
    {
      return Json(_folderService.GetAllFolders());
    }
  }
}
