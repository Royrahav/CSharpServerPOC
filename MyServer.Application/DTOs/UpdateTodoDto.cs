using System.ComponentModel.DataAnnotations;

namespace MyServer.Application.DTOs
{
    public class UpdateTodoDto
    {
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Title { get; set; } = string.Empty;

        public bool IsCompleted { get; set; }
    }
}
