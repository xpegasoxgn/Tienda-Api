namespace Tienda.API.ResponseApi
{
    public class ResponseApi<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }=string.Empty;
        public T? Data { get; set; }
        public List<string>
            Errors
        { get; set; } = new List<string>();
        public DateTime Fecha { get; set; } = DateTime.Now;
    }
}
