using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models;

public class Cart
{
    [Key]
    public int? CartId { get; set; }
    public int? ProductId { get; set; }
    public int? UserId { get; set; }
}