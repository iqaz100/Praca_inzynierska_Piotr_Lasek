using Brutus_RestApi.Models;
using Brutus_RestApi.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brutus_RestApi.Repositories.Classes
{
    public class GradeRepository : IGradeRepository
    {
        private mydbContext context;
        public GradeRepository(mydbContext context)
        {
            this.context = context;
        }
        public void Add(Grade Contract)
        {
            context.Add<Grade>(Contract);
            this.Commit();
        }

        public void Commit()
        {
            context.SaveChanges();
        }

        public void Delete(Grade Contract)
        {
            var gradeToDelete = context.Grade.SingleOrDefault(x => x.GradeId == Contract.GradeId);
            if(gradeToDelete != null)
            {
                context.Entry(gradeToDelete).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                Commit();
            }
            
        }

        public Grade Get()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Grade> GetAll()
        {
            var grades = context.Grade.ToList();
            grades.ForEach(grade => { 
                grade.GradedefGradedef = context.Gradedef.Find(grade.GradedefGradedefId);
                grade.SubjectsSubject = context.Subject.Find(grade.SubjectsSubjectId);
            });
            return grades;
        }

        public IEnumerable<Grade> GetAllFromClass(int classId)
        {
            var studentsInClass = context.Student.Where(student => student.ClassesClassId == classId);
            var gradesInClass =
                from grades in GetAll()
                join students in studentsInClass on grades.StudentsStudentId equals students.StudentId
                join person in context.Person on students.PersonsPersonId equals person.PersonId
                select grades;
            return gradesInClass;
        }

        public IEnumerable<Grade> GetAllFromSubject(int subjectId)
        {
            return GetAll().Where(grades => grades.SubjectsSubjectId == subjectId);
        }

        public void Update(Grade Contract)
        {
            throw new NotImplementedException();
        }
    }
}
