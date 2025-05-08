using day6.CourseSystem.Interfaces;

namespace day6.CourseSystem.DataModels;

public class Course : ICourseService
{
    public List<Student> Students { get; set; }
    public string CourseName { get; set; }
    public int Credits { get; set; }

    public Course(string coursename, int credits)
    {
        Students = new List<Student>();
        CourseName = coursename;
        Credits = credits;
    }

    public int AddStudent(Student student)
    {
        if (Students.Contains(student)) return 0;
        Students.Add(student);
        return 1;
    }

    public int RemoveStudent(Student student)
    {
        if (!Students.Contains(student)) return 0;
        Students.Remove(student);
        return 1;
    }

    public void ListStudents()
    {
        foreach (var student in Students)
        {
            Console.WriteLine(student.Name);
        }
    }

    public int AssignGrade(Student student, char grade)
    {
        if (Students.Contains(student)) return 0;
        student.CourseGrades[this] = grade;
        return 1;
    }
    
}