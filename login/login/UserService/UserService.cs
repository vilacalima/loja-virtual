using login.Model;
using System.Text.RegularExpressions;

namespace login.UserService
{
    public class UserService : IUserService
    {
        private readonly IUserService _userService;

        public UserService(IUserService userService)
        {
            _userService = userService;
        }

        public bool IsValidUser(string email, string password)
        {
            if (email == null || password == null) { /*adicionar validação*/} 

            //Validar email
            //validar senha
            //chamar banco de dados

            return email == "usuario" && password == "senha";
        }

        /// <summary>
        /// Registrando novo usuário
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<bool> RegisterNewUser(User user)
        {
            try
            {
                if(user != null)
                {
                    if (!ValidateCPF(user.Cpf) || user.Cpf == null)
                    {
                        throw new Exception("Cpf Invalido!");
                    }

                    if(!ValidateEmail(user.Email) || user.Email == null)
                    {
                        throw new Exception("Email Invalido!");
                    }

                    if (!ValidatePassword(user.Password) || user.Password == null)
                    {
                        throw new Exception("Digite uma senha forte");
                    }
                }

                _userService.RegisterNewUser(user);

                return Task.FromResult(true);
            } catch (Exception ex) 
            { 
                throw ex;
            }
        }

        /// <summary>
        /// Valida o cpf
        /// </summary>
        /// <param name="cpf"></param>
        /// <returns></returns>
        private static bool ValidateCPF(string cpf)
        {
            cpf = new string(cpf.Where(char.IsDigit).ToArray());

            if (cpf.Length != 11)
                return false;

            if (cpf.Distinct().Count() == 1)
                return false;

            int[] multiplicadores1 = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicadores2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            string tempCpf = cpf.Substring(0, 9);
            int soma = 0;
            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicadores1[i];

            int resto = soma % 11;
            int digito1 = resto < 2 ? 0 : 11 - resto;

            tempCpf += digito1;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicadores2[i];

            resto = soma % 11;
            int digito2 = resto < 2 ? 0 : 11 - resto;

            return cpf.EndsWith(digito1.ToString() + digito2.ToString());
        }

        /// <summary>
        /// Valida email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        private static bool ValidateEmail(string email)
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            Match match = Regex.Match(email, pattern);

            return match.Success;
        }

        /// <summary>
        /// Valida Senha forte
        /// </summary>
        /// <param name="senha"></param>
        /// <returns></returns>
        private static bool ValidatePassword(string password)
        {
            if (password.Length < 8) return false;

            if (!password.Any(char.IsUpper)) return false;

            if (!password.Any(char.IsLower)) return false;

            if (!password.Any(char.IsDigit)) return false;

            if (!password.Any(c => !char.IsLetterOrDigit(c))) return false;

            return true;
        }
    }
}
