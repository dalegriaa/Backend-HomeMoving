namespace Transversal.Common
{

    // esta entidad contiene toda la informacion de los recursos que contiente nuestra web api
    public class Response<T>
    {
        // data contiene la informacion de los diversos metodos, respuestas de los metodos
        public T Data { get; set; }
        // informacion de la ejecucion de todos los metodos
        public bool IsSuccess { get; set; }
        //informacion de errores
        public string Message { get; set; }
    }
}
