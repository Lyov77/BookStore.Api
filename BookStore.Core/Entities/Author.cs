using BookStore.Core.Entities.Base;

namespace BookStore.Core.Entities
{
    public class Author : EntityBase
    {
        public required string Name { get; set; }
        public virtual ICollection<Book> Books { get; set; } = [];
    }
}