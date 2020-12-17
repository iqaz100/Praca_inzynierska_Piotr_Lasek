using Brutus_RestApi.Models;
using Brutus_RestApi.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brutus_RestApi.Repositories.Classes
{
    public class AbsenceRepository : IAbsenceRepository
    {
        private mydbContext context;
        public AbsenceRepository(mydbContext context)
        {
            this.context = context;
        }

        public void Add(Absence Contract)
        {
            throw new NotImplementedException();
        }

        public void Commit()
        {
            context.SaveChanges();
        }

        public void Delete(Absence Contract)
        {
            throw new NotImplementedException();
        }

        public Absence Get()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Absence> GetAll()
        {
            return context.Absence;
        }

        public IEnumerable<Absence> GetAllStudentAbsences(int studentId)
        {
            var allAbsences = context.Absence.Where(absence => absence.StudentsStudentId == studentId);
            return allAbsences;
        }

        public Absence ExcuseAbsence(int absenceId)
        {
            var absence = context.Absence.SingleOrDefault(x => x.AbsenceId == absenceId);
            if (absence == null)
            {
                return null;
            }
            else
            {
                context.Entry(absence).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                absence.Excused = "1";
                context.SaveChanges();
                return absence;
            }
        }

        public void Update(Absence Contract)
        {
            throw new NotImplementedException();
        }
    }
}
