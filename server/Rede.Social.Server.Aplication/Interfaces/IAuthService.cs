namespace Rede.Social.Server.Aplication;

public interface IAuthService
{
    Task<UserLoginResponseDTO> UserLogin(UserLoginRequestDTO userLogin);
}
