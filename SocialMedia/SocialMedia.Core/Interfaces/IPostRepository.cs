using SocialMedia.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialMedia.Core.Interfaces
{
    public interface IPostRepository
    {
        //Esta interfaz nos va a representar las operaciones
        //que vamos a tener con la BD para el tema de las
        //publicaciones. Teniendo en cuenta que las interfaces
        //es solo como si fuera un contrato, por eso es que
        //aqui es donde definimos los metodos que debemos
        //implementar aquella clases que estén implementando
        //esta interfaz.

        //Manejaremos metodos asincronos en donde se pueda
        //(e.g. task)

        Task<IEnumerable<Post>> GetPosts();
        Task<Post> GetPost(int id);
        Task InsertPost(Post post);
        Task<bool> UpdatePost(Post post);
        Task<bool> DeletePost(int id);
    }
}
