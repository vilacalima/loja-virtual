using login.Model;
using login.DTO;

public static class UserMapHelpers
{
    public static User UserMap(UserDTO usuarioDTO)
    {
        if (usuarioDTO == null)
            return null;

        return new User
        {
            Name = usuarioDTO.NomeUsuario,
            Cpf = usuarioDTO.CPF,
            Email = usuarioDTO.Email,
            Password = usuarioDTO.Senha
        };
    }
}