namespace day6.CourseSystem.Interfaces;


public interface IStudentService : IPersonService
{
    public decimal GetGPA();
    
}