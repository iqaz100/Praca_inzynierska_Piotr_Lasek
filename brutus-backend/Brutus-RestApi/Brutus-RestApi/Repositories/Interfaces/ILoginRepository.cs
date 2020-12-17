using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Brutus_RestApi.Models;

namespace Brutus_RestApi.Repositories.Interfaces
{
    public interface ILoginRepository
    {
        (int, int, string, string) AuthUser(string name, int pesel);
        (int, int, string, string) AuthUser2(string login, string password);

        Login ChangePassword(string login, string oldPassword, string newPassword);

    }


}
