using Microsoft.EntityFrameworkCore;
using SOLID.Context;
using SOLID.Domain.IdValue;
using SOLID.Domain.Service;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SOLID.Domain.User
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

        public bool Delete(int id)
        {
            var user = FindOne(id);

            if (user != null) {
                 _context.Remove(user);
                return true;
            }

            return false;
        }

        public List<UserModel> FindAll()
        {
            return _context.User.ToList();
        }

        public UserModel FindOne(int id)
        {
            return _context.User
               .SingleOrDefault(user => user.Id.Equals(id));
        }

        public IValue<int> Update(int id, UserModel userDto)
        {
            var userEntity = _context.User
                .Where(user => user.Id.Equals(id))
                .First();

            var result = _context.Update(userEntity).Entity;

            return new IdValue<int>(result.Id);
        }
    }
}
