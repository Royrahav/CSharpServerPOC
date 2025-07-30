using System.ComponentModel.DataAnnotations;

namespace MyServer.Application.DTOs
{
    public class CreateTodoDto
    {
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Title { get; set; } = string.Empty;
    }
}
