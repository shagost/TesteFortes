using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteFortes.Application.ViewModels;

namespace TesteFortes.Application.Interfaces
{
    public interface IUserService
    {
        List<UserViewModel> Get();
        bool Post(UserViewModel userViewModel);
        UserViewModel GetById(int id);
        bool Put(UserUpdateViewModel userViewModel);
        bool Delete(int id);
    }
}
