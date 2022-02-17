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
    }
}