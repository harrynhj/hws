using day6.CourseSystem.DataModels;

namespace day6.CourseSystem.Interfaces;

public interface ICourseService
{
    public int AddStudent(Student student);
    
    public void ListStudents();
    
    public int RemoveStudent(Student student);
    
    public int AssignGrade(Student student, char grade);
}