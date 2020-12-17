using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brutus_RestApi
{
    using AutoMapper;
    using Brutus_RestApi.Contracts;
    using Brutus_RestApi.Models;

    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Class, ClassGet>();
            CreateMap<Subject, SubjectGet>();
            CreateMap<BehaviorAdd, Behavior>()
                .ForMember(dest => dest.Behavior1, act => act.MapFrom(src => src.BehaviorDescription))
                .ForMember(dest => dest.StudentsStudentId, act => act.MapFrom(src => src.StudentId));
            CreateMap<Behavior, BehaviorGet>()
                .ForMember(dest => dest.BehaviorDescription, act => act.MapFrom(src => src.Behavior1))
                .ForMember(dest => dest.StudentId, act => act.MapFrom(src => src.StudentsStudentId));

            CreateMap<Absence, AbsenceGet>();
            CreateMap<Student, StudentGet> ();
            CreateMap<Grade, GradeGet>()
                .ForMember(dest => dest.GradeValue, act => act.MapFrom(src => src.GradedefGradedef.Grade))
                .ForMember(dest => dest.SubjectName, act => act.MapFrom(src => src.SubjectsSubject.SubjectName));
            CreateMap<Grade, GradeWithStudentGet>()
                .ForMember(dest => dest.GradeValue, act => act.MapFrom(src => src.GradedefGradedef.Grade))
                .ForMember(dest => dest.SubjectName, act => act.MapFrom(src => src.SubjectsSubject.SubjectName))
                .ForMember(dest => dest.StudentId, act => act.MapFrom(src => src.StudentsStudentId));
            CreateMap<GradeAdd, Grade>()
                .ForMember(dest => dest.GradedefGradedefId, act => act.MapFrom(src => src.GradedefId))
                .ForMember(dest => dest.StudentsStudentId, act => act.MapFrom(src => src.StudentId))
                .ForMember(dest => dest.SubjectsSubjectId, act => act.MapFrom(src => src.SubjectId))
                .ForMember(dest => dest.TeachersTeacherId, act => act.MapFrom(src => src.TeacherId));
            CreateMap<GradeDelete, Grade>();
        }
    }
}
