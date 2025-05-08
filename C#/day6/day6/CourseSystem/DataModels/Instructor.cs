using day6.CourseSystem.Interfaces;

namespace day6.CourseSystem.DataModels;
public class Instructor : Person, IInstructorService
{
    public string Department { get; private set; }
    public DateTime JoinDate { get; private set; }
    public bool IsHeadOfDepartment { get; set; }

    public Instructor(string name, int id, DateTime birthday, decimal salary, 
        string department, DateTime joinDate, bool isHeadOfDepartment = false) 
        : base(name, id, birthday, salary)
    {
        Department = department;
        JoinDate = joinDate;
        IsHeadOfDepartment = isHeadOfDepartment;
    }

    public int CalculateYearOfExperience()
    {
        DateTime now = DateTime.Now;
        int years = now.Year - JoinDate.Year;
        if (now.Month < Birthday.Month || (now.Month == Birthday.Month && now.Day < Birthday.Day))
        {
            years--;
        }
        return years;
    }

    public new decimal CalculateSalary(int hours)
    {
        return hours * (Salary + CalculateYearOfExperience());
    }


}