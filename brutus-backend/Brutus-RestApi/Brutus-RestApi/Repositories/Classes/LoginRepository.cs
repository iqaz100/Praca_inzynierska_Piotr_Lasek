using Brutus_RestApi.Models;
using Brutus_RestApi.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brutus_RestApi.Repositories.Classes
{
    public class LoginRepository : ILoginRepository
    {
        private mydbContext context;

        public LoginRepository(mydbContext context)
        {
            this.context = context;
        }
        public (int, int, string, string) AuthUser(string name, int pesel)
        {
            var person = context.Person.FirstOrDefault(person => person.FirstName == name && person.Pesel == pesel);
            var student = context.Student.FirstOrDefault(student => student.PersonsPersonId == person.PersonId);
            var teacher = context.Teacher.FirstOrDefault(student => student.PersonsPersonId == person.PersonId);
            var parents = context.Parent.FirstOrDefault(student => student.PersonsPersonId == person.PersonId);
            if (student != null)
            {
                return (0, student.StudentId, person.FirstName, person.LastName);
            }
            if (teacher != null)
            {
                return (1, teacher.TeacherId, person.FirstName, person.LastName);
            }
            if (parents != null)
            {
                return (2, parents.ParentId, person.FirstName, person.LastName);
            }
            return (-1, -1, "","");
        }

        public (int, int, string, string) AuthUser2(string login, string password)
        {
            var login1 = context.Login.FirstOrDefault(login1 => login1.Login1 == login && login1.Password == password);
            var person = context.Person.FirstOrDefault(person => person.LoginLoginId == login1.LoginId);
            var student = context.Student.FirstOrDefault(student => student.PersonsPersonId == person.PersonId);
            var teacher = context.Teacher.FirstOrDefault(student => student.PersonsPersonId == person.PersonId);
            var parents = context.Parent.FirstOrDefault(student => student.PersonsPersonId == person.PersonId);
            if (student != null)
            {
                return (0, student.StudentId, person.FirstName, person.LastName);
            }
            if (teacher != null)
            {
                return (1, teacher.TeacherId, person.FirstName, person.LastName);
            }
            if (parents != null)
            {
                return (2, parents.ParentId, person.FirstName, person.LastName);
            }
            return (-1, -1, "", "");
        }

        public Login ChangePassword(string login, string oldPassword, string newPassword)
        {
            var vlogin = context.Login.SingleOrDefault(x => x.Login1 == login && x.Password == oldPassword);
            if (vlogin == null)
            {
                return null;
            }
            else
            {
                context.Entry(vlogin).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                vlogin.Password = newPassword;
 
                context.SaveChanges();
                return vlogin;
            }
        }
    }
}
