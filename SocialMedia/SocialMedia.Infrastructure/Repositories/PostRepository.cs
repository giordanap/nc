using Microsoft.EntityFrameworkCore;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;
using SocialMedia.Infrastructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialMedia.Infrastructure.Repositories
{
    //Ahora indicamos que nuestra clase va a implementar
    //la interfaz
    public class PostRepository : IPostRepository
    {
        //Vamos a utilizar inyeccion de dependencia para
        //inyectar nuestro contexto de base de datos
        private readonly SocialMediaContext _context;

        public PostRepository(SocialMediaContext context)
        {
            _context = context;
        }

        //Todos los metodos que esperan, usando el await,
        //deben ser asincronos
        public async Task<IEnumerable<Post>> GetPosts()
        {
            var posts = await _context.Posts.ToListAsync();

            return posts;
        }

        //Para que la funcionalidad sea accesible, debe
        //estar mapeada en la interfaz
        public async Task<Post> GetPost(int id)
        {
            var post = await _context.Posts.FirstOrDefaultAsync(x=> x.PostId == id);

            return post;
        }

        //Creamos nuestro metodo en la base de datos,
        //en este caso, en el repositorio. Haremos el
        //insertado, pero sin hacer validaciones. Estas
        //validaciones ya se verán más adelante.
        public async Task InsertPost(Post post)
        {
            //Generamos contexto en la tabla de posts,
            //vamos a agregar un nuevo post, que es
            //este objeto que estamos recibiendo como
            //parámetro
            _context.Posts.Add(post);
            //Luego, una ves lo agregamos, vamos a
            //decirle que queremos guardar los cambios,
            //y lo hacemos con context, save changes
            //y lo hacemos asincronos
            await _context.SaveChangesAsync();
        }
    }
}