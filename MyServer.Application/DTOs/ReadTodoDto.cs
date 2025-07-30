namespace MyServer.Application.DTOs
{
    public class ReadTodoDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public bool IsCompleted { get; set; }
    }
}
