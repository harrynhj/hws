namespace day5;

public class Birthday
{
    public static void sol()
    {
        DateTime birthDate = new DateTime(2000, 1, 1);
        DateTime today = DateTime.Today;
        
        int ageInDays = (today - birthDate).Days;
        Console.WriteLine($"You are {ageInDays} days old.");
        
        int daysToNextAnniversary = 10000 - (ageInDays % 10000);
        DateTime nextAnniversary = today.AddDays(daysToNextAnniversary);
        Console.WriteLine($"Your next 10,000-day anniversary is on {nextAnniversary.ToShortDateString()}.");
    }
}