using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteFortes.Application.Interfaces;
using TesteFortes.Application.ViewModels;
using TesteFortes.Domain.Entities;
using TesteFortes.Domain.Interfaces;
using ValidationContect = System.ComponentModel.DataAnnotations.ValidationContext;

namespace TesteFortes.Application.Services
{
    public class UserService : IUserService
    {
        protected readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public List<UserViewModel> Get()
        {
            List<UserViewModel> viewModel = new List<UserViewModel>();
            IEnumerable<User> users = _userRepository.GetAll();
            viewModel = _mapper.Map<List<UserViewModel>>(users); 

            return viewModel;
        }

        public bool Post(UserViewModel userViewModel)
        {
            if (userViewModel.UserId != 0)
                throw new Exception("Id is not empty!");

            Validator.ValidateObject(userViewModel, new ValidationContext(userViewModel), true);

            User user = _mapper.Map<User>(userViewModel);
            _userRepository.Create(user);
            return true;
        }

        public UserViewModel GetById(int id)
        {
            if(id <= 0)
                throw new Exception("Id is not valid!");

            var user = _userRepository.Find(x => x.UserId == id && x.IsActive);
            if (user == null)
                throw new Exception("User not found!");
            return _mapper.Map<UserViewModel>(user);
        }

        public bool Put(UserUpdateViewModel userViewModel)
        {
            if(userViewModel.UserId == 0)
                throw new Exception("User not found!");

            var user = _userRepository.Find(x => x.UserId == userViewModel.UserId && x.IsActive);
            if (user == null)
                throw new Exception("User not found!");

            userViewModel.CreatedDate = user.CreatedDate;
            userViewModel.UpdatedData = DateTime.Now;
            userViewModel.IsActive = user.IsActive;

            user = _mapper.Map<User>(userViewModel);
            _userRepository.Update(user);
            return true;
        }

        public bool Delete(int id)
        {
            var user = _userRepository.Find(x => x.UserId == id && x.IsActive);
            if (user == null)
                throw new Exception("User not found!");
            return _userRepository.Delete(user);
        }
    }
}
