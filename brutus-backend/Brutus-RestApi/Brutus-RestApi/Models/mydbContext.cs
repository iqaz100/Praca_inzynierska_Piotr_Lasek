using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Brutus_RestApi.Models
{
    public partial class mydbContext : DbContext
    {
        public mydbContext()
        {
        }

        public mydbContext(DbContextOptions<mydbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Absence> Absence { get; set; }
        public virtual DbSet<Absences1> Absences1 { get; set; }
        public virtual DbSet<AbsencesLogs> AbsencesLogs { get; set; }
        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<Behavior> Behavior { get; set; }
        public virtual DbSet<BehaviorsLogs> BehaviorsLogs { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Class> Class { get; set; }
        public virtual DbSet<Family> Family { get; set; }
        public virtual DbSet<Grade> Grade { get; set; }
        public virtual DbSet<GradeLogs> GradeLogs { get; set; }
        public virtual DbSet<Gradedef> Gradedef { get; set; }
        public virtual DbSet<Lesson> Lesson { get; set; }
        public virtual DbSet<Login> Login { get; set; }
        public virtual DbSet<Parent> Parent { get; set; }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<ReportCard1> ReportCard1 { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<Subject> Subject { get; set; }
        public virtual DbSet<Teacher> Teacher { get; set; }
        public virtual DbSet<Timetable> Timetable { get; set; }
        public virtual DbSet<Timetable2> Timetable2 { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("Server=localhost;Database=mydb;User=root;Password=13jaro13;TreatTinyAsBoolean=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Absence>(entity =>
            {
                entity.HasKey(e => new { e.AbsenceId, e.StudentsStudentId, e.LessonsLessonId })
                    .HasName("PRIMARY");

                entity.ToTable("absence");

                entity.HasIndex(e => e.LessonsLessonId)
                    .HasName("fk_ABSENCES_LESSONS1_idx");

                entity.HasIndex(e => e.StudentsStudentId)
                    .HasName("fk_ABSENCES_STUDENTS1_idx");

                entity.Property(e => e.AbsenceId)
                    .HasColumnName("absence_id")
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.StudentsStudentId)
                    .HasColumnName("STUDENTS_student_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.LessonsLessonId)
                    .HasColumnName("LESSONS_lesson_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Excused)
                    .IsRequired()
                    .HasColumnName("excused")
                    .HasColumnType("char(1)")
                    .HasCharSet(Pomelo.EntityFrameworkCore.MySql.Storage.CharSet.Utf8Mb4);
            });

            modelBuilder.Entity<Absences1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("absences1");

                entity.Property(e => e.Excused)
                    .IsRequired()
                    .HasColumnName("excused")
                    .HasColumnType("char(1)")
                    .HasCharSet(Pomelo.EntityFrameworkCore.MySql.Storage.CharSet.Utf8Mb4);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("first_name")
                    .HasColumnType("varchar(20)")
                    .HasCharSet(Pomelo.EntityFrameworkCore.MySql.Storage.CharSet.Utf8Mb4);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("last_name")
                    .HasColumnType("varchar(55)")
                    .HasCharSet(Pomelo.EntityFrameworkCore.MySql.Storage.CharSet.Utf8Mb4);

                entity.Property(e => e.LessonDatetime)
                    .HasColumnName("lesson_datetime")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<AbsencesLogs>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("absences_logs");

                entity.Property(e => e.ChangeType)
                    .HasColumnName("change_type")
                    .HasColumnType("varchar(20)")
                    .HasCharSet(Pomelo.EntityFrameworkCore.MySql.Storage.CharSet.Utf8Mb4);

                entity.Property(e => e.LogDate)
                    .HasColumnName("log_date")
                    .HasColumnType("timestamp");

                entity.Property(e => e.Who)
                    .HasColumnName("who")
                    .HasColumnType("varchar(50)")
                    .HasCharSet(Pomelo.EntityFrameworkCore.MySql.Storage.CharSet.Utf8Mb4);
            });

            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("address");

                entity.Property(e => e.AddressId)
                    .HasColumnName("address_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ApartamentNumber)
                    .HasColumnName("apartament_number")
                    .HasColumnType("varchar(5)")
                    .HasCharSet(Pomelo.EntityFrameworkCore.MySql.Storage.CharSet.Utf8Mb4);

                entity.Property(e => e.BuildingNumber)
                    .IsRequired()
                    .HasColumnName("building_number")
                    .HasColumnType("varchar(5)")
                    .HasCharSet(Pomelo.EntityFrameworkCore.MySql.Storage.CharSet.Utf8Mb4);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasColumnName("city")
                    .HasColumnType("varchar(31)")
                    .HasCharSet(Pomelo.EntityFrameworkCore.MySql.Storage.CharSet.Utf8Mb4);

                entity.Property(e => e.Street)
                    .IsRequired()
                    .HasColumnName("street")
                    .HasColumnType("varchar(75)")
                    .HasCharSet(Pomelo.EntityFrameworkCore.MySql.Storage.CharSet.Utf8Mb4);

                entity.Property(e => e.ZipCode)
                    .IsRequired()
                    .HasColumnName("zip_code")
                    .HasColumnType("varchar(6)")
                    .HasCharSet(Pomelo.EntityFrameworkCore.MySql.Storage.CharSet.Utf8Mb4);
            });

            modelBuilder.Entity<Behavior>(entity =>
            {
                entity.HasKey(e => new { e.BehaviorId, e.StudentsStudentId })
                    .HasName("PRIMARY");

                entity.ToTable("behavior");

                entity.HasIndex(e => e.StudentsStudentId)
                    .HasName("fk_BEHAVIORS_STUDENTS1_idx");

                entity.Property(e => e.BehaviorId)
                    .HasColumnName("behavior_id")
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.StudentsStudentId)
                    .HasColumnName("STUDENTS_student_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Behavior1)
                    .IsRequired()
                    .HasColumnName("behavior")
                    .HasColumnType("varchar(200)")
                    .HasCharSet(Pomelo.EntityFrameworkCore.MySql.Storage.CharSet.Utf8Mb4);

                entity.Property(e => e.BehaviorType)
                    .IsRequired()
                    .HasColumnName("behavior_type")
                    .HasColumnType("varchar(45)")
                    .HasCharSet(Pomelo.EntityFrameworkCore.MySql.Storage.CharSet.Utf8Mb4);
            });

            modelBuilder.Entity<BehaviorsLogs>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("behaviors_logs");

                entity.Property(e => e.ChangeType)
                    .HasColumnName("change_type")
                    .HasColumnType("varchar(20)")
                    .HasCharSet(Pomelo.EntityFrameworkCore.MySql.Storage.CharSet.Utf8Mb4);

                entity.Property(e => e.LogDate)
                    .HasColumnName("log_date")
                    .HasColumnType("timestamp");

                entity.Property(e => e.Who)
                    .HasColumnName("who")
                    .HasColumnType("varchar(50)")
                    .HasCharSet(Pomelo.EntityFrameworkCore.MySql.Storage.CharSet.Utf8Mb4);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("category");

                entity.Property(e => e.CategoryId)
                    .HasColumnName("category_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(255)")
                    .HasCharSet(Pomelo.EntityFrameworkCore.MySql.Storage.CharSet.Utf8Mb4);
            });

            modelBuilder.Entity<Class>(entity =>
            {
                entity.HasKey(e => new { e.ClassId, e.TeachersTeacherId })
                    .HasName("PRIMARY");

                entity.ToTable("class");

                entity.HasIndex(e => e.TeachersTeacherId)
                    .HasName("fk_CLASSES_TEACHERS1_idx");

                entity.Property(e => e.ClassId)
                    .HasColumnName("class_id")
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.TeachersTeacherId)
                    .HasColumnName("TEACHERS_teacher_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ClassTitle)
                    .IsRequired()
                    .HasColumnName("class_title")
                    .HasColumnType("varchar(50)")
                    .HasCharSet(Pomelo.EntityFrameworkCore.MySql.Storage.CharSet.Utf8Mb4);

                entity.Property(e => e.EndYear)
                    .HasColumnName("end_year")
                    .HasColumnType("int(11)");

                entity.Property(e => e.StartYear)
                    .HasColumnName("start_year")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<Family>(entity =>
            {
                entity.HasKey(e => new { e.ParentsParentId, e.StudentsStudentId })
                    .HasName("PRIMARY");

                entity.ToTable("family");

                entity.HasIndex(e => e.StudentsStudentId)
                    .HasName("fk_FAMILY_STUDENTS1_idx");

                entity.Property(e => e.ParentsParentId)
                    .HasColumnName("PARENTS_parent_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.StudentsStudentId)
                    .HasColumnName("STUDENTS_student_id")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<Grade>(entity =>
            {
                entity.HasKey(e => new { e.GradeId, e.GradedefGradedefId, e.StudentsStudentId, e.TeachersTeacherId, e.SubjectsSubjectId })
                    .HasName("PRIMARY");

                entity.ToTable("grade");

                entity.HasIndex(e => e.GradedefGradedefId)
                    .HasName("fk_GRADES_GRADEDEF1_idx");

                entity.HasIndex(e => e.StudentsStudentId)
                    .HasName("fk_GRADES_STUDENTS1_idx");

                entity.HasIndex(e => e.SubjectsSubjectId)
                    .HasName("fk_GRADES_SUBJECTS1_idx");

                entity.HasIndex(e => e.TeachersTeacherId)
                    .HasName("fk_GRADES_TEACHERS1_idx");

                entity.Property(e => e.GradeId)
                    .HasColumnName("grade_id")
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.GradedefGradedefId)
                    .HasColumnName("GRADEDEF_gradedef_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.StudentsStudentId)
                    .HasColumnName("STUDENTS_student_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TeachersTeacherId)
                    .HasColumnName("TEACHERS_teacher_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SubjectsSubjectId)
                    .HasColumnName("SUBJECTS_subject_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.GradeDatetime)
                    .HasColumnName("grade_datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.GradeScale)
                    .IsRequired()
                    .HasColumnName("grade_scale")
                    .HasColumnType("varchar(45)")
                    .HasCharSet(Pomelo.EntityFrameworkCore.MySql.Storage.CharSet.Utf8Mb4);

                entity.Property(e => e.GradeType)
                    .IsRequired()
                    .HasColumnName("grade_type")
                    .HasColumnType("varchar(10)")
                    .HasCharSet(Pomelo.EntityFrameworkCore.MySql.Storage.CharSet.Utf8Mb4);

                entity.HasOne(d => d.GradedefGradedef)
                    .WithMany(p => p.GradeNavigation)
                    .HasForeignKey(d => d.GradedefGradedefId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_GRADES_GRADEDEF1");

                entity.HasOne(d => d.SubjectsSubject)
                    .WithMany(p => p.Grade)
                    .HasForeignKey(d => d.SubjectsSubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_GRADES_SUBJECTS1");
            });

            modelBuilder.Entity<GradeLogs>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("grade_logs");

                entity.Property(e => e.ChangeType)
                    .HasColumnName("change_type")
                    .HasColumnType("varchar(20)")
                    .HasCharSet(Pomelo.EntityFrameworkCore.MySql.Storage.CharSet.Utf8Mb4);

                entity.Property(e => e.LogDate)
                    .HasColumnName("log_date")
                    .HasColumnType("timestamp");

                entity.Property(e => e.Who)
                    .HasColumnName("who")
                    .HasColumnType("varchar(50)")
                    .HasCharSet(Pomelo.EntityFrameworkCore.MySql.Storage.CharSet.Utf8Mb4);
            });

            modelBuilder.Entity<Gradedef>(entity =>
            {
                entity.ToTable("gradedef");

                entity.Property(e => e.GradedefId)
                    .HasColumnName("gradedef_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Grade)
                    .HasColumnName("grade")
                    .HasColumnType("decimal(3,2)");
            });

            modelBuilder.Entity<Lesson>(entity =>
            {
                entity.HasKey(e => new { e.LessonId, e.SubjectsSubjectId, e.ClassesClassId, e.TeachersTeacherId })
                    .HasName("PRIMARY");

                entity.ToTable("lesson");

                entity.HasIndex(e => e.ClassesClassId)
                    .HasName("fk_LESSONS_CLASSES1_idx");

                entity.HasIndex(e => e.SubjectsSubjectId)
                    .HasName("fk_LESSONS_SUBJECTS_idx");

                entity.HasIndex(e => e.TeachersTeacherId)
                    .HasName("fk_LESSONS_TEACHERS1_idx");

                entity.Property(e => e.LessonId)
                    .HasColumnName("lesson_id")
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.SubjectsSubjectId)
                    .HasColumnName("SUBJECTS_subject_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ClassesClassId)
                    .HasColumnName("CLASSES_class_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TeachersTeacherId)
                    .HasColumnName("TEACHERS_teacher_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.LessonDatetime)
                    .HasColumnName("lesson_datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.LessonEnd)
                    .HasColumnName("lesson_end")
                    .HasColumnType("time");

                entity.Property(e => e.Room)
                    .IsRequired()
                    .HasColumnName("room")
                    .HasColumnType("varchar(4)")
                    .HasCharSet(Pomelo.EntityFrameworkCore.MySql.Storage.CharSet.Utf8Mb4);

                entity.Property(e => e.Topic)
                    .HasColumnName("topic")
                    .HasColumnType("varchar(100)")
                    .HasCharSet(Pomelo.EntityFrameworkCore.MySql.Storage.CharSet.Utf8Mb4);

                entity.HasOne(d => d.SubjectsSubject)
                    .WithMany(p => p.Lesson)
                    .HasForeignKey(d => d.SubjectsSubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_LESSONS_SUBJECTS");
            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.ToTable("login");

                entity.Property(e => e.LoginId)
                    .HasColumnName("login_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Login1)
                    .HasColumnName("login")
                    .HasColumnType("varchar(20)")
                    .HasCharSet(Pomelo.EntityFrameworkCore.MySql.Storage.CharSet.Utf8Mb4);

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasColumnType("varchar(55)")
                    .HasCharSet(Pomelo.EntityFrameworkCore.MySql.Storage.CharSet.Utf8Mb4);
            });

            modelBuilder.Entity<Parent>(entity =>
            {
                entity.HasKey(e => new { e.ParentId, e.PersonsPersonId })
                    .HasName("PRIMARY");

                entity.ToTable("parent");

                entity.HasIndex(e => e.PersonsPersonId)
                    .HasName("fk_PARENTS_PERSONS1_idx");

                entity.Property(e => e.ParentId)
                    .HasColumnName("parent_id")
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.PersonsPersonId)
                    .HasColumnName("PERSONS_person_id")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.HasKey(e => new { e.PersonId, e.AddressAddressId, e.LoginLoginId })
                    .HasName("PRIMARY");

                entity.ToTable("person");

                entity.HasIndex(e => e.AddressAddressId)
                    .HasName("fk_PERSON_ADDRESS1_idx");

                entity.HasIndex(e => e.LoginLoginId)
                    .HasName("fk_PERSON_LOGIN1_idx");

                entity.Property(e => e.PersonId)
                    .HasColumnName("person_id")
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.AddressAddressId)
                    .HasColumnName("ADDRESS_address_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.LoginLoginId)
                    .HasColumnName("LOGIN_login_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("first_name")
                    .HasColumnType("varchar(20)")
                    .HasCharSet(Pomelo.EntityFrameworkCore.MySql.Storage.CharSet.Utf8Mb4);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("last_name")
                    .HasColumnType("varchar(55)")
                    .HasCharSet(Pomelo.EntityFrameworkCore.MySql.Storage.CharSet.Utf8Mb4);

                entity.Property(e => e.Pesel)
                    .HasColumnName("pesel")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.AddressAddress)
                    .WithMany(p => p.Person)
                    .HasForeignKey(d => d.AddressAddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_PERSON_ADDRESS1");

                entity.HasOne(d => d.LoginLogin)
                    .WithMany(p => p.Person)
                    .HasForeignKey(d => d.LoginLoginId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_PERSON_LOGIN1");
            });

            modelBuilder.Entity<ReportCard1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("report_card1");

                entity.Property(e => e.Srednia).HasColumnName("srednia");

                entity.Property(e => e.SubjectName)
                    .IsRequired()
                    .HasColumnName("subject_name")
                    .HasColumnType("varchar(50)")
                    .HasCharSet(Pomelo.EntityFrameworkCore.MySql.Storage.CharSet.Utf8Mb4);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => new { e.StudentId, e.PersonsPersonId, e.ClassesClassId })
                    .HasName("PRIMARY");

                entity.ToTable("student");

                entity.HasIndex(e => e.ClassesClassId)
                    .HasName("fk_STUDENTS_CLASSES1_idx");

                entity.HasIndex(e => e.PersonsPersonId)
                    .HasName("fk_STUDENTS_PERSONS1_idx");

                entity.Property(e => e.StudentId)
                    .HasColumnName("student_id")
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.PersonsPersonId)
                    .HasColumnName("PERSONS_person_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ClassesClassId)
                    .HasColumnName("CLASSES_class_id")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.ToTable("subject");

                entity.Property(e => e.SubjectId)
                    .HasColumnName("subject_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("varchar(500)")
                    .HasCharSet(Pomelo.EntityFrameworkCore.MySql.Storage.CharSet.Utf8Mb4);

                entity.Property(e => e.SubjectName)
                    .IsRequired()
                    .HasColumnName("subject_name")
                    .HasColumnType("varchar(50)")
                    .HasCharSet(Pomelo.EntityFrameworkCore.MySql.Storage.CharSet.Utf8Mb4);
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.HasKey(e => new { e.TeacherId, e.PersonsPersonId })
                    .HasName("PRIMARY");

                entity.ToTable("teacher");

                entity.HasIndex(e => e.PersonsPersonId)
                    .HasName("fk_TEACHERS_PERSONS1_idx");

                entity.Property(e => e.TeacherId)
                    .HasColumnName("teacher_id")
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.PersonsPersonId)
                    .HasColumnName("PERSONS_person_id")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<Timetable>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("timetable");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("first_name")
                    .HasColumnType("varchar(20)")
                    .HasCharSet(Pomelo.EntityFrameworkCore.MySql.Storage.CharSet.Utf8Mb4);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("last_name")
                    .HasColumnType("varchar(55)")
                    .HasCharSet(Pomelo.EntityFrameworkCore.MySql.Storage.CharSet.Utf8Mb4);

                entity.Property(e => e.LessonDatetime)
                    .HasColumnName("lesson_datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.Room)
                    .IsRequired()
                    .HasColumnName("room")
                    .HasColumnType("varchar(4)")
                    .HasCharSet(Pomelo.EntityFrameworkCore.MySql.Storage.CharSet.Utf8Mb4);

                entity.Property(e => e.SubjectName)
                    .IsRequired()
                    .HasColumnName("subject_name")
                    .HasColumnType("varchar(50)")
                    .HasCharSet(Pomelo.EntityFrameworkCore.MySql.Storage.CharSet.Utf8Mb4);
            });

            modelBuilder.Entity<Timetable2>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("timetable2");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("first_name")
                    .HasColumnType("varchar(20)")
                    .HasCharSet(Pomelo.EntityFrameworkCore.MySql.Storage.CharSet.Utf8Mb4);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("last_name")
                    .HasColumnType("varchar(55)")
                    .HasCharSet(Pomelo.EntityFrameworkCore.MySql.Storage.CharSet.Utf8Mb4);

                entity.Property(e => e.LessonDatetime)
                    .HasColumnName("lesson_datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.Room)
                    .IsRequired()
                    .HasColumnName("room")
                    .HasColumnType("varchar(4)")
                    .HasCharSet(Pomelo.EntityFrameworkCore.MySql.Storage.CharSet.Utf8Mb4);

                entity.Property(e => e.SubjectName)
                    .IsRequired()
                    .HasColumnName("subject_name")
                    .HasColumnType("varchar(50)")
                    .HasCharSet(Pomelo.EntityFrameworkCore.MySql.Storage.CharSet.Utf8Mb4);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("user");

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasColumnType("varchar(255)")
                    .HasCharSet(Pomelo.EntityFrameworkCore.MySql.Storage.CharSet.Utf8Mb4);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasColumnType("varchar(32)")
                    .HasCharSet(Pomelo.EntityFrameworkCore.MySql.Storage.CharSet.Utf8Mb4);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasColumnType("varchar(16)")
                    .HasCharSet(Pomelo.EntityFrameworkCore.MySql.Storage.CharSet.Utf8Mb4);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
