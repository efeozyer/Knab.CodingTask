using System.ComponentModel.DataAnnotations;

namespace Knab.Platform.Persistence;

public abstract class EntityBase<TKey>
{
    [Key]
    public TKey Id { get; set; }
}