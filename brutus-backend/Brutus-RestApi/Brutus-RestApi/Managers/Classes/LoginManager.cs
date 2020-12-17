using AutoMapper;
using Brutus_RestApi.Contracts;
using Brutus_RestApi.Managers.Interfaces;
using Brutus_RestApi.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brutus_RestApi.Managers.Classes
{
    public class LoginManager : ILoginManager
    {
        private readonly ILoginRepository loginRepository;
        private readonly IMapper mapper;

        public LoginManager(ILoginRepository loginRepository, IMapper mapper)
        {
            this.loginRepository = loginRepository;
            this.mapper = mapper;
        }
        public LoginGet AuthUser(string name, int pesel)
        {
            var auth = loginRepository.AuthUser(name, pesel);
            if(auth.Item1 < 0 || auth.Item2 < 0)
            {
                return null;
            }
            var user = new LoginGet { Id = auth.Item2, TypeId = auth.Item1, FirstName = auth.Item3, LastName = auth.Item4 };
            return user;
        }

        public LoginGet AuthUser2(string login, string password)
        {
            var auth = loginRepository.AuthUser2(login, password);
            if (auth.Item1 < 0 || auth.Item2 < 0)
            {
                return null;
            }
            var user = new LoginGet { Id = auth.Item2, TypeId = auth.Item1, FirstName = auth.Item3, LastName = auth.Item4 };
            return user;
        }

        public AccountGet ChangePassword(string login, string oldPassword, string newPassword)
        {
            var acc = loginRepository.ChangePassword(login, oldPassword, newPassword);
            var user = new AccountGet { LoginId = acc.LoginId, Login = acc.LoginId, Password = acc.Password };
            return user;
        }
    }
}
