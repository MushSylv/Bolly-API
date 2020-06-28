using BollyApi.Repository.Abstractions.Users;
using BollyApi.Repository.Models.Users;
using Microsoft.Extensions.Options;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BollyAPI.Mock.Users
{
    public class MockUserRepository : IUserRepository
    {
        private readonly MockUsers _mock;

        public MockUserRepository(IOptions<MockUsers> mock) => _mock = mock.Value;
        public User GetUser(string login) => _mock.Users.SingleOrDefault(user => user.Login == login);
    }
}
