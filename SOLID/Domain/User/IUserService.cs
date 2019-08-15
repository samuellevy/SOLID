using SOLID.Domain.Service;
using SOLID.Domain.User;

namespace SOLID.Domain
{
    public interface IUserService : IService<UserModel, int>
    {
    }
}
