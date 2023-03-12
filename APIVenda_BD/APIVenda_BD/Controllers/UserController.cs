using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APIVenda_BD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet("public")]
        public IActionResult Public()
        {
            return Ok("LOCAL Publico");
        }


        [HttpGet("autoriza")]
        [Authorize]
        public IActionResult vendasGrafico()
        {
            //var currentVenda = 
            return Ok("autorizado com Token");
        }

    }

}
