using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Core.DTOs;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;
using SocialMedia.WebApi.Responses;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SocialMedia.Api.Controllers
{
    //Este controlador se encargará de las publicaciones
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        //De en adelante se van a trabjar con las abstracciones y no
        //con las implementaciones propias
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        //Antes de crear el controlador (controlador del Post)
        //alguien me tiene que decir cual es el repositorio
        //que debo de usar, siendo este el principio basico de
        //la inyeccion de dependencia, que es decidir, en algun
        //punto de la aplicacion, las implementaciones concretas
        //que se van a utilizar para las abstracciones que
        //estamos referenciando, siendo en este caso una
        //interfaz que es del repositorio. Entonces, para que
        //este controlador funcione, debe existir un
        //repositorio (tenemos 2 SQL y Mongo)
        public PostController(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        //LocalRedirectResult ideal es tener un metodo por cada verbo http
        [HttpGet]
        //Como ya se cambio la implementacion y se esta trabajando
        //con metodos asincronos, la respuesta nos devuelve un
        //available, que es un task
        public async Task<IActionResult> GetPosts()
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


            //var posts = new PostRepository().GetPosts();

            //Ya con el constructor nos deshacemos del new, quitando
            //el acoplamiento, y trabajamos con abastraciones

            //Con el await ya esperamos a que el metodo se resuelva
            var posts = await _postRepository.GetPosts();
            var postsDto = _mapper.Map<IEnumerable<PostDto>>(posts);
            var response = new ApiResponse<IEnumerable<PostDto>>(postsDto);
            
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPost(int id)
        {
            var post = await _postRepository.GetPost(id);
            var postDto = _mapper.Map<PostDto>(post);

            return Ok(post);
        }

        //Para hacer el insert de nuestro post, debemos hace uso
        //de un nuevo metodo. El nombre del metodo puede ser cualquiera
        //porque accederemos a él a través del verbo http y no
        //del metodo
        //Los Post que envian los GET son post de las entidades de
        //dominio, por eso trata de pintar el usuario y los comentarios
        //en el postman cuando le pone null
        [HttpPost]
        public async Task<IActionResult> Post(PostDto postDto)
        {
            var post = _mapper.Map<Post>(postDto);

            await _postRepository.InsertPost(post);

            postDto = _mapper.Map<PostDto>(post);
            var response = new ApiResponse<PostDto>(postDto);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, PostDto postDto)
        {
            var post = _mapper.Map<Post>(postDto);
            post.PostId = id;
            
            var result = await _postRepository.UpdatePost(post);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _postRepository.DeletePost(id);
            var response = new ApiResponse<bool>(result);

            return Ok(response);
        }
    }
}
