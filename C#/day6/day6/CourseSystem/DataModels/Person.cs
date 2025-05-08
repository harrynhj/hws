using day6.CourseSystem.Interfaces;

namespace day6.CourseSystem.DataModels;

public class Person : IPersonService
{
    public string Name { get; set; }
    public int Id { get; set; }
    public DateTime Birthday { get; set; }
    private decimal _salary;
    public decimal Salary {
        get
        {
            return _salary;
        }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Salary cannot be negative");
            }
            _salary = value;
        }
    }
    public List<string> Addresses { get; set; }

    public Person(string name, int  id, DateTime birthday, decimal salary)
    {
        Addresses = new List<string>();
        Name = name;
        Id = id;
        Birthday = birthday;
        Salary = salary;
    }

    public int CalculateAge()
    {
        DateTime now = DateTime.Now;
        int age = now.Year - Birthday.Year;
        if (now.Month < Birthday.Month || (now.Month == Birthday.Month && now.Day < Birthday.Day))
        {
            age--;
        }
        return age;
    }

    public decimal CalculateSalary(int hours)
    {
        return Salary * hours;
    }


}