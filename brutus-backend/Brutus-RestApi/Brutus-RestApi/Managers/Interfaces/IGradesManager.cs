using Brutus_RestApi.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brutus_RestApi.Managers.Interfaces
{
    public interface IGradesManager
    {
        void AddGrade(GradeAdd grade);
        IEnumerable<GradeGroupedGet> GetAllStudentGrades(int studentId);
        IEnumerable<GradeGet> GetAllSubjectGrades(int subjectId);
        IEnumerable<GradeStudentGroupedGet> GetAllFromClass(int classId, int subjectId);
        void DeleteGrade(GradeDelete grade);
        decimal GetAverageGrade(int studentId, int subjectId);
    }
}
