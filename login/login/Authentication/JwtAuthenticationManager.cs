using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using login.Authentication;
using Microsoft.IdentityModel.Tokens;

public class JwtAuthenticationManager : IJwtAuthenticationManager
{
    private readonly string _secretKey;

    public JwtAuthenticationManager(string secretKey)
    {
        _secretKey = secretKey;
    }

    public string GenerateToken(string username)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_secretKey);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[] { new Claim("username", username) }),
            Expires = DateTime.UtcNow.AddHours(1),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    // Método para autenticar o usuário (pode ser substituído por uma consulta ao banco de dados)
    //public bool Authenticate(string username, string password)
    //{
    //    // Lógica de autenticação aqui (por exemplo, verificar no banco de dados)
    //    // Se o usuário for autenticado com sucesso, retorne true; caso contrário, retorne false.
    //    return username == "usuario" && password == "senha"; // Exemplo simples de autenticação, NÃO utilize em produção!
    //}
}
