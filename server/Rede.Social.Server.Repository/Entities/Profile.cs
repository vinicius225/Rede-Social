using System.ComponentModel.DataAnnotations.Schema;

namespace Rede.Social.Server.Repository;

[Table(name:"profiles")]
public class Profile
{
public string Id { get; set; }
public string Name { get; set; }
public string Description { get; set; }
public DateTime DateCreated { get; set; }
public DateTime DateUpdated { get; set; }
}
