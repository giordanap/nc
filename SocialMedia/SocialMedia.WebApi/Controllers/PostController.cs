using Microsoft.AspNetCore.Mvc;
using SocialMedia.Core.Interfaces;
using SocialMedia.Infrastructure.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SocialMedia.Api.Controllers
{
    //Este controlador se encargará de las publicaciones
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostRepository _postRepository;

        public PostController(IPostRepository)
        {

        }

        //LocalRedirectResult ideal es tener un metodo por cada verbo http
        [HttpGet]
        public IActionResult GetPosts()
        {
            //Es para indicarle al API que cuando llegue a este punto
            //devuelva diferentes estados dependiendo de la operacion
            //se validaron o procesaron correctamente. Un Ok devuelve
            //un status 200 (todo funciono como se esperaba)

            //Aqui estamos acoplando fueretemente el controlador al
            //respositorio, por lo que estariamos incumpliendo el
            //ultimo principio SOLID (Inyeccion de dependencias)
            //Este principio nos habla de que las clases no deberian
            //depender de implementaciones concretas, sino de
            //abstracciones. Asi la ID nos permite no usar la clase
            //para crear el objeto sino que sea inyectado.

            //Como objetivo buscamos un bajo acoplamiento y una alta
            //cohesion, es decir que en cuanto al acoplamiento, queremos
            //que nuestras clases dependan lo menos de otras, esto lo
            //logramos usando abstracciones (ID, usando interfaces),
            //nos sirven para las pruebas unitarias, ya que podemos
            //crear mocks, para simular data y no tener que ir a la BD
            //cuando no es este el deber de una prueba unitaria, sino
            //que podamos usar mocks o diferentes frameworks para
            //simular esto, a su vez, permite que el software sea
            //mantenible en el tiempo, desentendiendonos de la
            //implementacion completa, es decir: si nos conectamos a
            //SQL Server, será muy fácil conectarnos a una BD de Oracle,
            //Mongo, etc., y el controlador que está haciendo uso del
            //repositorio no tendrá que ser modificado.
            //Para poder trabajar con Inyeccion de dependencias,
            //debemos trabajar con abstracciones, lo que se traduce
            //como Interfaces, esto se hace en el proyecto Core.

            //Desde que tenemos la palabra new, ya nos damos cuenta
            //que tenemos una alta dependencia, de una implementacion
            //en concreto. Entonces, en lugar de new, todo lo debemos
            //hacer por inyeccion de dependencias

            //Hay diferentes tipos o approach para inyectar
            //dependencias en una clase. La forma más concida y que
            //usaremos es inyeccion via constructor, esto es:
            //En el momento que se va a instanciar una clase, se
            //le pasan los objetos que de este dependan
            var posts = new PostRepository().GetPosts();
            return Ok(posts);
        }
    }
}
