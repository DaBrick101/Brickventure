using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Brickventure_Library.Environment;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace BrickventureWebAPI.Controllers
{
    
    [Microsoft.AspNetCore.Mvc.Route("api/brickventureAPI")]
    [ApiController]
    public class BrickventureAPIController : Controller
    {
        private IWorld _world;
        public BrickventureAPIController(IWorld world)
        {
            _world = world;
        }

        [HttpGet]
        public IWorld GetWorld()
        {
            return _world;
        }
    }
}
