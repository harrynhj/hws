using day6.CourseSystem.Interfaces;

namespace day6.CourseSystem.DataModels;

public class Department : IDepartmentService
{
    public Instructor HeadOfDepartment { get; set; }
    public List<Course> Courses { get; set; }
    public decimal BudgetAmount { get; set; }
    public DateTime BudgetStartDate { get; set; }
    public DateTime BudgetEndDate { get; set; }

    public int AddCourse(Course course)
    {
        if (Courses.Contains(course)) return 0;
        Courses.Add(course);
        return 1;
    }

    public int SetHead(Instructor instructor)
    {
        HeadOfDepartment.IsHeadOfDepartment = false;
        HeadOfDepartment = instructor;
        instructor.IsHeadOfDepartment = true;
        return 1;
    }
}

