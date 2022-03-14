namespace SocialMedia.WebApi.Responses
{
    //Esta es la clase que siempre vamos a retornar a través de
    //nuestra Api, osea, si insertó, elimino, actualizó, etc.,
    //para manejar una estructura estandar en todo
    public class ApiResponse<T>
    {
        public ApiResponse(T data)
        {
            Data = data;
        }

        //Es donde vamos a enviar el resultado especifico de
        //nuestra accion, osea que si se invoca el metodo de
        //obtener los post, entonces en la propiedad data es
        //donde se envian los posts, y para el delete seria
        // el true o false
        public T Data { get; set; }
    }
}
