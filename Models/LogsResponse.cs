namespace StringPorject.Models
{
    public class LogsResponse
    {
        public List<Log> Data { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }
    }
}
