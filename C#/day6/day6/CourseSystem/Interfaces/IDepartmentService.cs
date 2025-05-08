using day6.CourseSystem.DataModels;

namespace day6.CourseSystem.Interfaces;


public interface IDepartmentService
{
    public int AddCourse(Course course);
    public int SetHead(Instructor instructor);
}