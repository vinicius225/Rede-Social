using System.ComponentModel.DataAnnotations.Schema;

namespace Rede.Social.Server.Repository;

[Table(name:"users")]
public class User
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Document { get; set; }
    public string Country { get; set; }
    public int IdProfile { get; set; }
    public Profile Profile { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime DateUpdated { get; set; }
    public bool Status { get; set; }
}
