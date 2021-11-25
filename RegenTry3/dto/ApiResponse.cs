namespace RegenTry3.dto
{
    public class ApiResponse<T>
    {
        public T Data { get; set; }
        public int StatusCode { get; set; }
        public string Description { get; set; }
    }
}
