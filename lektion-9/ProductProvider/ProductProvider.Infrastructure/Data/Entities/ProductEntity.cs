using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductProvider.Infrastructure.Data.Entities;

public class ProductEntity
{
    [Key]
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Title { get; set; } = null!;

    [Column(TypeName = "money")]
    public decimal Price { get; set; }
}
