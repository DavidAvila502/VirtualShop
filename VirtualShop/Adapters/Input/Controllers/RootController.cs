using Microsoft.AspNetCore.Mvc;

namespace VirtualShop.Adapters.Input.Controllers
{
    [Route("/")]
    [ApiController]
    public class RootController:ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(new
            {
               message="Welcome to virtualShop 1.0 API.", 
               description = "This is an example project of a API REST Hexagonal architecture.",
               documentation = "To see the documentation just add /swagger  to this URL."
                
            });

        }
    }
}
