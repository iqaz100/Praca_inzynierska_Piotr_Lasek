using AutoMapper;
using Brutus_RestApi.Contracts;
using Brutus_RestApi.Managers.Interfaces;
using Brutus_RestApi.Models;
using Brutus_RestApi.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brutus_RestApi.Managers.Classes
{
    public class GradesManager : IGradesManager
    {
        private readonly IGradeRepository gradeRepository;
        private readonly IPersonRepository personRepository;
        private readonly IStudentManager studentManager;
        private readonly IMapper mapper;

        public GradesManager(IGradeRepository gradeRepository, IPersonRepository personRepository, IStudentManager studentManager, IStudentRepository studentRepository, IMapper mapper)
        {
            this.mapper = mapper;
            this.gradeRepository = gradeRepository;
            this.personRepository = personRepository;
            this.studentManager = studentManager;
        }
        public void AddGrade(GradeAdd grade)
        {
            var newEntity = mapper.Map<Grade>(grade);
            newEntity.GradeDatetime = DateTime.Now;
            gradeRepository.Add(newEntity);
        }

        public void DeleteGrade(GradeDelete grade)
        {
            var deleteEntity = mapper.Map<Grade>(grade);
            gradeRepository.Delete(deleteEntity);
        }

        public IEnumerable<GradeStudentGroupedGet> GetAllFromClass(int classId, int subjectId)
        {
            var studentsGrades = mapper.Map<IEnumerable<GradeWithStudentGet>>(gradeRepository.GetAllFromClass(classId));
            var subjectGrades = GetAllSubjectGrades(subjectId);
            var students = studentManager.GetAll();
            var persons = personRepository.GetAll().ToList();
            var classSubjectGrades =
                from studentGrade in studentsGrades
                join subjectGrade in subjectGrades on studentGrade.GradeId equals subjectGrade.GradeId
                join student in students on studentGrade.StudentId equals student.StudentId
                join person in persons on student.PersonsPersonId equals person.PersonId
                select new GradeWithStudentGet { 
                    FirstName = person.FirstName,
                    LastName = person.LastName,
                    GradeDatetime = studentGrade.GradeDatetime,
                    StudentId = studentGrade.StudentId,
                    SubjectName = studentGrade.SubjectName,
                    GradeScale = studentGrade.GradeScale,
                    GradeId = studentGrade.GradeId,
                    GradeType = studentGrade.GradeType,
                    GradeValue = studentGrade.GradeValue
                };
            var query = from grades in classSubjectGrades
                        group grades by new { grades.StudentId, grades.FirstName, grades.LastName }
                        into grp
                        select new GradeStudentGroupedGet
                        {
                            studentId = grp.Key.StudentId,
                            firstName = grp.Key.FirstName,
                            lastName = grp.Key.LastName,
                            grades = grp.ToList()
                        };
            return query;
        }

        public decimal GetAverageGrade(int studentId, int subjectId)
        {
            var studentsGrades = mapper.Map<IEnumerable<GradeGet>>(gradeRepository.GetAll().Where(x => x.StudentsStudentId == studentId && x.SubjectsSubjectId == subjectId));
            decimal average = 0;
            int scaleAmount = 0;
            foreach (var item in studentsGrades)
            {
                scaleAmount += item.GradeScale;
                average += item.GradeValue * item.GradeScale;
            }
            return decimal.Round(average / scaleAmount, 2);
        }

        public IEnumerable<GradeGroupedGet> GetAllStudentGrades(int studentId)
        {
            var studentsGrades = mapper.Map<IEnumerable<GradeGet>>(gradeRepository.GetAll().Where(x => x.StudentsStudentId == studentId));
            var groupedGrades = studentsGrades.GroupBy(
                x => x.SubjectName,
                (key, g) => new GradeGroupedGet { key = key, grades = g.ToList() }
            );
            return groupedGrades;
        }

        public IEnumerable<GradeGet> GetAllSubjectGrades(int subjectId)
        {
            var grades = mapper.Map<IEnumerable<GradeGet>>(gradeRepository.GetAllFromSubject(subjectId));
            return grades;
        }
    }
}
