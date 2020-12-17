using Brutus_RestApi.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brutus_RestApi.Managers.Interfaces
{
    public interface ILoginManager
    {
        LoginGet AuthUser(string name, int pesel);

        LoginGet AuthUser2(string login, string password);

        AccountGet ChangePassword(string login, string oldPassword, string newPassword);
    }
}
