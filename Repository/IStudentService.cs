using Practical_17.Models;

namespace Practical_17.Repository
{
    public interface IStudentService
    {
        Students GetStudentById(int id);
        IEnumerable<Students> GetAllStudents();

        void AddStudent(Students student);
        void UpdateStudent(Students student);
        int DeleteStudent(int id);
    }
}
