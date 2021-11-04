using Minly.Core.DTOs;
using Minly.Data;
using System.Threading.Tasks;

namespace Minly.Core.Services
{
    public interface IAuthManager
    {
        Task<bool> ValidateUser(LoginUserDTO userDTO);
        Task<ApiUser> GetUserByEmailAndPassword(LoginUserDTO userDTO);
        Task<string> CreateToken();
    }
}
