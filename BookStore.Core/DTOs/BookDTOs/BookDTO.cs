namespace BookStore.Core.DTOs.BookDTOs
{
    public class BookDTO : BaseBookDTO
    {
        public int Id { get; set; }
        public string? Author { get; set; }
    }
}
