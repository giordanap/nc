using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SocialMedia.Api.Controllers
{
    //Este controlador se encargará de las publicaciones
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        //LocalRedirectResult ideal es tener un metodo por cada verbo http
        [HttpGet]
        public IActionResult GetPosts()
        {
            //Es para indicarle al API que cuando llegue a este punto
            //devuelva diferentes estados dependiendo de la operacion
            //se validaron o procesaron correctamente. Un Ok devuelve
            //un status 200 (todo funciono como se esperaba)
            return Ok(new { mensaje = "Todo OK" });
        }
    }
}
