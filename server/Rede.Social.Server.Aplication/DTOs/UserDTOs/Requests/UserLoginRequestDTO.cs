using System.ComponentModel.DataAnnotations;

namespace Rede.Social.Server.Aplication;

public class UserLoginRequestDTO
{
    [Required]
    public string Login { get; set; }
    [Required]
    public string Password { get; set; }
}
