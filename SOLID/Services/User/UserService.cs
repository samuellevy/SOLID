using SOLID.Context;
using SOLID.Models.User;
using SOLID.ObjectValues.IdValue;
using System.Collections.Generic;
using System.Linq;

namespace SOLID.Services.User
{
    public class UserService : IUserService
    {
        private SolidDbContext _context;

        public UserService(SolidDbContext context)
        {
            _context = context;
        }

        public virtual IValue<int> Create(UserModel user)
        {
            _context.User.Add(user);
            var result = _context.SaveChanges();

            return new IdValue<int>(result);
        }

        public virtual bool Delete(int id)
        {
            var user = FindOne(id);

            if (user != null) {
                 _context.Remove(user);
                return true;
            }

            return false;
        }

        public virtual List<UserModel> FindAll()
        {
            return _context.User.ToList();
        }

        public virtual UserModel FindOne(int id)
        {
            return _context.User
               .SingleOrDefault(user => user.Id.Equals(id));
        }

        public virtual IValue<int> Update(int id, UserModel userDto)
        {
            var userEntity = FindOne(id);

            var result = _context.Update(userEntity).Entity;

            return new IdValue<int>(result.Id);
        }
    }
}
