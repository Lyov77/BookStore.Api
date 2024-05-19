using BookStore.Core.Entities.Base;

namespace BookStore.Core.Entities
{
    public class Book : EntityBase
    {
        public required string Title { get; set; }
        public string? Description { get; set; }
        public bool IsAvailable { get; set; }
        public decimal Price { get; set; }

        public virtual Author? Author { get; set; }
        public int AuthorId { get; set; }
    }
}
