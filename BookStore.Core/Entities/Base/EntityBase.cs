using System.ComponentModel.DataAnnotations;

namespace BookStore.Core.Entities.Base
{
    public abstract class EntityBase : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}