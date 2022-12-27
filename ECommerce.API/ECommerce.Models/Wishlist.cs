using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models;
public class Wishlist 
{
    [Key]
    public int? WishlistId { get; set; }
    public int? ProductId { get; set; }
    public int? UserId { get; set; }
}