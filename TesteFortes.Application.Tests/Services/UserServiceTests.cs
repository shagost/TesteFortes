using AutoMapper;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteFortes.Application.AutoMapper;
using TesteFortes.Application.Services;
using TesteFortes.Application.ViewModels;
using TesteFortes.Domain.Entities;
using TesteFortes.Domain.Interfaces;
using Xunit;

namespace TesteFortes.Application.Tests.Services
{
    public class UserServiceTests
    {
        private UserService _userService;

        public UserServiceTests()
        {
            _userService = new UserService(new Mock<IUserRepository>().Object,
                new Mock<IMapper>().Object);
        }

        [Fact]
        public void Post_SendingValidId()
        {
            var exc = Assert.Throws<Exception>(() => _userService.Post(new UserViewModel { UserId = 4 }));
            Assert.Equal("Id is not empty!", exc.Message);
        }

        [Fact]
        public void GetById_SendingEmptyId()
        {
            var exc = Assert.Throws<Exception>(() => _userService.GetById(0));
            Assert.Equal("Id is not valid!", exc.Message);
        }

        [Fact]
        public void Put_SendingEmptyId()
        {
            var exc = Assert.Throws<Exception>(() => _userService.Put(new UserUpdateViewModel()));
            Assert.Equal("User not found!", exc.Message);
        }

        [Fact]
        public void Delete_SendingEmptyId()
        {
            var exc = Assert.Throws<Exception>(() => _userService.Delete(0));
            Assert.Equal("User not found!", exc.Message);
        }

        [Fact]
        public void Post_SendingValidObject()
        {
            var result = _userService.Post(new UserViewModel { Name = "João Santos" });
            Assert.True(result);
        }

        [Fact]
        public void Get_ValidatingObject()
        {
            List<User> users = new List<User>();
            users.Add(new User { UserId = 20, Name = "João Santos", CreatedDate = DateTime.Now });

            var userRep = new Mock<IUserRepository>();
            userRep.Setup(x => x.GetAll()).Returns(users);

            var automapperprofile = new AutoMapperConfig();
            var config = new MapperConfiguration(x => x.AddProfile(automapperprofile));
            IMapper _mapper = new Mapper(config);

            _userService = new UserService(userRep.Object, _mapper);
            var result = _userService.Get();
            Assert.True(result.Count > 0);
        }

        [Fact]
        public void Post_SendingInvalidObject()
        {
            var exc = Assert.Throws<ValidationException>(() => _userService.Post(new UserViewModel()));
            Assert.Equal("The Name field is required.", exc.Message);
        }
    }
}
