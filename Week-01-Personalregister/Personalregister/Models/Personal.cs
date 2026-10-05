namespace Personalregister.Models;

public class Personal
{
  public Guid Id { get; set; }
  public string FirstName { get; set; }
  public string LastName { get; set; }
  public decimal SalaryByMonth { get; set; }

  public Personal(string fname, string lname, decimal salary)
  {
    Id = Guid.NewGuid();
    FirstName = fname;
    LastName = lname;
    SalaryByMonth = salary;
  }

  public string GetFullname()
  {
    return $"{FirstName} {LastName}";
  }
}
