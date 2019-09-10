using SOLID.Models.User;
using SOLID.Service;

namespace SOLID.Services.User
{
    public interface IUserService : IService<UserModel, int>
    {
    }
}
