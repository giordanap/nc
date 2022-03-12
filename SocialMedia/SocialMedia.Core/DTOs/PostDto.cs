using System;

namespace SocialMedia.Core.DTOs
{
    public class PostDto
    { 
        public int PostId { get; set; }
        public int UserId { get; set; }
        //Una fecha por defecto no es nulo, siempre le entrega un valor por
        //defecto, por eso lo volvemos nulleable para recién poder
        //restringirlo, a´si que le agregamos el signo de pregunta
        public DateTime? Date { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
