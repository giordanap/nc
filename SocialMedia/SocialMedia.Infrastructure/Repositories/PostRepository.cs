﻿using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMedia.Infrastructure.Repositories
{
    //Ahora indicamos que nuestra clase va a implementar
    //la interfaz
    public class PostRepository : IPostRepository
    {
        //Todos los metodos que esperan, usando el await,
        //deben ser asincronos
        public async Task<IEnumerable<Post>> GetPosts()
        {
            var posts = Enumerable.Range(1, 10).Select(x => new Post
            {
                PostId = x,
                Description = $"Description {x}",
                Date = DateTime.Now,
                Image = $"https://misapis.com/{x}",
                UserId = x * 2
            });

            //vamos a simular que este es un metodo
            //asincrono
            await Task.Delay(10);

            return posts;
        }
    }
}