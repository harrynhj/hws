using day6.CourseSystem.Interfaces;

namespace day6.CourseSystem.DataModels;

public class Student : Person, IStudentService
{
    public Dictionary<Course, char> CourseGrades { get; set; }


    public Student(string name, int id, DateTime birthday, decimal salary) : base(name, id, birthday, salary)
    {
        CourseGrades = new Dictionary<Course, char>();
    }

    public decimal GetGPA()
    {
        int actualCredits = 0;
        int allCredits = 0;
        foreach (var entry in CourseGrades)
        {
            var course = entry.Key;
            char grade = entry.Value;
            int gradeInt = 0;
            switch (grade)
            {
                case 'A':
                    gradeInt = 4;
                    break;
                case 'B':
                    gradeInt = 3;
                    break;
                case 'C':
                    gradeInt = 2;
                    break;
                case 'D':
                    gradeInt = 1;
                    break;
                default:
                    break;
            }
            actualCredits += gradeInt;
            allCredits += course.Credits;
        }
        if (allCredits == 0) return 4;
        return 4*(Convert.ToDecimal(actualCredits) / Convert.ToDecimal(allCredits));
        
    }
}