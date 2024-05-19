using System.ComponentModel.DataAnnotations;

namespace BookStore.Core.DTOs.BookDTOs
{
    public class BaseBookDTO
    {
        public required string Title { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
    }
}
