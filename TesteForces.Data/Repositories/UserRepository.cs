using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteFortes.Data.Context;
using TesteFortes.Domain.Entities;
using TesteFortes.Domain.Interfaces;

namespace TesteFortes.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }

        public IEnumerable<User> GetAll()
        {
            return Query(x => x.IsActive);
        }

        public new bool Delete(User user)
        {
            user.UpdatedData = DateTime.Now;
            user.IsActive = false;
            return this.Update(user);
        }
    }
}
