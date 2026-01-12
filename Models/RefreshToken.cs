using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserCRUDandJWT.Models;

public class RefreshToken
{
    public int Id { get; set; }

    [Required]
    public string Token { get; set; } = null!;

    public DateTime ExpiresAt { get; set; }

    public bool IsRevoked { get; set; } = false;

    // 🔹 Foreign key
    public int UserId { get; set; }

    // 🔹 Navigation property
    public User User { get; set; } = null!;
}
