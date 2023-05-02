using EntityFrameworkCoreINHA.Context;
using EntityFrameworkCoreINHA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCoreINHA
{
    public class DbService
    {
        public DbService() { }

        public int CreateStudents()
        {
            using (var context = new INHAContext())
            {

                var students = new List<Student>
                {
                    new Student()
                    {
                        Name = "Jasur"
                    },

                    new Student()
                    {
                        Name = "Makhmud"
                    },

                    new Student()
                    {
                        Name = "Zilola"
                    }
                };
                
                context.Students.AddRange(students);
                context.Courses.Add(new Course { Name = "DB" });
                return context.SaveChanges();
            }
        }

        public int CreateCourses()
        {
            using (var context = new INHAContext())
            {

                var courses = new List<Course>
                {
                    new Course()
                    {
                        Name = "Math"
                    },

                    new Course()
                    {
                        Name = "Physics"
                    },

                    new Course()
                    {
                        Name = "Operating Systems"
                    }
                };

                context.Courses.AddRange(courses);
                return context.SaveChanges();
            }
        }

        public int UpdateStudent()
        {
            using (var context = new INHAContext())
            {
                var student = context.Students.First();
                student.Description = "Address: Ziyolilar 14";
                return context.SaveChanges();
            }
        }

        public int DeleteStudent()
        {
            using (var context = new INHAContext())
            {
                var student = context.Students.First();
                context.Students.Remove(student);
                return context.SaveChanges();
            }
        }

        public ICollection<Student> GetAllStudents()
        {
            using (var context = new INHAContext())
            {
                return context.Students.ToList();
            }
        }

        public ICollection<Student> WhereStudentsMethod()
        {
            using (var context = new INHAContext())
            {
                var students = context.Students;
                return students.Where(s => s.Age > 20).ToList();
            }
        }

        public ICollection<Student> WhereStudentsQuery()
        {
            using (var context = new INHAContext())
            {
                var students = context.Students;
                var result = (from s in students
                             where s.Age > 20
                             select s).ToList();
                return result;
            }
        }

        public ICollection<Student> OrderbyStudentsMethod()
        {
            using (var context = new INHAContext())
            {
                var students = context.Students;
                return students.OrderBy(s => s.Age).ToList();
            }
        }

        public ICollection<Student> OrderbyStudentsQuery()
        {
            using (var context = new INHAContext())
            {
                var students = context.Students;
                var result = (from s in students
                              orderby s.Age
                              select s).ToList();
                return result;
            }
        }

        public ICollection<(Student, string)> JoinStudentsMethod()
        {
            using (var context = new INHAContext())
            {
                var students = context.Students.ToList();
                var ages = new Dictionary<int, string>() { { 20, "twenty" }, { 21, "twentyOne" } };
                return students.Join(ages,
                    s => s.Age,
                    a => a.Key,
                    (a, s) => (a, s.Value)).ToList();
            }
            
        }

        public ICollection<(Student, string)> JoinStudentsQuery()
        {
            using (var context = new INHAContext())
            {
                var students = context.Students.ToList();
                var ages = new Dictionary<int, string>() { { 20, "twenty" }, { 21, "twentyOne" } };
                var result = from s in students
                             join age in ages
                             on s.Age equals age.Key
                             select (s, age.Value);
                return result.ToList();
            }
            
        }
    }
}
